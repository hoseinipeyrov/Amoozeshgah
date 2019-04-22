using Amoozeshgah.Services;
using Amoozeshgah.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Amoozeshgah.WebUI.Areas.SiteUsers.Controllers
{
    public class CoursesController : Controller
    {

        ICourseService courseService;
        ILessonService lessonService;
        IClassroomService classroomService;
        ITeacherService teacherService;


        public CoursesController(ICourseService courseService,
                                 ILessonService lessonService,
                                 IClassroomService classroomService,
                                 ITeacherService teacherService)
        {
            this.courseService = courseService;
            this.lessonService = lessonService;
            this.classroomService = classroomService;
            this.teacherService = teacherService;

        }
        public ActionResult Index()
        {
            return View(new CourseDto());
        }
        public JsonResult GetAll()
        {
            var lessons = courseService.GetClassesDto();
            return Json(new { data = lessons }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Add()
        {
            var classDto = new CourseDto
            {
                Lessons = new SelectList(lessonService.GetAll(), "Id", "Name"),
                Teachers = new SelectList(teacherService.GetTeachers(), "Id", "TeacherCode"),
                Classrooms = new SelectList(classroomService.GetClassrooms(), "Id", "Name")
            };
            return View(classDto);
        }

        [HttpPost]
        public ActionResult Add(CourseDto model)
        {
            try
            {
                courseService.CreateNewCourseDto(model);
                var successMessage = $"رشته {model.Code} با موفقیت ثبت شد";
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
            var classDto = courseService.GetCourseDtoById(id);
            if (classDto == null)
            {
                return new HttpNotFoundResult("Not Found!");
            }
            classDto = new CourseDto
            {
                Lessons = new SelectList(lessonService.GetAll(), "Id", "Name",classDto.LessonId),
                Teachers = new SelectList(teacherService.GetTeachers(), "Id", "TeacherCode", classDto.TeacherId),
                Classrooms = new SelectList(classroomService.GetClassrooms(), "Id", "Name", classDto.ClassroomId)
            };
            return View(classDto);
        }
        [HttpPost]
        public ActionResult Update(CourseDto model)
        {
            try
            {
                courseService.UpdateClassDto(model);
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
                var deletedField = courseService.DeleteClassById(Id);
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