using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Web;
using Microsoft.AspNet.Identity;

namespace Amoozeshgah.Common.Domain
{
    public class WebUserInfo
    {
        public static int RoleId
        {
            get
            {
                return Convert.ToInt32((Thread.CurrentPrincipal as ClaimsPrincipal).FindFirst("RoleId").Value);
            }
        }
        public static int UserId
        {
            get
            {
                return Convert.ToInt32((Thread.CurrentPrincipal as ClaimsPrincipal).FindFirst("UserId").Value);
            }
        }
        public static string Username
        {
            get
            {
               // return HttpContext.Current.User.Identity.Name;
                return (Thread.CurrentPrincipal as ClaimsPrincipal).FindFirst("Name").Value.ToString();
            }
        }
        public static int SiteId
        {
            get
            {
                return Convert.ToInt32((Thread.CurrentPrincipal as ClaimsPrincipal).FindFirst("SiteId").Value);
            }
        }
        public static int OrganizationId
        {
            get
            {
                return Convert.ToInt32((Thread.CurrentPrincipal as ClaimsPrincipal).FindFirst("OrganizationId").Value);
            }
        }
    }
}