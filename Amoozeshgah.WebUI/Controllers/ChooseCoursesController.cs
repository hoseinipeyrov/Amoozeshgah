using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using Amoozeshgah.Common.Domain;
using Amoozeshgah.Core.Infrastructure;
using Amoozeshgah.Domain.Entities;
using Amoozeshgah.ViewModel;
using Microsoft.Ajax.Utilities;

namespace Amoozeshgah.WebUI.Controllers
{
    public class ChooseCoursesController : Controller
    {
        private readonly AppContext _db;

        public ChooseCoursesController()
        {
            _db = new AppContext();
        }

        [HttpGet]
        public ActionResult SearchCourses()
        {
            


            var searchCourseDto = new SearchCourseDto
            {
                Provinces = _db.Set<Province>().ToList().Select(p => new SelectListItem
                {
                    Text = p.Name,
                    Value = p.Id.ToString()
                }),
                Areas = new List<SelectListItem>
                {

                    new SelectListItem
                    {
                        Text = "همه ناحیه ها",
                        Value = "1"
                    }
                },
                Sexes = _db.Set<Sex>().ToList().Select(p => new SelectListItem
                {
                    Text = p.Title,
                    Value = p.Id.ToString()
                }),
                EducationalCenterCategories = new List<SelectListItem>
                {
                    new SelectListItem
                    {
                        Text = "مرکز زبان خارجه",
                        Value = "مرکز زبان خارجه"
                    },
                    new SelectListItem
                    {
                        Text = "مرکز علمی",
                        Value = "مرکز علمی"
                    }
                }
            };
            return View(searchCourseDto);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult AjaxProvinceAreas(int provinceId = 0)
        {
            var areas = _db.Set<Province>().Include("Areas.Site").ToList().First(p => p.Id == provinceId).Areas.ToList().Select(a => new
            {
                Id = a.Id.ToString(),
                Text = a.Site.Name
            });
            return Json(areas, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public ActionResult SearchCourses(SearchCourseDto model)
        {

            var r = _db.Set<Course>()
                       .Include("Lesson.Field.Department.DepartmentType.EducationalCenter.Site")
                       .Include("Teacher.User.Person")
                       .Include("Lesson.Field.Department.DepartmentType.EducationalCenter.Sex")
                       .Where(c => (model.CourseCode == null || c.Code == model.CourseCode) &&
                                   (model.CourseName == null || c.Name.Contains(model.CourseName)) &&
                                   (model.EducationalCenterCode == null || c.Lesson.Field.Department.DepartmentType.EducationalCenterId == model.EducationalCenterCode) &&
                                   (model.EducationalCenterName == null || c.Lesson.Field.Department.DepartmentType.EducationalCenter.Site.Name.Contains(model.EducationalCenterName)) &&
                                   (c.Lesson.Field.Department.DepartmentType.EducationalCenter.SexId == model.SexId) &&
                                   (c.Lesson.Field.Department.DepartmentType.EducationalCenter.AreaId == model.AreaId) &&
                                  (c.Lesson.Field.Department.DepartmentType.EducationalCenter.Category == model.EducationalCenterCategory)

                                   )
                        .ToList()
                        .Select(c => new
                        {
                            CourseNameAndCode = c.Name + " " + c.Code,
                            EducationalCenterNameAndCode = c.Lesson.Field.Department.DepartmentType.EducationalCenter.Site.Name + " " + c.Lesson.Field.Department.DepartmentType.EducationalCenter.Id,
                            LessonName = c.Lesson.Name,
                            TeacherName = c.Teacher.User.Person.FirstName + " " + c.Teacher.User.Person.LastName,
                            SexType = c.Lesson.Field.Department.DepartmentType.EducationalCenter.Sex.Title,
                            Select = c.Id
                        });
            return Json(r, JsonRequestBehavior.AllowGet);
        }



        [HttpPost]
        public ActionResult AjaxCourseDetails(int courseId)
        {
            var course = _db.Set<Course>().Include("Teacher.User.Person")
                                          .Include("Lesson.Field.Department.DepartmentType.EducationalCenter.Site")
                                          .Include("Lesson.Field.Department.DepartmentType.EducationalCenter.Sex")
                                          .FirstOrDefault(c => c.Id == courseId);
            var detail = $@"ثبت نام در کلاس 
                                <strong>{course.Name}</strong>
                                <hr />
                                <div class='row'>
                                <div class='col-xs-12 col-md-6 adineh'>
                                     <lable>مرکز آموزشی: </label>
                                     <strong>{course.Lesson.Field.Department.DepartmentType.EducationalCenter.Site.Name}</strong>
                                </div>
                                <div class='col-xs-12 col-md-6 adineh'>
                                     <lable>کد مرکز: </label>
                                     <strong>{course.Lesson.Field.Department.DepartmentType.EducationalCenter.Id}</strong>
                                </div>
                                <div class='col-xs-12 col-md-6 adineh'>
                                     <lable>نشانی: </label>
                                     <strong>{course.Lesson.Field.Department.DepartmentType.EducationalCenter.Site.Address}</strong>
                                </div>
                                <div class='col-xs-12 col-md-6 adineh'>
                                     <lable>تلفن تماس: </label>
                                     <strong>{course.Lesson.Field.Department.DepartmentType.EducationalCenter.Site.PhoneNo1}</strong>
                                     &nbsp;&nbsp;&nbsp;
                                     <strong>{course.Lesson.Field.Department.DepartmentType.EducationalCenter.Site.PhoneNo1}</strong>
                                </div>
                                <div class='col-xs-12 col-md-6 adineh'>
                                     <lable>جنسیت: </label>
                                     <strong>{course.Lesson.Field.Department.DepartmentType.EducationalCenter.Sex.Title}</strong>
                                </div>
                                <div class='col-xs-12 col-md-6 adineh'>
                                     <lable>نام مدرس: </label>
                                     <strong>{course.Teacher.User.Person.FirstName} {course.Teacher.User.Person.LastName}</strong>
                                </div>
                                <div class='col-xs-12 col-md-6 adineh'>
                                     <lable>ظرفیت: </label>
                                     <strong>{course.Capacity} نفر</strong>
                                </div>
                                <div class='col-xs-12 col-md-6 adineh'>
                                     <lable>طول دوره: </label>
                                     <strong>{course.Lesson.TotalHours} ساعت</strong>
                                </div>
                            </div>
                            <hr />
                            <a onclick='gotoRules({courseId})' class='btn btn-primary btn-sm'>ادامه</a>
                            ";
            return Json(detail, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AjaxCourseRules(int courseId)
        {
            var course = _db.Set<Course>().Include("Lesson.Field.Department.DepartmentType.EducationalCenter").FirstOrDefault(c => c.Id == courseId);
            var ministryRule = _db.Set<MinistryRule>().FirstOrDefault();
            var educationalCenterRule = course?.Lesson.Field.Department.DepartmentType.EducationalCenter.Rule;
            var ecRule = $@"قوانین ثبت نام در کلاس 
                                <strong>{course.Name}</strong>
                                <hr />
                            <i class='fa fa-fw fa-check-circle text-success'></i><strong class='text-success'>قوانین آموزش و پروزش کشور</strong>
                            <p>{ministryRule.Rule}</p>
                            <br />
                            <i class='fa fa-fw fa-check-circle text-success'></i><strong class='text-success'>قوانین مرکز آموزشی</strong>

                            <p>{educationalCenterRule}</p>
                            <hr />
                            <a onclick='registerNewCourse({courseId})' class='btn btn-primary btn-sm'>قبول می کنم. ادامه</a>
                            ";
            return Json(ecRule, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AjaxRegisterNewCourse(int courseId)
        {
            
            if (User.Identity.IsAuthenticated)
            {
                var course = _db.Set<Course>()
                    .Include(c => c.CoursesJoinStudents)
                    .Include(c => c.Lesson.Field.Department.DepartmentType.EducationalCenter)
                    .FirstOrDefault(c => c.Id == courseId);
                if (course == null)
                {
                    return Json(new { success = false, message = $"درسی با کد {courseId} یافت نشد " }, JsonRequestBehavior.AllowGet);
                }
                
                var courseSexId = course.Lesson.Field.Department.DepartmentType.EducationalCenter.SexId;
                var userId = WebUserInfo.UserId;
                var student = _db.Set<Student>().Include(s => s.User.Person).FirstOrDefault(s => s.Id == userId && s.User.Person.SexId == courseSexId);
                if (student == null)
                {
                    return Json(new { success = false, message = "لطفا ابتدا بعنوان فراگیر وارد شوید" }, JsonRequestBehavior.AllowGet);
                }



                var regesterdStudentsCount = course.CoursesJoinStudents.ToList().Count();

                if (regesterdStudentsCount >= course.Capacity)
                {
                    return Json(new { success = false, message = "ظرفیت این کلاس تکمیل شده است" }, JsonRequestBehavior.AllowGet);
                }

                if (course.CoursesJoinStudents.Count(cjs => cjs.StudentId == student.Id) != 0)
                {
                    return Json(new { success = false, message = "شما قبلا در این کلاس ثبت نام نموده اید" }, JsonRequestBehavior.AllowGet);
                }
                
                return Json(new { success = true, message = "برو به درگاه بانکی" }, JsonRequestBehavior.AllowGet);
                //response redirect 

            }

            return Json(new { success = false, message = "لطفا ابتدا وارد شوید" }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SuccessRegisterDialog()
        {
            return View();
        }
    }
}
