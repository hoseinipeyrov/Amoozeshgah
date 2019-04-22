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
using Microsoft.Ajax.Utilities;

namespace Amoozeshgah.WebUI.Areas.EducationalCenterUserArea.Controllers
{
    public class ReceivedRequestsController : Controller
    {
        private readonly AppContext _db;

        public ReceivedRequestsController()
        {
            _db = new AppContext();
        }
        public ActionResult Index()
        {
            var educationalCenterId = WebUserInfo.SiteId;
            var educationalCenter = _db.Set<EducationalCenter>()
                .Include("LanguageDeterminationLevelRequests.Student.User.Person").First(ec => ec.Id == educationalCenterId);
            if (educationalCenter.Category != "مرکز زبان خارجه")
            {
                return View("OnlyLanguageEducationalCentersPermitted");
            }
            return View();
        }

        public ActionResult GetAll()
        {
            var educationalCenterId = WebUserInfo.SiteId;
            var educationalCenter = _db.Set<EducationalCenter>()
                .Include("LanguageDeterminationLevelRequests.Student.User.Person").First(ec => ec.Id == educationalCenterId);

            var requests = educationalCenter.LanguageDeterminationLevelRequests.ToList().Select(ldlr => new
            {
                Id = ldlr.Id,
                FullName = ldlr.Student.User.Person.FirstName + " " + ldlr.Student.User.Person.LastName,
                PreferJalaliDate = ldlr.PreferJalaliHour + " " + ldlr.PreferJalaliDay,
                Status = ((ldlr.SetJalaliDay.IsNullOrWhiteSpace()) ? "<span><i class='fa fa-spinner fa-spin'></i></span>" : "<span class='text-success'><i class='fa fa-check-circle-o'></i></span>"),
                SetJalaliDate = ((ldlr.SetJalaliDay.IsNullOrWhiteSpace()) ? "-" : ldlr.SetJalaliHour + " " + ldlr.SetJalaliDay),

            });

            return Json(new { data = requests }, JsonRequestBehavior.AllowGet);

        }
        [HttpGet]
        public ActionResult SetTime(int id)
        {
            var ecId = WebUserInfo.SiteId;
            var req = _db.Set<LanguageDeterminationLevelRequest>()
                .Include("Student.User.Person")
                .FirstOrDefault(ldlr => ldlr.Id == id && ldlr.EducationalCenterId == ecId);
            if (req == null)
            {
                return View("NotFound");
            }

            var determinationLevelResponse = new DeterminationLevelResponseDto
            {
                Day = req.SetJalaliDay,
                Hour = req.SetJalaliHour,
                StudentFullName = req.Student.User.Person.FirstName + " " + req.Student.User.Person.LastName,
                PhoneNo = req.Student.User.Person.MobileNo,
                StudentPereferDate = req.PreferJalaliDayName + " " + req.PreferJalaliDay + " ساعت " + req.PreferJalaliHour,
                Id = id
            };
            return View(determinationLevelResponse);



        }

