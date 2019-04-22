﻿
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

using Amoozeshgah.ViewModel;
using Amoozeshgah.Common.Domain;
using Amoozeshgah.Services;
using Amoozeshgah.WebUI.Filters;
using Amoozeshgah.Domain.Entities;

namespace Amoozeshgah.WebUI.Areas.SiteUsers.Controllers
{
    public class FieldsController : Controller
    {
        IFieldService fieldService;
        IDepartmentService departmentService;
        public FieldsController(IFieldService fieldService, IDepartmentService departmentService)
        {
            this.fieldService = fieldService;
            this.departmentService = departmentService;
        }
        public ActionResult Index()
        {
            return View(new FieldDto());
        }
        public JsonResult GetAll()
        {
            var fileds = fieldService.GetFieldsDto();
            return Json(new { data = fileds }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet, AjaxOnly]
        public ActionResult Add()
        {
            var fieldDto = new FieldDto
            {
                Departments = new SelectList(departmentService.GetDepartments(), "Id", "Name"),
            };
            return View(fieldDto);
        }

        [HttpPost]
        public ActionResult Add(FieldDto model)
        {
            try
            {
                fieldService.CreateNewFieldDto(model);
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

        [HttpGet]
        public ActionResult Update(int id = 0)
        {
            var fieldDto = fieldService.GetFieldDtoById(id);

            if (fieldDto == null)
            {
                return new HttpNotFoundResult("Not Found!");
            }

            fieldDto.Departments = new SelectList(departmentService.GetDepartments(), "Id", "Name", fieldDto.Id);
            return View(fieldDto);
        }
        [HttpPost]
        public ActionResult Update(FieldDto model)
        {
            try
            {
                fieldService.UpdateFieldDto(model);
                var successMessage = $"رشته {model.Name} با موفقیت ثبت شد";
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
