using Amoozeshgah.Common.Domain;
using Amoozeshgah.Core.Infrastructure;
using Amoozeshgah.Domain.Entities;
using Amoozeshgah.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Amoozeshgah.WebUI.Areas.AdministratorArea.Controllers
{
    public class RegisteredStudentsController : Controller
    {
        private readonly AppContext _db;

        public RegisteredStudentsController()
        {
            _db = new AppContext();
        }
        [HttpGet]
        public ActionResult AllList()
        {
            var roleId = WebUserInfo.RoleId;


            var searchRegisteredStudentDto = new AdministratorSearchRegisteredStudentDto
            {

                Areas = new List<SelectListItem>
                {

                    new SelectListItem
                    {
                        Text = "همه ناحیه ها",
                        Value = "0"
                    }
                },

                EducationalCenterCategories = new List<SelectListItem>
                {
                    new SelectListItem
                    {
                        Text = "همه موارد",
                        Value = "همه موارد",
                        Selected = true
                    },
                    new SelectListItem
                    {
                        Text = "مرکز زبان خارجه",
                        Value = "مرکز زبان خارجه"
                    },
                    new SelectListItem
                    {
                        Text = "مرکز علمی آزاد",
                        Value = "مرکز علمی آزاد"
                    }
                }
            };

            searchRegisteredStudentDto.Sexes.Add(new SelectListItem
            {
                Value = "0",
                Text = "هر دو"
            });

            searchRegisteredStudentDto.Sexes.AddRange(_db.Set<Sex>().ToList().Select(p => new SelectListItem
            {
                Text = p.Title,
                Value = p.Id.ToString()
            }));


            if (roleId == 1)
            {
                searchRegisteredStudentDto.Provinces.Add(new SelectListItem
                {
                    Value = "0",
                    Text = "همه استان ها"
                });
                searchRegisteredStudentDto.Provinces.AddRange(_db.Set<Province>().ToList().Select(p => new SelectListItem
                {
                    Text = p.Name,
                    Value = p.Id.ToString()
                }));
            }
            else if (roleId == 2)
            {
                var site = _db.Set<Site>().Include("Province").First(s => s.Id == WebUserInfo.SiteId);
                searchRegisteredStudentDto.Provinces.Add(new SelectListItem
                {
                    Value = site.Province.Id.ToString(),
                    Text = site.Province.Name,
                    Selected = true
                });
                searchRegisteredStudentDto.Areas.AddRange(
                    _db.Set<Area>().Include("Site").Where(a => a.ProvinceId == WebUserInfo.SiteId).ToList().Select(a => new SelectListItem
                    {
                        Text = a.Site.Name,
                        Value = a.Id.ToString()
                    }));
            }
            else if (roleId == 3)
            {
                var area = _db.Set<Area>().Include("Province").Include("Site").First(a => a.Id == WebUserInfo.SiteId);
                searchRegisteredStudentDto.Provinces.Add(new SelectListItem
                {
                    Value = area.Province.Id.ToString(),
                    Text = area.Province.Name,
                    Selected = true
                });
                searchRegisteredStudentDto.Areas = new List<SelectListItem>()
                {
                    new SelectListItem
                    {
                        Value = area.Id.ToString(),
                        Text = area.Site.Name,
                        Selected = true
                    }
                };
            }
            return View(searchRegisteredStudentDto);
        }


        [HttpPost]
        public ActionResult AllList(AdministratorSearchEducationalCenterDto model)
        {
            if (WebUserInfo.RoleId == 2)
            {
                model.ProvinceId = _db.Set<Province>().First(p => p.Id == WebUserInfo.SiteId).Id;
            }

            if (WebUserInfo.RoleId == 3)
            {
                model.AreaId = WebUserInfo.SiteId;
                model.ProvinceId = _db.Set<Area>().First(a => a.Id == WebUserInfo.SiteId).ProvinceId;
            }


            var allEducationalCenters = _db.Set<EducationalCenter>()
                .Include(ec => ec.Site)
                .Include(ec => ec.Area.Province)
                .Include(ec => ec.Area.Site)
                .Include(ec => ec.Sex)
                .Where(ec => model.EducationalCenterCode == null || ec.Id == model.EducationalCenterCode)
                .Where(ec => model.EducationalCenterName == null || ec.Site.Name.Contains(model.EducationalCenterName))

                .AsQueryable();


            if (model.ProvinceId != 0)
            {
                allEducationalCenters = model.AreaId == 0 ?
                   allEducationalCenters.Where(ec => ec.Area.ProvinceId == model.ProvinceId) :
                   allEducationalCenters.Where(ec => ec.AreaId == model.AreaId);
            }

            if (model.EducationalCenterCategory != "همه موارد")
            {
                allEducationalCenters = allEducationalCenters.Where(ec => ec.Category == model.EducationalCenterCategory);
            }

            if (model.SexId != 0)
            {
                allEducationalCenters = allEducationalCenters.Where(ec => ec.SexId == model.SexId);
            }

            var r = allEducationalCenters.ToList().Select(ec => new
            {
                EducationalCenterName = ec.Site.Name,
                EducationalCenterCode = ec.Id,
                Province = ec.Area.Province.Name,
                Area = ec.Area.Site.Name,
                Category = ec.Category,
                Sex = ec.Sex.Title
            });
            return Json(r, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult AjaxProvinceAreas(int provinceId = 0)
        {

            if (provinceId == 0)
            {
                return Json(new { isOne = true }, JsonRequestBehavior.AllowGet);
            }
            var areas = _db.Set<Province>().Include("Areas.Site").ToList().First(p => p.Id == provinceId).Areas.ToList().Select(a => new
            {
                Id = a.Id.ToString(),
                Text = a.Site.Name,
                isOne = false
            });
            return Json(areas, JsonRequestBehavior.AllowGet);

        }
    }
}