        [HttpPost]
        public ActionResult SetTime(DeterminationLevelResponseDto model)
        {
            var ecId = WebUserInfo.SiteId;
            var languageDeterminationLevelRequest = _db.Set<LanguageDeterminationLevelRequest>().Include("Student.User.Person").FirstOrDefault(ldlr => ldlr.Id == model.Id && ldlr.EducationalCenterId == ecId);
            if (languageDeterminationLevelRequest == null)
            {
                return Json("داده ای یافت نشد", JsonRequestBehavior.AllowGet);
            }

            languageDeterminationLevelRequest.SetJalaliDay = model.Day;
            languageDeterminationLevelRequest.SetJalaliHour = model.Hour;

            var time = model.Hour.Split(':');
            var setDate = model.Day.ToGeorgianDateTimeFromJalali(Convert.ToDouble(time[0]), Convert.ToDouble(time[1]));
            languageDeterminationLevelRequest.SetDate = setDate;
            languageDeterminationLevelRequest.Setter = WebUserInfo.UserId.ToString();
            languageDeterminationLevelRequest.SetJalaliDayName = model.Day.ToJalaliDateName();
            _db.Entry(languageDeterminationLevelRequest).State = EntityState.Modified;
            _db.SaveChanges();
            return Json(new { success = true, message = "ثبت موفق" }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult StudentRequestDetails(int id)
        {
            var ecId = WebUserInfo.SiteId;
            var languageDeterminationLevelRequest = _db.Set<LanguageDeterminationLevelRequest>().Include("Student.User.Person").FirstOrDefault(ldlr => ldlr.Id == id && ldlr.EducationalCenterId == ecId);
            if (languageDeterminationLevelRequest == null)
            {
                return Json("داده ای برای نمایش وجود ندارد", JsonRequestBehavior.AllowGet);
            }

            var detail = $@"<p> نام و نام خانوادگی: {languageDeterminationLevelRequest.Student.User.Person.FirstName} {languageDeterminationLevelRequest.Student.User.Person.LastName} </p>" +
                $"<p>زمان پیشنهاد شده: {languageDeterminationLevelRequest.PreferJalaliDayName} {languageDeterminationLevelRequest.PreferJalaliDay} ساعت: {languageDeterminationLevelRequest.PreferJalaliHour}</p>";
            return Json(detail, JsonRequestBehavior.AllowGet);

        }



        ////////////////////////////////////////////////////////////////////////

        public ActionResult StudentsDiscountRequests()
        {
            return View();
        }

        public ActionResult GetAllNotResponsed()
        {

            var educationalCenterId = WebUserInfo.SiteId;

            var discountRequests = _db.Set<DiscountRequest>()
                .Include("Student.User.Person")
                .Include("Course.Lesson.Field")
                .Where(dr =>
                dr.Course.Lesson.Field.Department.DepartmentType.EducationalCenterId == educationalCenterId &&
                    dr.IsResponsed != true
                    )
                .ToList()
                .Select(dr => new
                {
                    StudentFullName = dr.Student.User.Person.FirstName + " " + dr.Student.User.Person.LastName,
                    Field = dr.Course.Lesson.Field.Name,
                    Lesson = dr.Course.Lesson.Name,
                    CourseName = dr.Course.Name,
                    CourseCode = dr.Course.Code,
                    Id = dr.Id

                });



            return Json(new { data = discountRequests }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult GetAllResponsed()
        {

            var educationalCenterId = WebUserInfo.SiteId;

            var discountRequests = _db.Set<DiscountRequest>()
                .Include("Student.User.Person")
                .Include("Course.Lesson.Field")
                .Where(dr =>
                    dr.Course.Lesson.Field.Department.DepartmentType.EducationalCenterId == educationalCenterId &&
                    dr.IsResponsed == true
                )
                .ToList()
                .Select(dr => new
                {
                    StudentFullName = dr.Student.User.Person.FirstName + " " + dr.Student.User.Person.LastName,
                    Field = dr.Course.Lesson.Field.Name,
                    Lesson = dr.Course.Lesson.Name,
                    CourseName = dr.Course.Name,
                    CourseCode = dr.Course.Code

                });



            return Json(new { data = discountRequests }, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public ActionResult ResponseToDiscountRequest(int id = 0)
        {
            var discountRequestId = id;
            var educationalId = WebUserInfo.SiteId;

            var request = _db.Set<DiscountRequest>()
                .Include(dr => dr.Course.Lesson.Field.Department.DepartmentType)
                .Include(dr => dr.Student.User.Person)
                .FirstOrDefault(dr => dr.Id == discountRequestId &&
                                                                  dr.IsResponsed != true &&
                                                                  dr.Course.Lesson.Field.Department.DepartmentType
                                                                      .EducationalCenterId == educationalId);
            if (request == null)
            {
                return View("NotFound");
            }

            ViewBag.maxDiscount = (int)request.Course.Price * 96 / 100;

            return View(request);

        }

       

    }
}