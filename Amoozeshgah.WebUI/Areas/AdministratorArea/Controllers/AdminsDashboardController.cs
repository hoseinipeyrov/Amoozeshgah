using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Amoozeshgah.WebUI.Areas.AdministratorArea.Controllers
{
    public class AdminsDashboardController : Controller
    {
        // GET: AdministratorArea/AdminsDashboard
        public ActionResult ProvinceUser()
        {
            return View();
        }
        public ActionResult AreaUser()
        {
            return View();
        }

        
    }
}