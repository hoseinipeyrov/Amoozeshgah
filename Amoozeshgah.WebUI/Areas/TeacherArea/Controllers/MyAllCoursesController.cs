using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Amoozeshgah.Common.Domain;
using Amoozeshgah.Core.Infrastructure;
using Amoozeshgah.Domain.Entities;

namespace Amoozeshgah.WebUI.Areas.TeacherArea.Controllers
{
    public class MyAllCoursesController: Controller
    {
        private readonly AppContext _db;

        public MyAllCoursesController()
        {
            _db=new AppContext();
        }
        public ActionResult Index()
        {
            var teacherId = WebUserInfo.UserId;
            var courses = _db.Set<Teacher>().Include(t=>t.Courses).First(t => t.Id == teacherId).Courses;
           
            return View(courses);

        }
    }
}