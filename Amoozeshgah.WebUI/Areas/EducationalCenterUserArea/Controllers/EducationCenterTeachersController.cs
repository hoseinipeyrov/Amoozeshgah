using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Amoozeshgah.Common;
using Amoozeshgah.Common.Domain;
using Amoozeshgah.Core.Infrastructure;
using Amoozeshgah.Domain.Entities;
using Amoozeshgah.ViewModel;
using Microsoft.Ajax.Utilities;

namespace Amoozeshgah.WebUI.Areas.EducationalCenterUserArea.Controllers
{
    public class EducationCenterTeachersController : Controller
    {
        private readonly AppContext _db = new AppContext();
        private readonly int _siteId = WebUserInfo.SiteId;
        public ActionResult Index()
        {
            var teachers = _db.Set<EducationalCenter>().Include("Teachers.Teacher.User.Person")
                                                                .First(ec => ec.Id == _siteId)
                                                                .Teachers.Select(t => new EducationalCenterTeacherDto
                                                                {
                                                                    Status = t.IsDisable.ToEnableOrDisabe(),
                                                                    FirstName = t.Teacher.User.Person.FirstName,
                                                                    LastName = t.Teacher.User.Person.LastName,
                                                                    NationalCode = t.Teacher.User.Person.NationalCode,
                                                                   
                                                                });

            return View(teachers);
        }



        [HttpGet]
        public ActionResult AddNewTeacher()
        {
            return View("AddNewTeacher", new AddNewTeacherDto());
        }

        [HttpPost]
        public ActionResult AddNewTeacher(AddNewTeacherDto model)
        {
            var educationalCenter = _db.Set<EducationalCenter>().Include("Teachers.Teacher.User.Person").First(ec => ec.Id == _siteId);
            var teacher = _db.Set<Teacher>().Include(t=>t.User.Person).First(t => t.User.Person.NationalCode == model.NationalCode);
            var search =
                educationalCenter.Teachers.FirstOrDefault(t => t.Teacher.User.Person.NationalCode == model.NationalCode);
            if (search == null)
            {
                educationalCenter.Teachers.Add(new EducationalCenterJoinTeacher {TeacherId = teacher.Id,EducationalCenterId = _siteId});
                _db.SaveChanges();
                TempData["AddTeacherMessage"] =
                    $"<div class='alert alert-success'>{teacher.User.Person.FirstName} {teacher.User.Person.LastName} با موفقیت افزوده شد</div>";
                return RedirectToAction(nameof(Index));
            }

            TempData["AddTeacherMessage"] =
                $"<div class='alert alert-info'>{teacher.User.Person.FirstName} {teacher.User.Person.LastName} وجود دارد</div>";
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public ActionResult SearchByNationalCode()
        {
            return RedirectToAction(nameof(AddNewTeacher));
        }
        [HttpPost]
        public ActionResult SearchByNationalCode(AddNewTeacherDto model)
        {
            var teacher = _db.Set<Teacher>().Include("User.Person").FirstOrDefault(t => t.User.Person.NationalCode == model.NationalCode);
            if (teacher != null)
            {
                var checkTeacher = new AddNewTeacherDto
                {
                    NationalCode = teacher.User.Person.NationalCode,
                    EducationalCenterTeachers = new List<AddNewTeacherDto>
                    {
                        new AddNewTeacherDto
                        {
                            FirstName = teacher.User.Person.FirstName,
                            LastName = teacher.User.Person.LastName,
                            NationalCode = teacher.User.Person.NationalCode
                        }
                    }
                };
                return View("AddNewTeacher", checkTeacher);

            }
            return View("AddNewTeacher", new AddNewTeacherDto());

        }

        [HttpGet]
        public ActionResult SearchByName()
        {
            return RedirectToAction(nameof(SearchByName));
        }
        [HttpPost]
        public ActionResult SearchByName(AddNewTeacherDto model)
        {
            var teacher = _db.Set<Teacher>().Include("User.Person").Where(t => t.User.Person.FirstName.Contains(model.FirstName) || t.User.Person.LastName.Contains(model.LastName)).ToList()
                .Select(t => new AddNewTeacherDto
                {
                    FirstName = t.User.Person.FirstName,
                    LastName = t.User.Person.LastName,
                    NationalCode = t.User.Person.NationalCode,
                }).ToList();
            return View("AddNewTeacher", new AddNewTeacherDto
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                EducationalCenterTeachers = teacher
            });


        }

        [HttpPost]
        public ActionResult ChangeStatus(string nationalCode)
        {
            var educationalCenter = _db.Set<EducationalCenter>().Include("Teachers.Teacher.User.Person")
                .First(ec => ec.Id == _siteId);
            var teacher = educationalCenter.Teachers.First(t => t.Teacher.User.Person.NationalCode == nationalCode);
            teacher.IsDisable=!teacher.IsDisable;
            _db.Entry(educationalCenter).State = EntityState.Modified;
            _db.SaveChanges();
            

            return RedirectToAction(nameof(Index));
        }

    }
}