using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Amoozeshgah.WebUI.Areas.StudentArea.Controllers
{
    public class AccountController : Controller
    {
        // GET: StudentArea/Account
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult StudentRegister()
        {

            return View();
        }
    }
}