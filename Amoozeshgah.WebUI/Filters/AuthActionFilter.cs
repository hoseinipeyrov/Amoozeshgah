using Amoozeshgah.Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Web.Routing;

namespace Amoozeshgah.WebUI.Filters
{
    public class AuthActionFilter : ActionFilterAttribute, IAuthenticationFilter
    {
        public int[] UserTypeId { get; set; }
        public int CurrentUserTypeId { get; set; }

        public void OnAuthentication(AuthenticationContext filterContext)
        {
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            var user = filterContext.HttpContext.User;
            if (user == null || !user.Identity.IsAuthenticated)
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {


            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                
                var identity = Thread.CurrentPrincipal as ClaimsPrincipal;
                CurrentUserTypeId = WebUserInfo.RoleId;
            }

            try
            {
                bool flag = false;
                for (int i = 0; i < UserTypeId.Length; i++)
                {
                    if (UserTypeId[i] == CurrentUserTypeId)
                    {
                        flag = true;
                        break;
                    }
                }
                if (flag)
                {
                    filterContext.Controller.TempData.Add("RedirectReason", "امکان دسترسی وجود ندارد");
                    filterContext.Result = new HttpUnauthorizedResult();
                }
                base.OnActionExecuting(filterContext);
            }
            catch
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }

        }
    }
}