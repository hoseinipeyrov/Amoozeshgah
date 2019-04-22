using Amoozeshgah.Services;
using Amoozeshgah.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Amoozeshgah.WebUI.Areas.SiteUsers.Controllers
{
    public class TeachersController : Controller
    {
        ITeacherService teacherService;
        public TeachersController(ITeacherService teacherService)
        {
            this.teacherService = teacherService;
        }
        public ActionResult Index()
        {
            return View(new TeacherDto());
        }
        public JsonResult GetAll()
        {
            var teachers = teacherService.GetTeachersDto();
            return Json(new { data = teachers }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Add()
        {
            //var lessonDto = new TeacherDto
            //{
            //    Fields = new SelectList(teacherService.GetFields(), "Id", "Name"),
            //};
            return View(new TeacherDto());
        }

        [HttpPost]
        public ActionResult Add(TeacherDto model)
        {
            try
            {
                teacherService.CreateNewTeacherDto(model);
                var successMessage = $"معلم با کد {model.TeacherCode} با موفقیت ثبت شد";
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
            var teacherDto = teacherService.GetTeacherDtoById(id);
            if (teacherDto == null)
            {
                return new HttpNotFoundResult("Not Found!");
            }

          //  teacherDto.Fields = new SelectList(teacherService.GetFields(), "Id", "Name", teacherDto.FieldId);
            return View(teacherDto);
        }
        [HttpPost]
        public ActionResult Update(TeacherDto model)
        {
            try
            {
                teacherService.UpdateTeacherDto(model);
                var successMessage = $"معلم با کد  {model.TeacherCode} با موفقیت ثبت شد";
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
                var deletedTeacher = teacherService.DeleteTeacherById(Id);
                var successMessage = $"{deletedTeacher.TeacherCode} با موفقیت حذف شد";
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