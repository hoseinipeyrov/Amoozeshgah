using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Amoozeshgah.Common.DateConverter;
using Amoozeshgah.Common.Domain;
using Amoozeshgah.Core.Infrastructure;
using Amoozeshgah.Domain.Entities;
using Amoozeshgah.ViewModel;

namespace Amoozeshgah.WebUI.Areas.StudentArea.Controllers
{
    public class MyRequestsController : Controller
    {
        private readonly AppContext _db;

        public MyRequestsController()
        {
            _db = new AppContext();
        }
        [HttpGet]
        public ActionResult Index()
        {
            var studentId = WebUserInfo.UserId;
            var student = _db.Set<Student>().Include("LanguageDeterminationLevelRequests.EducationalCenter.Site").FirstOrDefault(s => s.Id == studentId);
            if (student == null)
            {
                return Redirect("/account/StudentSignIn");
            }

            return View(student);
        }

        [HttpGet]
        public ActionResult LanguageDeterminationLevel()
        {
            var studentId = WebUserInfo.UserId;
            var last30Days = DateTime.Now.AddDays(-30);
            var requestCounts = _db.Set<Student>()
                .Include("LanguageDeterminationLevelRequests")
                .First(s => s.Id == studentId)
                .LanguageDeterminationLevelRequests.Count(l => l.CreatedDate >= last30Days);
            if (requestCounts >= 5)
            {
                return View("RunOutOfLanguageDeterminationLevelRequest");
            }
            return View();
        }

        [HttpPost]
        public ActionResult LanguageDeterminationLevel(DeterminationLevelRequestDto model)
        {


            var studentId = WebUserInfo.UserId;
            var last30Days = DateTime.Now.AddDays(-30);

            var requestCounts = _db.Set<Student>()
                .Include("LanguageDeterminationLevelRequests")
                .First(s => s.Id == studentId)
                .LanguageDeterminationLevelRequests.Count(l => l.CreatedDate >= last30Days);

            if (requestCounts >= 5)
            {
                return Json(new { success = false, message = "امکان درخواست ماهانه به اتمام رسیده است" }, JsonRequestBehavior.AllowGet);
            }


            var educationalCenter =
                _db.Set<EducationalCenter>().FirstOrDefault(ec => ec.Id == model.EducationalCenterCode);
            if (educationalCenter == null)
            {
                return Json(new { success = false, message = "کد مرکز آموزشی نامعتبر است" }, JsonRequestBehavior.AllowGet);
            }

            if (educationalCenter.Category != "مرکز زبان خارجه")
            {
                return Json(new { success = false, message = "کد انتخابی یک مرکز زبان خارجه نمی باشد" }, JsonRequestBehavior.AllowGet);

            }



            var time = model.PreferHour.Split(':');
            var preferDate = model.PreferDay.ToGeorgianDateTimeFromJalali(Convert.ToDouble(time[0]), Convert.ToDouble(time[1]));

            var ldlr = new LanguageDeterminationLevelRequest
            {
                StudentId = studentId,
                EducationalCenterId = educationalCenter.Id,
                PreferJalaliDay = model.PreferDay,
                PreferJalaliHour = model.PreferHour,
                PreferJalaliDayName = model.PreferDay.ToJalaliDateName(),
                PreferDate = preferDate

            };


            _db.Set<LanguageDeterminationLevelRequest>().Add(ldlr);
            _db.SaveChanges();
            return Json(new { success = true, message = "ثبت موفق" }, JsonRequestBehavior.AllowGet);
        }


       
        [HttpGet]
        public ActionResult RefundRequest()
        {
            var StudentId = WebUserInfo.UserId;
            var courses = _db.Set<Student>().Include("CoursesJoinStudents.Course.Term").First(s => s.Id == StudentId).CoursesJoinStudents.ToList();
            var refundRequest = new RefundRequestDto
            {
                Courses = courses.Select(c => new SelectListItem
                {
                    Text = $@"{c.Course.Name} ({c.Course.Term.Name})",
                    Value = c.Course.Id.ToString()
                })
            };
            return View(refundRequest);
        }





    }
}