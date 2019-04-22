using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Amoozeshgah.Common.DateConverter;
using Amoozeshgah.Common.Domain;
using Amoozeshgah.Core.Infrastructure;
using Amoozeshgah.Domain.Entities;
using Amoozeshgah.ViewModel;

namespace Amoozeshgah.WebUI.Areas.AdministratorArea.Controllers
{
    public class ManageMaximumTuitionsController : Controller
    {
        private readonly AppContext _db;

        public ManageMaximumTuitionsController()
        {
            _db = new AppContext();
        }

        [HttpGet]
        public ActionResult Index()
        {

            return View();
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var provinceId = WebUserInfo.SiteId;

            var tuitions = _db.Set<MaximumTuition>().Include(mt => mt.Area.Site)
                .Where(mt => mt.Area.ProvinceId == provinceId)
                .OrderByDescending(mt => mt.CreatedDate).ToList().Select(mt => new
                {
                    Area = mt.Area.Site.Name,
                    FromJalali = mt.FromJalali,
                    ToJalali = mt.ToJalali,
                    Id = mt.Id
                });
            return Json(new { data = tuitions }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult MaximumTutionDetails(int id)
        {
            var provinceId = WebUserInfo.SiteId;

            var tuition = _db.Set<MaximumTuition>().Include(mt => mt.Area.Site)
                .FirstOrDefault(mt => mt.Area.ProvinceId == provinceId && mt.Id == id);
            if (tuition == null)
            {
                return Json("داده ای برای نمایش وجود ندارد", JsonRequestBehavior.AllowGet);
            }

            var detail =
                $@"<div class='col=md-6'>" +
                $@"<p>علمی ابتدایی : <strong>{tuition.ScienceElementry}</strong> ریال</p>" +
                $@"<p>علمی متوسطه اول : <strong>{tuition.ScienceFirstMiddle}</strong> ریال</p>" +
                $@"<p>علمی متوسطه دوم : <strong>{tuition.ScienceSecondMiddle}</strong> ریال</p>" +
                $@"</div>" +
                $@"<div class='col=md-6'>" +

                $@"<p>زبان مقدماتی : <strong>{tuition.LanguageElementary}</strong> ریال</p>" +
                $@"<p>زبان میانی : <strong>{tuition.LanguageMiddle}</strong> ریال</p>" +
                $@"<p>زبان پیشرفته : <strong>{tuition.LanguageAdvanced}</strong> ریال</p>" +
                $@"<p>آزمون : <strong>{tuition.Exam}</strong> ریال</p>" +
                $@"</div>";
            return Json(detail, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public ActionResult SetMaximumTuition()
        {
            var provinceId = WebUserInfo.SiteId;
            var areas = _db.Set<Province>().Include("Areas.Site").First(p => p.Id == provinceId).Areas;

            return View(new MaximumTuitionDto
            {
                Areas = areas.Select(a => new SelectListItem
                {
                    Text = a.Site.Name,
                    Value = a.Id.ToString()
                })
            });
        }

        [HttpPost]
        public ActionResult SetMaximumTuition(MaximumTuitionDto model)
        {
            var provinceId = WebUserInfo.SiteId;
            var areaId = model.AreaId;
            var area = _db.Set<Area>().FirstOrDefault(a => a.Id == areaId && a.ProvinceId == provinceId);

            if (area == null)
            {
                return Json(new { success = false, message = "ناحیه یافت نشد" }, JsonRequestBehavior.AllowGet);
            }

            try
            {
                area.MaximumTuitions.Add(new MaximumTuition
                {
                    CreatedBy = WebUserInfo.UserId.ToString(),
                    From = model.FromJalali.ToGeorgianDateTime(),
                    FromJalali = model.FromJalali,
                    To = model.ToJalali.ToGeorgianDateTime(),
                    ToJalali = model.ToJalali,
                    ScienceElementry = model.ScienceElementry.Value,
                    ScienceFirstMiddle = model.ScienceFirstMiddle.Value,
                    ScienceSecondMiddle = model.ScienceSecondMiddle.Value,
                    LanguageElementary = model.LanguageElementary.Value,
                    LanguageMiddle = model.LanguageMiddle.Value,
                    LanguageAdvanced = model.LanguageAdvanced.Value,
                    Exam = model.Exam.Value
                });
            }
            catch
            {
                return Json(new { success = false, message = "لطفا مقادیر را به درستی وارد نمایید" }, JsonRequestBehavior.AllowGet);
            }



            _db.SaveChanges();

            return Json(new { success = true, message = "قوانین مرکز آموزشی ذخیره شد" }, JsonRequestBehavior.AllowGet);
        }
    }
}