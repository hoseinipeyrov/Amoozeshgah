using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Amoozeshgah.WebUI.Filters
{
    public class CustomExceptionHandler : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            if (filterContext.ExceptionHandled || filterContext.HttpContext.IsCustomErrorEnabled)
            {
                return;
            }
            Exception e = filterContext.Exception;
            filterContext.ExceptionHandled = true;
            var data = new ViewDataDictionary
         {
             new KeyValuePair<string, object>("RedirectReason", e.Message),
         };
            
            filterContext.Result = new ViewResult()
            {
                ViewName = "Error",
                
                ViewData= data
            };
        }
    }
}