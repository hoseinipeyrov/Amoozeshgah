using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Amoozeshgah.WebUI.Areas.StudentArea.Controllers
{
    public class StudentDashboardController : Controller
    {
        // GET: StudentArea/Dashboard
        public ActionResult Index()
        {
            return View();
        }
    }
}