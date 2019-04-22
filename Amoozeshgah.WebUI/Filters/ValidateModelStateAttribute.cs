using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Amoozeshgah.WebUI.Filters
{
    public class ValidateModelStateAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var viewData = context.Controller.ViewData;

            if (!viewData.ModelState.IsValid)
                context.Result = new ViewResult
                {
                    ViewData = viewData,
                    TempData = context.Controller.TempData
                };
        }
    }
}