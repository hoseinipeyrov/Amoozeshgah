using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Amoozeshgah.Common.Domain;
using Amoozeshgah.ViewModel;
using Amoozeshgah.Core.Infrastructure;
using Amoozeshgah.Domain.Entities;
using Amoozeshgah.Common;
using Amoozeshgah.Common.DateConverter;
using Microsoft.Ajax.Utilities;

namespace Amoozeshgah.WebUI.Areas.EducationalCenterUserArea.Controllers
{

    public class BaseInformationsController : Controller
    {
        private readonly AppContext _db = new AppContext();
        private readonly int _siteId = WebUserInfo.SiteId;

        [HttpGet]
        public ActionResult BasicInfo()
        {
            var educationalCenter = _db.Set<EducationalCenter>().Include("Site").Include("CategoryItems").Include("Shift").Include("Sex").Include("CertificateType").Include("CourseHoldingTypes").FirstOrDefault(ec => ec.Id == _siteId);
            if (educationalCenter != null)
            {
                return View(new BasicInfoDto
                {
                    Id = _siteId,
                    Name = educationalCenter.Site.Name,
                    PhoneNo1 = educationalCenter.Site.PhoneNo1,
                    PostalCode = educationalCenter.PostalCode,
                    Sex = educationalCenter.Sex.Title,
                    CertificateCode = educationalCenter.CertificateCode,
                    Category = educationalCenter.Category,
                    CategoryItems = educationalCenter.CategoryItems.Select(c => c.Name).ToArray(),
                    Shift = educationalCenter.Shift.Name,
                    Address = educationalCenter.Site.Address,
                    CertificateTypeId = educationalCenter.CertificateTypeId,
                    CertificateTypes = _db.Set<CertificateType>().ToList().Select(ct => new SelectListItem
                    {
                        Text = ct.Title,
                        Value = ct.Id.ToString()
                    }),
                    EstablishmentDate = educationalCenter.EstablishmentDate,
                    CourseHoldingTypes = _db.Set<CourseHoldingType>().ToList().Select(cht => new SelectListItem
                    {
                        Text = cht.Name,
                        Value = cht.Id.ToString(),
                        Selected = educationalCenter.CourseHoldingTypes.Contains(cht)
                    })

                });
            }


            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult BasicInfo(BasicInfoDto model)
        {

            var educationalCenter = _db.Set<EducationalCenter>().Include("Site").Include("CategoryItems").Include("Shift").Include("Sex").Include("CertificateType").Include("CourseHoldingTypes").FirstOrDefault(ec => ec.Id == _siteId);

            var courseHoldingTypes = _db.Set<CourseHoldingType>().Where(c => model.CourseHoldingTypesIds.Contains(c.Id)).ToList();
            educationalCenter.CourseHoldingTypes = courseHoldingTypes;
            educationalCenter.Site.PhoneNo1 = model.PhoneNo1;
            educationalCenter.PostalCode = model.PostalCode;
            educationalCenter.Site.Address = model.Address;
            educationalCenter.CertificateTypeId = model.CertificateTypeId;
            educationalCenter.CertificateCode = model.CertificateCode;
            educationalCenter.EstablishmentDate = model.EstablishmentDate;

            _db.Entry(educationalCenter).State = EntityState.Modified;
            _db.SaveChanges();
            TempData["Message"] = "با موفقیت ثبت گردید";
            return RedirectToAction("BasicInfo");
        }

        [HttpGet]
        public ActionResult EstateInfo()
        {
            var educationalCenter = _db.Set<EducationalCenter>().Find(_siteId);

            if (educationalCenter != null)
                return View(new EstateDto
                {
                    HavePrayerRoom = educationalCenter.HavePrayerRoom.ToHaveNotHave(),
                    HaveLibrary = educationalCenter.HaveLibrary.ToHaveNotHave(),
                    HavePlaceConfirmation = educationalCenter.HavePlaceConfirmation.ToHaveNotHave(),
                    ApplicationType = educationalCenter.IsApplicationTypeForLearning.ToApplicationType(),
                    HaveLanguageLaborator = educationalCenter.HaveLanguageLaborator.ToHaveNotHave(),
                    HaveSmartSystem = educationalCenter.HaveSmartSystem.ToHaveNotHave(),
                    HaveSite = educationalCenter.HaveSite.ToHaveNotHave(),
                    HaveAdvisorRoom = educationalCenter.HaveAdvisorRoom.ToHaveNotHave(),
                    HaveDedicatedBuffet = educationalCenter.HaveDedicatedBuffet.ToHaveNotHave(),
                    HaveWarmWc = educationalCenter.HaveWarmWc.ToHaveNotHave(),
                    EstateStatusId = educationalCenter.EstateStatusId,
                    HaveDedicatedDrinking = educationalCenter.HaveDedicatedDrinking.ToHaveNotHave(),
                    AreaArenaMeter = educationalCenter.AreaArenaMeter,
                    AreaLordMeter = educationalCenter.AreaLordMeter,
                    MonthlyRentCost = educationalCenter.MonthlyRentCost,
                    FloorCount = educationalCenter.FloorCount,

                    EstateStatus = _db.Set<EstateStatus>().ToList().Select(es => new SelectListItem
                    {
                        Text = es.Name,
                        Value = es.Id.ToString()
                    })
                });



            return HttpNotFound();
        }
        [HttpPost]
        public ActionResult EstateInfo(EstateDto model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(null, "لطفا خطا ها را برطرف نمایید");
                return View(model);
            }

            var educationalCenter = _db.Set<EducationalCenter>().Find(_siteId);

            educationalCenter.HavePrayerRoom = model.HavePrayerRoom.TooBool();
            educationalCenter.HaveLibrary = model.HaveLibrary.TooBool();
            educationalCenter.HavePlaceConfirmation = model.HavePlaceConfirmation.TooBool();
            educationalCenter.IsApplicationTypeForLearning = model.ApplicationType == ApplicationType.Learning;
            educationalCenter.HaveLanguageLaborator = model.HaveLanguageLaborator.TooBool();
            educationalCenter.HaveSmartSystem = model.HaveSmartSystem.TooBool();
            educationalCenter.HaveSite = model.HaveSite.TooBool();
            educationalCenter.HaveAdvisorRoom = model.HaveAdvisorRoom.TooBool();
            educationalCenter.HaveDedicatedBuffet = model.HaveDedicatedBuffet.TooBool();
            educationalCenter.HaveWarmWc = model.HaveWarmWc.TooBool();
            educationalCenter.HaveDedicatedDrinking = model.HaveDedicatedDrinking.TooBool();
            educationalCenter.EstateStatusId = model.EstateStatusId;
            educationalCenter.AreaArenaMeter = model.AreaArenaMeter;
            educationalCenter.AreaLordMeter = model.AreaLordMeter;
            educationalCenter.FloorCount = model.FloorCount;
            educationalCenter.MonthlyRentCost = model.MonthlyRentCost;
            _db.Entry(educationalCenter).State = EntityState.Modified;
            _db.SaveChanges();

            TempData["Message"] = "با موفقیت ثبت گردید";
            return RedirectToAction(nameof(EstateInfo));
        }

