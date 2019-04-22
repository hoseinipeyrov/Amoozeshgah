using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Amoozeshgah.WebUI.Areas.TeacherArea.Controllers
{
    public class DashboardController : Controller
    {
        // GET: TeacherArea/Dashboard
        public ActionResult Index()
        {
            return View();
        }
    }
}