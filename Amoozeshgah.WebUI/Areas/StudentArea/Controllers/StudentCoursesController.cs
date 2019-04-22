using Amoozeshgah.Core.Infrastructure;
using Amoozeshgah.Domain.Entities;
using Amoozeshgah.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Amoozeshgah.WebUI.Areas.StudentArea.Controllers
{
    public class StudentCoursesController : Controller
    {
        int StudentId = 2;
        AppContext db = new AppContext();

        // GET: StudentArea/StudentCourses
        //[HttpGet]
        public ActionResult SelectNewCuorse()
        {
            var _student = db.Set<Student>().FirstOrDefault(st => st.Id == StudentId);
            var selectNewCourseDto = new SelectNewCourseDto
            {
                ProvinceId = _student.CityOfHome.ProvinceId,
                CityId = _student.CityOfHomeId,
                Provinces = new SelectList(db.Set<Province>().ToList(), "Id", "Name", _student.CityOfHome.ProvinceId),
                Citys = new SelectList(db.Set<City>().Where(c => c.ProvinceId == _student.CityOfHome.ProvinceId).ToList(), "Id", "Name", _student.CityOfHomeId),
                Categorys = new SelectList(db.Set<Category>().ToList(), "Id", "Name"),
                CategoryItems = new SelectList(db.Set<CategoryItem>().Where(ci => ci.CategoryId == 1).ToList(), "Id", "Name")
            };
            return View(selectNewCourseDto);
        }
        [HttpGet]
        public ActionResult SelectCuorse()
        {
            var x = db.Set<Province>().ToList();

            SelectNewCourseDto selectNewCourseDto = new SelectNewCourseDto
            {
                ProvinceId = 4,
                Provinces = new SelectList(x, "Id", "Name")
            };

            return View(selectNewCourseDto);
        }
        [HttpPost]
        public ActionResult SelectCuorse(SelectNewCourseDto d)
        {

            return View(d);
        }
        [HttpPost]
        public ActionResult Cities(int? provinceId)
        {

            var provincecities = db.Set<City>().Where(c => c.ProvinceId == provinceId.Value).Select(c=>new { Id=c.Id, Name=c.Name}).ToList();
            return Json(provincecities, JsonRequestBehavior.AllowGet);
        }
    }
}