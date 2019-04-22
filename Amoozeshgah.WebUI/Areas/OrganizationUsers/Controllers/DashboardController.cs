using Amoozeshgah.Services;
using Amoozeshgah.Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Amoozeshgah.WebUI.Areas.OrganizationUsers.Controllers
{
    public class DashboardController : Controller
    {
        IUserWithDetailService userWithDetailService;
        IDashboardService dashboardService = null;
        public DashboardController(IDashboardService dashboardService, IUserWithDetailService userWithDetailService)
        {
            this.dashboardService = dashboardService;
            this.userWithDetailService = userWithDetailService;
        }
        public ActionResult Index()
        {
            var roleId = WebUserInfo.RoleId;
            var userId = WebUserInfo.UserId;
            ViewBag.person = userWithDetailService.FindPersonByUserId(userId);
            switch (roleId)
            {
                case 1:
                    return View("BranchUser");

                case 2:
                    return View("BranchTeacher");
                case 3:
                    return View("BranchStudent");

            }

            return View();
        }
        public ActionResult BranchUser()
        {
            return View();
        }
        public ActionResult BranchTeacher()
        {
            return View();
        }
        public ActionResult BranchStudent()
        {
            return View();
        }
    }
}