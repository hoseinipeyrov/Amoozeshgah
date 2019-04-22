using Amoozeshgah.Common;
using Amoozeshgah.Common.Domain;
using Amoozeshgah.Core.Infrastructure;
using Amoozeshgah.Domain.Entities;
using Amoozeshgah.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Amoozeshgah.WebUI.Areas.AdministratorArea.Controllers
{
    public class ManageEducationalCentersController : Controller
    {
        AppContext db = new AppContext();
        public ActionResult Index()
        {
            var areaId = WebUserInfo.SiteId;
            var educationalCenters = db.Set<EducationalCenter>().Include("Site").Include("Sex").Include("CategoryItems").Where(ec => ec.AreaId == areaId).ToList();
            return View(educationalCenters);
        }
        [HttpGet]
        public ActionResult CreateNewEducationalCenter()
        {
            return View(new EducationalCenterDefinitionDto
            {
                Sexes = db.Set<Sex>().ToList().Select(s => new SelectListItem
                {
                    Text = s.Title,
                    Value = s.Id.ToString()
                }),
                Shifts = db.Set<Shift>().ToList().Select(s => new SelectListItem
                {
                    Text = s.Name,
                    Value = s.Id.ToString()
                })
            });
        }

        [HttpPost]
        public ActionResult CreateNewEducationalCenter(EducationalCenterDefinitionDto model)
        {
            var areaId = WebUserInfo.SiteId;
            var stepNo = 1000;

            var newSiteId = db.Set<EducationalCenter>().Where(ec => ec.AreaId == areaId).OrderByDescending(ec => ec.CreatedDate).FirstOrDefault();
            if (newSiteId != null)
            {
                stepNo = Convert.ToInt32((newSiteId.Id.ToString()).Substring(6)) + 1;

            }

            var cis = db.Set<CategoryItem>().Include("Category").Where(c => model.CategoryItemsIds.Contains(c.Id)).ToList();
            var cat = cis.First().Category;
            var catName = cat.Name;
            var catCode = cat.Code;
            var userId = WebUserInfo.UserId.ToString();
            var ecGeneratedId = EducationalCenterCodeGenetrator.GenerateNew(areaId, model.SexId, catCode, stepNo);

            var educationalCenter = new EducationalCenter
            {
                AreaId = areaId,
                CertificateCode = model.CertificateCode,
                SexId = model.SexId,
                CreatedBy = userId,
                MoassesFirstName = model.MoassesFirstName,
                MoassesLastName = model.MoassesLastName,
                MoassesNationalCode = model.MoassesNationalCode,
                ShiftId = model.ShiftId,
                CategoryItems = cis,
                Category = catName,
                Site = new Site
                {
                    Id = ecGeneratedId,
                    Name = model.EducationalCenterName,
                    CreatedBy = userId
                }

            };

            db.Set<EducationalCenter>().Add(educationalCenter);
            db.SaveChanges();

            var sur = new SiteUserRole
            {
                User=new User
                {
                    Person = new Person
                    {
                        FirstName = model.MoassesFirstName,
                        LastName = model.MoassesLastName,
                        BirthDate = DateTime.Now,
                        SexId = 1,
                        BirthDateJalali = "1346",
                        NationalCode = model.MoassesNationalCode,
                        CreatedBy = WebUserInfo.UserId.ToString(),
                        CreatedDate = DateTime.Now
                    },
                    UserName = ecGeneratedId.ToString(),
                    Password = model.MoassesNationalCode,
                    Status = true,
                    CreatedBy = WebUserInfo.UserId.ToString(),
                    CreatedDate = DateTime.Now,
                },
                RoleId = 4,
                SiteId = ecGeneratedId,
                CreatedDate = DateTime.Now,
                CreatedBy = userId
            };
            db.Set<SiteUserRole>().Add(sur);

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditEducationalCenter(int id)
        {
            {
                var educationalCenterDto = new EducationalCenterDefinitionDto
                {
                    Sexes = db.Set<Sex>().ToList().Select(s => new SelectListItem
                    {
                        Text = s.Title,
                        Value = s.Id.ToString()
                    }),
                    Shifts = db.Set<Shift>().ToList().Select(s => new SelectListItem
                    {
                        Text = s.Name,
                        Value = s.Id.ToString()
                    })
                };

                var educationalCenter = db.Set<EducationalCenter>().Include("Site").Include("CategoryItems").FirstOrDefault(ec => ec.Id == id);
                if (educationalCenter == null)
                {
                    return HttpNotFound();
                }
                educationalCenterDto.Id = educationalCenter.Id;
                educationalCenterDto.MoassesFirstName = educationalCenter.MoassesFirstName;
                educationalCenterDto.MoassesLastName = educationalCenter.MoassesLastName;
                educationalCenterDto.MoassesNationalCode = educationalCenter.MoassesNationalCode;
                educationalCenterDto.MoassesMobileNo = educationalCenter.MoassesMobileNo;
                educationalCenterDto.SexId = educationalCenter.SexId;
                educationalCenterDto.ShiftId = educationalCenter.ShiftId;
                educationalCenterDto.EducationalCenterName = educationalCenter.Site.Name;
                educationalCenterDto.CertificateCode = educationalCenter.CertificateCode;
                educationalCenterDto.PhoneNo1 = educationalCenter.Site.PhoneNo1;
                educationalCenterDto.PhoneNo2 = educationalCenter.Site.PhoneNo2;
                educationalCenterDto.Address = educationalCenter.Site.Address;
                educationalCenterDto.Category = educationalCenter.Category;
                educationalCenterDto.CategoryItemsIds = educationalCenter.CategoryItems.ToList().Select(ci => ci.Id).ToArray();

                return View(educationalCenterDto);
            }
        }


        [HttpPost]
        public ActionResult EditEducationalCenter(EducationalCenterDefinitionDto model)
        {
            int ecId = model.Id;
            var educationalCenter = db.Set<EducationalCenter>().Include("CategoryItems").First(ec => ec.Id == ecId);

            var xs = educationalCenter.CategoryItems.ToList();
            foreach (var x in xs)
            {
                educationalCenter.CategoryItems.Remove(x);
            }

            var cis = db.Set<CategoryItem>().Include("Category").Where(c => model.CategoryItemsIds.Contains(c.Id)).ToList();
            educationalCenter.CategoryItems = cis;

            db.Entry(educationalCenter).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}



































