using Amoozeshgah.Services;
using Amoozeshgah.ViewModel;
using Amoozeshgah.WebUI.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Amoozeshgah.WebUI.Areas.SiteUsers.Controllers
{
    [AuthenticationFilter]
    public class DepartmentTypesController : Controller
    {
        IDepartmentTypeService departmentTypeService ;

        public DepartmentTypesController(IDepartmentTypeService departmentTypeService)
        {
            this.departmentTypeService = departmentTypeService;
        }
        public ActionResult Index()
        {
            return View(new DepartmentTypeDto());
        }
        [AjaxOnly]
        public JsonResult GetAll()
        {

            var departmentTypes = departmentTypeService.GetDepartmentTypesDto();
            return Json(new { data = departmentTypes }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet, AjaxOnly]
        public ActionResult Add()
        {
            return View(new DepartmentTypeDto());
        }
        [HttpPost]
        public ActionResult Add(DepartmentTypeDto model)
        {
            try
            {
                departmentTypeService.CreateNewDepartmentTypeDto(model);

                var successMessage = $"نوع دپارتمان {model.NameFa} با موفقیت ثبت شد";
                return Json(new { success = true, message = successMessage }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                var failMessage = "خطایی در ذخیره رخ داد، لطفا ورود داده را بررسی نمایید";
                failMessage += $" {ex.Message}";
                return Json(new { success = false, message = failMessage }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet, AjaxOnly]
        public ActionResult Update(int id=0)
        {
            var departmentType = departmentTypeService.GetDepartmentTypeDtoById(id);
            if (departmentType==null)
            {
                return new HttpNotFoundResult("Not Found!");
            }
            return View(departmentType);
        }
        [HttpPost]
        public ActionResult Update(DepartmentTypeDto model)
        {
            try
            {
                departmentTypeService.UpdateDepartmentTypeDto(model);
                var successMessage = $"دپارتمان {model.NameFa} با موفقیت ثبت شد";
                return Json(new { success = true, message = successMessage }, JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {

                var failMessage = "خطایی در ذخیره رخ داد، لطفا ورود داده را بررسی نمایید";
                failMessage += $".<br /> code {ex.Message}";
                return Json(new { success = false, message = failMessage }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public ActionResult Delete(int Id=0)
        {
            try
            {
               var deletedDepartmentType= departmentTypeService.DeleteDepartmentTypeById(Id);
                var successMessage = $"{deletedDepartmentType.NameFa} با موفقیت حذف شد";
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