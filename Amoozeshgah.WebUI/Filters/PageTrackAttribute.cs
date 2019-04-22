using Amoozeshgah.Core.Infrastructure;
using Amoozeshgah.Domain.Entities;
using System;
using System.Web.Mvc;

namespace Amoozeshgah.WebUI.Filters
{
    public class PageTrackAttribute : ActionFilterAttribute
    {
        //IAuditService auditService;
        //public AuditAttribute(IAuditService auditService)
        //{
        //    this.auditService = auditService;
        //}
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // Stores the Request in an Accessible object
            var request = filterContext.HttpContext.Request;
            // Generate an audit
            PageTrack pageTrack = new PageTrack()
            {
                // Username (if available)
                Username = (request.IsAuthenticated) ? filterContext.HttpContext.User.Identity.Name : "Anonymous",
                // IP Address of the Request
                IPAddress = request.ServerVariables["HTTP_X_FORWARDED_FOR"] ?? request.UserHostAddress,
                // The URL that was accessed
                AreaAccessed = request.RawUrl,
                // Timestamp
                TimeAccessed = DateTime.Now,              
            };

            // Stores the Audit in the Database
            //auditService.InserAudit(audit);
            var context = new AppContext();
            context.PageTracks.Add(pageTrack);

            // context.Set(Audit).Add(audit);
            context.SaveChanges();
            // Finishes executing the Action as normal 
            base.OnActionExecuting(filterContext);
        }
    }
}