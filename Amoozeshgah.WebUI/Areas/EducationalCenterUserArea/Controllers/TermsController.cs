using Amoozeshgah.Common.DateConverter;
using Amoozeshgah.Services;
using Amoozeshgah.ViewModel;
using Amoozeshgah.WebUI.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Amoozeshgah.WebUI.Areas.EducationalCenterUserArea.Controllers
{
    public class TermsController : Controller
    {
        ITermService termService;

        public TermsController(ITermService termService)
        {
            this.termService = termService;
        }

        public ActionResult Index()
        {
            return View(new TermDto());
        }
        [AjaxOnly]
        public JsonResult GetAll()
        {

            var terms = termService.GetTermsDto();
            return Json(new { data = terms }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Add()
        {

            return View(new TermDto());
        }

        [HttpPost]
        public ActionResult Add(TermDto model)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Select(x => x.Value.Errors)
              .Where(y => y.Count > 0)
              .ToList();

                string failMessage = "" ;
                foreach (var error in errors)
                {
                    failMessage += error.First().ErrorMessage+"     ";
                }
                return Json(new { success = false, message = failMessage }, JsonRequestBehavior.AllowGet);

            }

            try
            {
                termService.InsertTermDto(model);
                var successMessage = $"رشته {model.Name} با موفقیت ثبت شد";
                return Json(new { success = true, message = successMessage }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                var failMessage = "خطایی در ذخیره رخ داد، لطفا ورود داده را بررسی نمایید";
                failMessage += $" {ex.Message}";
                return Json(new { success = false, message = failMessage }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Delete(int Id = 0)
        {
            try
            {
                termService.DeleteTermById(Id);
                var successMessage = $"با موفقیت حذف شد";
                return Json(new { success = true, message = successMessage }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                var failMessage = "خطایی در ذخیره رخ داد، ";
                failMessage += $"{ex.Message}";
                return Json(new { success = false, message = failMessage }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}