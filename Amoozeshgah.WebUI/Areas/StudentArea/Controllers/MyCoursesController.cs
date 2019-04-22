using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Amoozeshgah.Common.Domain;
using Amoozeshgah.Core.Infrastructure;
using Amoozeshgah.Domain.Entities;
using Amoozeshgah.ViewModel;

namespace Amoozeshgah.WebUI.Areas.StudentArea.Controllers
{
    public class MyCoursesController : Controller
    {
        private readonly AppContext _db=new AppContext();
        public ActionResult Index()
        {
            var studentId = WebUserInfo.UserId;
            var student = _db.Set<Student>()
                .Include(s => s.User.Person)
                .Include("CoursesJoinStudents.Course.Lesson.Field.Department.DepartmentType.EducationalCenter.Site")
                .First(s => s.Id == studentId);
            var courses = student
                .CoursesJoinStudents
                .ToList()
                .Select(cjs=>new MyCoursesDto
                {
                    CourseName = cjs.Course.Name,
                    CourseCode = cjs.Course.Code,
                    CourseDescription = "",
                    CourseStartDate = cjs.Course.StartDateJalali,
                    EducationalCenterName = cjs.Course.Lesson.Field.Department.DepartmentType.EducationalCenter.Site.Name,
                    LessonName = cjs.Course.Lesson.Name,
                    FieldName = cjs.Course.Lesson.Field.Name
                });
            return View(courses);
        }
    }
}