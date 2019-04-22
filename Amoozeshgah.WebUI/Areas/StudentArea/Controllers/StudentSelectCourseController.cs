using Amoozeshgah.Core.Infrastructure;
using Amoozeshgah.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Data.Entity;

namespace Amoozeshgah.WebUI.Areas.StudentArea.Controllers
{
    public class StudentSelectCourseController : Controller
    {
        AppContext db = new AppContext();
        public ActionResult Index()
        {
            var coursess = db.Set<Course>().Include(c=>c.Teacher.User.Person).ToList();
            return View(coursess);
        }
    }
}