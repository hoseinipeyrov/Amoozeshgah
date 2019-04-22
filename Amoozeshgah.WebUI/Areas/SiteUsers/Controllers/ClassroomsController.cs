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

namespace Amoozeshgah.WebUI.Areas.SiteUsers.Controllers
{
    public class ClassroomsController : Controller
    {

        IClassroomService classroomService;
        IClassroomTypeService classroomTypeService;
        public ClassroomsController(IClassroomService classroomService, IClassroomTypeService classroomTypeService)
        {
            this.classroomService = classroomService;
            this.classroomTypeService = classroomTypeService;
        }
        public ActionResult Index()
        {
            return View(new ClassroomDto());
        }
        public JsonResult GetAll()
        {
            var classrooms = classroomService.GetClassroomsDto();
            return Json(new { data = classrooms }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Add()
        {
            var classroomDto = new ClassroomDto
            {
                ClassroomTypes = new SelectList(classroomTypeService.GetClassroomTypes(), "Id", "Type"),
            };
            return View(classroomDto);
        }

        [HttpPost]
        public ActionResult Add(ClassroomDto model)
        {
            try
            {
                classroomService.CreateNewClassroomDto(model);
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
            var classroomDto = classroomService.GetClassroomDtoById(id);
            if (classroomDto == null)
            {
                return new HttpNotFoundResult("Not Found!");
            }

            classroomDto.ClassroomTypes = new SelectList(classroomTypeService.GetClassroomTypes(), "Id", "Type",classroomDto.ClassroomTypeId);
            return View(classroomDto);
        }
        [HttpPost]
        public ActionResult Update(ClassroomDto model)
        {
            try
            {
                classroomService.UpdateClassroomDto(model);
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
                var deletedField = classroomService.DeleteClassroomById(Id);
                var successMessage = $"{deletedField.Name} با موفقیت حذف شد";
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