        [HttpGet]
        public ActionResult CertificateInfo()
        {
            var educationalCenter = _db.Set<EducationalCenter>().Find(_siteId);

            return View(new CertificateDto
            {
                TemporaryEstablishmentCertificateJalaliDate = educationalCenter.TemporaryEstablishmentCertificateJalaliDate,
                TemporaryEstablishmentCertificateNumber = educationalCenter.TemporaryEstablishmentCertificateNumber,

                BootCertificateJalaliDate = educationalCenter.BootCertificateJalaliDate,
                BootCertificateNumber = educationalCenter.BootCertificateNumber,


                EvenOddCertificateJalaliDate = educationalCenter.EvenOddCertificateJalaliDate,
                EvenOddCertificateNumber = educationalCenter.EvenOddCertificateNumber,

                MovementCertificateJalaliDate = educationalCenter.MovementCertificateJalaliDate

            });
        }
        //src.StartDate.ToJalalDateTime(DateFormat.YearMonthDay)
        [HttpPost]
        public ActionResult CertificateInfo(CertificateDto model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(null, "داده های ورودی را بررسی کنید");
                return View(model);
            }
            var temporaryEstablishmentCertificateGeorgianDate = model.TemporaryEstablishmentCertificateJalaliDate.ToGeorgianDateTime();
            var bootCertificateGeorgianDate = model.BootCertificateJalaliDate.ToGeorgianDateTime();
            var movementCertificateGeorgianDate = model.MovementCertificateJalaliDate.ToGeorgianDateTime();
            var evenOddCertificateGeorgianDate = model.EvenOddCertificateJalaliDate.ToGeorgianDateTime();


            var educationalCenter = _db.Set<EducationalCenter>().Find(_siteId);


            educationalCenter.TemporaryEstablishmentCertificateJalaliDate =
                model.TemporaryEstablishmentCertificateJalaliDate;
            educationalCenter.TemporaryEstablishmentCertificateGeorgianDate =
                temporaryEstablishmentCertificateGeorgianDate;



