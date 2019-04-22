using Amoozeshgah.Services;
using Amoozeshgah.Common.Domain;
using Amoozeshgah.WebUI.Filters;
using System.Web.Mvc;

namespace Amoozeshgah.WebUI.Areas.SiteUsers.Controllers
{
    public class MenusController : Controller
    {
        IUserWithDetailService userWithDetailService = null;
        public MenusController(IUserWithDetailService userWithDetailService)
        {
            this.userWithDetailService = userWithDetailService;
        }

        [AllowAnonymous]
        [AuthenticationFilter]
        public ActionResult Sidebar(string controller, string action)
        {
            var sidebar = userWithDetailService.GetSidebar(WebUserInfo.RoleId, controller, action);
            return PartialView("_Sidebar", sidebar);
        }
    }
}