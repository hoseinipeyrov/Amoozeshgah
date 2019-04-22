using System;
using System.Web.Mvc;
using Amoozeshgah.ViewModel;
using Amoozeshgah.Services;

namespace Amoozeshgah.WebUI.Areas.EducationalCenterUserArea.Controllers
{
    public class LessonsController : Controller
    {

        ILessonService lessonService;
        IFieldService fieldService;
        ILessonLevelService lessonLevelService;
        public LessonsController(ILessonService lessonService, IFieldService fieldService, ILessonLevelService lessonLevelService)
        {
            this.lessonService = lessonService;
            this.fieldService = fieldService;
            this.lessonLevelService = lessonLevelService;
        }
        public ActionResult Index()
        {
            return View(new LessonDto());
        }
        public JsonResult GetAll()
        {
            var lessons = lessonService.GetAllDto();
            return Json(new { data = lessons }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Add()
        {
            var lessonDto = new LessonDto
            {
                Fields = new SelectList(fieldService.GetFields(), "Id", "Name"),
                LessonLevels= new SelectList(lessonLevelService.GetLessonLevels(), "Id", "Name"),
                Prerequirements= new SelectList(lessonService.GetAll(), "Id", "Name"),
            };
            return View(lessonDto);
        }

        [HttpPost]
        public ActionResult Add(LessonDto model)
        {
            try
            {
                lessonService.CreateNewDto(model);
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
            var lessonDto = lessonService.GetDtoById(id);
            if (lessonDto == null)
            {
                return new HttpNotFoundResult("Not Found!");
            }

            lessonDto.Fields = new SelectList(fieldService.GetFields(), "Id", "Name",lessonDto.FieldId);
            return View(lessonDto);
        }
        [HttpPost]
        public ActionResult Update(LessonDto model)
        {
            try
            {
                lessonService.UpdateDto(model);
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
                var deletedField = lessonService.DeleteById(Id);
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
