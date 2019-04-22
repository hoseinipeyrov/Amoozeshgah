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

namespace Amoozeshgah.WebUI.Areas.EducationalCenterUserArea.Controllers
{
    public class SessionScheduleController : Controller
    {
        private readonly AppContext _db;

        public SessionScheduleController()
        {
            _db = new AppContext();
        }
        public ActionResult Index(int id)
        {

            var s = _db.Set<SessionSchedule>().Include(ss => ss.Course).Include(ss => ss.Classroom).Where(ss => ss.CourseId == id).ToList();
            ViewBag.CourseId = id;
           var course = _db.Set<Course>().First(c => c.Id == id);
            ViewBag.CourseName ="جلسات درس "+ course.Name + " کد " + course.Code;
            return View(s);
            //var course = _db.Set<Course>()
            //    .Include("Lesson.Field.Department.DepartmentType")
            //    .FirstOrDefault(c => c.Id == id &&
            //                         c.Lesson.Field.Department.DepartmentType.EducationalCenterId ==
            //                         WebUserInfo.SiteId);
            //if (course !=null )
            //{
            //    ViewBag.CourseId = id;
            //    return View(course.Sessions);

            //}

        }
        [HttpGet]
        public ActionResult AddNewSession(int id)
        {

            return View(new AddSessionScheduleDto
            {
                CourseId = id,
                Classrooms = _db.Set<Classroom>().Where(cr => cr.EducationalCenterId == WebUserInfo.SiteId).ToList().Select(cr => new SelectListItem
                {
                    Text = $"{cr.Name}({cr.Code})",
                    Value = cr.Id.ToString()
                })
            });
        }

        [HttpPost]
        public ActionResult AddNewSession(AddSessionScheduleDto model)
        {
            var time = model.StartHour.Split(':');
            var startDateTime = model.StartDayJalali.ToGeorgianDateTimeFromJalali(Convert.ToDouble(time[0]), Convert.ToDouble(time[1]));

            var sessionSchedule = new SessionSchedule
            {
                CourseId = model.CourseId,
                ClassroomId = model.ClassroomId,
                StartDateTime = startDateTime,
                StartDayJalali = model.StartDayJalali,
                StartTimeJalali = model.StartHour,
                StartDayTimeJalali = model.StartDayJalali + " " + model.StartHour,
                StartDayName = model.StartDayJalali.ToJalaliDateName()
            };

            _db.Set<SessionSchedule>().Add(sessionSchedule);

            _db.SaveChanges();


            return RedirectToAction("Index", new { id = model.CourseId });
        }

        [HttpGet]

        public ActionResult DeleteSession(int id)
        {
            var sessionToDelete = _db.Set<SessionSchedule>().Find(id);
            var courseId = sessionToDelete.CourseId;
            _db.Entry(sessionToDelete).State = EntityState.Deleted;
            _db.SaveChanges();

            return RedirectToAction("Index", new { id = courseId });
        }
    }
}