            educationalCenter.BootCertificateJalaliDate =
                model.BootCertificateJalaliDate;
            educationalCenter.BootCertificateGeorgianDate =
                bootCertificateGeorgianDate;


            educationalCenter.MovementCertificateJalaliDate =
                model.MovementCertificateJalaliDate;
            educationalCenter.MovementCertificateGeorgianDate =
                movementCertificateGeorgianDate;


            educationalCenter.EvenOddCertificateJalaliDate =
                model.EvenOddCertificateJalaliDate;
            educationalCenter.EvenOddCertificateGeorgianDate =
                evenOddCertificateGeorgianDate;


            educationalCenter.TemporaryEstablishmentCertificateNumber = model.TemporaryEstablishmentCertificateNumber;
            educationalCenter.BootCertificateNumber = model.BootCertificateNumber;
            educationalCenter.EvenOddCertificateNumber = model.EvenOddCertificateNumber;


            _db.Entry(educationalCenter).State = EntityState.Modified;
            _db.SaveChanges();


            TempData["Message"] = "با موفقیت ثبت گردید";
            return RedirectToAction(nameof(CertificateInfo));
        }


        [HttpGet]
        public ActionResult AccountInfo()
        {
            var accountInformation = _db.Set<AccountInformation>().FirstOrDefault(ec => ec.EducationalCenterId == _siteId);
            var accountInformationDto = new AccountInformationDto
            {
                Banks = _db.Set<Bank>().ToList().Select(b => new SelectListItem
                {
                    Text = b.Name,
                    Value = b.Id.ToString()
                })
            };

            if (accountInformation == null)
            {
                return View(accountInformationDto);

            }

            accountInformationDto.AccountOwnerFirstName = accountInformation.AccountOwnerFirstName;
            accountInformationDto.AccountOwnerLastName = accountInformation.AccountOwnerLastName;
            accountInformationDto.BrancheName = accountInformation.BrancheName;
            accountInformationDto.BrancheCode = accountInformation.BrancheCode;
            accountInformationDto.AccountNumber = accountInformation.AccountNumber;
            accountInformationDto.IdPay = accountInformation.IdPay;

            accountInformationDto.BankId = accountInformation.BankId;
            


            return View(accountInformationDto);
        }

        [HttpPost]
        public ActionResult AccountInfo(AccountInformationDto model)
        {
            var accountInformation = new AccountInformation
            {
                EducationalCenterId = _siteId,
                AccountOwnerFirstName = model.AccountOwnerFirstName,
                AccountOwnerLastName = model.AccountOwnerLastName,
                BankId = model.BankId,
                BrancheCode = model.BrancheCode.Value,
                BrancheName = model.BrancheName,
                AccountNumber = model.AccountNumber,
                IdPay = model.IdPay,
                IdPayNumbers = model.IdPay.Replace("-","").Replace("IR",""),
            };

            _db.Set<AccountInformation>().AddOrUpdate(m=>m.EducationalCenterId, accountInformation);
            _db.SaveChanges();
            TempData["Message"] = "با موفقیت ثبت گردید";

            return RedirectToAction("AccountInfo");
        }

        [HttpGet]
        public ActionResult Rules()
        {
            var ecId = WebUserInfo.SiteId;
            var educationalCenter = _db.Set<EducationalCenter>().Include(ec=>ec.Site).First(ec => ec.Id == ecId);
            var ruleViewModel = new EducationalCenterRuleDto
            {
                Rule = educationalCenter.Rule,
                EducationalCenterName = $"قوانین مرکز آموزشی {educationalCenter.Site.Name}"
            };
            return View(ruleViewModel);
        }

        [HttpPost]
        public ActionResult Rules(EducationalCenterRuleDto model)
        {
            var clearerRule = model.Rule.Replace("&nbsp;", "").Replace("<p>", "").Replace("<br>", "").Replace("</p>", "");
            if (clearerRule.IsNullOrWhiteSpace())
            {
                return Json(new { success = false, message = "قوانین مرکز آموزشی را وارد نمایید" }, JsonRequestBehavior.AllowGet);
            }
            var ecId = WebUserInfo.SiteId;
            var educationalCenter = _db.Set<EducationalCenter>().First(ec => ec.Id == ecId);
            educationalCenter.Rule = model.Rule;
            _db.Entry(educationalCenter).State = EntityState.Modified;
            _db.SaveChanges();
            return Json(new { success = true, message = "قوانین مرکز آموزشی ذخیره شد" }, JsonRequestBehavior.AllowGet);
        }
    }


}
