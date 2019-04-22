using Amoozeshgah.Common.DateConverter;
using Amoozeshgah.Common.Domain;
using Amoozeshgah.Core.Infrastructure;
using Amoozeshgah.Domain.Entities;
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
    public class CoursesController : Controller
    {

        ICourseService courseService;
        ILessonService lessonService;
        IClassroomService classroomService;
        ITeacherService teacherService;
        ITermService termService;

        public CoursesController(ICourseService courseService,
                                 ILessonService lessonService,
                                 IClassroomService classroomService,
                                 ITeacherService teacherService,
                                 ITermService termService)
        {
            this.courseService = courseService;
            this.lessonService = lessonService;
            this.classroomService = classroomService;
            this.teacherService = teacherService;
            this.termService = termService;

        }
        public ActionResult Index()
        {
            return View(new CourseDto());
        }
        public JsonResult GetAll()
        {
            var courcess = courseService.GetClassesDto();
            return Json(new { data = courcess }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        [AjaxOnly]
        public ActionResult Add()
        {
            var courseDto = new CourseDto
            {
                Lessons = new SelectList(lessonService.GetAll(), "Id", "Name"),
                Teachers = new SelectList(teacherService.GetTeachers(), "Id", "TeacherCode"),
                Classrooms = new SelectList(classroomService.GetClassrooms(), "Id", "Name"),
                Terms = new SelectList(termService.GetTerms(), "Id", "Name"),
            };
            return View(courseDto);
        }

        [HttpPost]
        [AjaxOnly]
        public ActionResult Add(CourseDto model)
        {
            var courseStartDay = model.StartDateJalali.ToGeorgianDateTime();
            var educationalCenterCode = WebUserInfo.SiteId;

            using (var _db = new AppContext())
            {
                var educationalCenter = _db.Set<EducationalCenter>().FirstOrDefault(l => l.Id == educationalCenterCode);

                if (educationalCenter != null)
                {
                    var areaId = educationalCenter.AreaId;
                    var maxRules = _db.Set<MaximumTuition>()
                        .FirstOrDefault(mt => mt.AreaId == areaId && mt.From <= courseStartDay && mt.To >= courseStartDay);
                    if (maxRules==null)
                    {
                        maxRules= _db.Set<MaximumTuition>()
                        .Where(mt => mt.AreaId == areaId).OrderByDescending(mt=>mt.To).First();
                    }

                    var lesson = _db.Set<Lesson>().First(l => l.Id == model.LessonId);
                    var lessonLevel = lesson.LessonLevelId;
                    var lessonTotalHour = lesson.TotalHours;


                    int max = 0;
                    switch (lessonLevel)
                    {
                        case 1: max = maxRules.LanguageElementary; break;
                        case 2: max = maxRules.LanguageMiddle; break;
                        case 3: max = maxRules.LanguageAdvanced; break;
                        case 4: max = maxRules.ScienceElementry; break;
                        case 5: max = maxRules.ScienceFirstMiddle; break;
                        case 6: max = maxRules.ScienceSecondMiddle; break;
                        default:
                            break;
                    }

                    var price = model.Price;
                    if (price>max* lessonTotalHour)
                    {
                        var failMessage = $"حداکثر مبلغ مجاز {max* lessonTotalHour} میباشد";
                        return Json(new { success = false, message = failMessage }, JsonRequestBehavior.AllowGet);
                    }


                }
            }


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
                Lessons = new SelectList(lessonService.GetAll(), "Id", "Name", classDto.LessonId),
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


        [HttpPost]
        public ActionResult AjaxLessonHour(int id = 0)
        {
            var lessonTime = "";
            using (var _db = new AppContext())
            {
                var lesson = _db.Set<Lesson>().FirstOrDefault(l => l.Id == id);

                if (lesson != null)
                {
                    lessonTime = lesson.TotalHours.ToString();
                    return Json(lessonTime, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(lessonTime, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult AjaxPricePerSession(int id = 0, int totalprice = 0)
        {
            using (var _db = new AppContext())
            {
                var lesson = _db.Set<Lesson>().FirstOrDefault(l => l.Id == id);

                if (lesson != null)
                {
                    var lessonTotalHours = lesson.TotalHours;
                    if (lessonTotalHours > 0)
                    {
                        var perHourPrice = totalprice / lessonTotalHours;
                        return Json(perHourPrice, JsonRequestBehavior.AllowGet);
                    }

                }
            }
            return Json(0, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult AjaxSetTuitionMax(int id = 0, int level = 0)
        {
            using (var _db = new AppContext())
            {
                var lesson = _db.Set<Lesson>().FirstOrDefault(l => l.Id == id);

                if (lesson != null)
                {
                }
            }
            return Json(0, JsonRequestBehavior.AllowGet);
        }
    }
}