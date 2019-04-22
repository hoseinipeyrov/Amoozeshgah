using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Amoozeshgah.WebUI.Areas.StudentArea.Controllers
{
    public class LessonsController : Controller
    {

        public ActionResult ChooseNewLessonMessage()
        {
            return View();
        }
        public ActionResult ChooseNewLesson()
        {
            return View();
        }
    }
}