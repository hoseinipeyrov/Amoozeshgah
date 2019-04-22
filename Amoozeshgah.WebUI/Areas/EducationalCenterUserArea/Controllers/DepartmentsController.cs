using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Amoozeshgah.ViewModel;
using Amoozeshgah.Services;
using Amoozeshgah.WebUI.Filters;
using Amoozeshgah.Common.Domain;

namespace Amoozeshgah.WebUI.Areas.EducationalCenterUserArea.Controllers
{
    //[AuthenticationFilter]
    public class DepartmentsController : Controller
    {
        IDepartmentService departmentService;
        IDepartmentTypeService departmentTypeService;

        public DepartmentsController(IDepartmentService departmentService, IDepartmentTypeService departmentTypeService)
        {
            this.departmentService = departmentService;
            this.departmentTypeService = departmentTypeService;
        }
        public ActionResult Index()
        {
            return View(new DepartmentDto());
        }
        public JsonResult GetAll()
        {
            var departmentsDto = departmentService.GetDepartmentsDto();
            return Json(new { response = departmentsDto }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var departmentDto = new DepartmentDto
            {
                //Languages = new SelectList(languageService.GetLanguages(WebUserInfo.UserBranchId), "Id", "Name"),

                DepartmentTypes = new SelectList(departmentTypeService.GetDepartmentTypes(), "Id", "Name"),
            };
            return View(departmentDto);
        }
        [HttpPost]
        public ActionResult Add(DepartmentDto model)
        {
            try
            {
                model.SiteId = WebUserInfo.SiteId;
                departmentService.InsertDepartmentDto(model);
                var successMessage = $"دپارتمان {model.Name} با موفقیت ثبت شد";
                return Json(new { success = true, message = successMessage }, JsonRequestBehavior.AllowGet);
            }
            catch
            {

                var failMessage = "خطایی در ذخیره رخ داد، لطفا ورود داده را بررسی نمایید";
                return Json(new { success = false, message = failMessage }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet, AjaxOnly]
        public ActionResult Update(int id = 0)
        {
            var departmentDto = departmentService.GetDepartmentDtoById(id);

            if (departmentDto == null)
            {
                return new HttpNotFoundResult("Not Found!");
            }

            departmentDto.DepartmentTypes = new SelectList(departmentTypeService.GetDepartmentTypes(), "Id", "Name", departmentDto.Id);
            return View(departmentDto);
        }
        [HttpPost]
        public ActionResult Update(DepartmentDto model)
        {
            try
            {
                model.SiteId = WebUserInfo.SiteId;
                departmentService.UpdateDepartmentDto(model);
                var successMessage = $"دپارتمان {model.Name} با موفقیت ثبت شد";
                return Json(new { success = true, message = successMessage }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                var failMessage = "خطایی در ذخیره رخ داد، لطفا ورود داده را بررسی نمایید";
                failMessage += $".<br /> code {ex.Message}";
                return Json(new { success = false, message = failMessage }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public ActionResult Delete(int Id = 0)
        {
            try
            {
                var deletedDepartment = departmentService.DeleteDepartmentById(Id);
                var successMessage = $"{deletedDepartment.Name} با موفقیت حذف شد";
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
