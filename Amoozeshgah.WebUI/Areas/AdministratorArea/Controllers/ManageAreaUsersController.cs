using Amoozeshgah.Common.Domain;
using Amoozeshgah.Core.Infrastructure;
using Amoozeshgah.Domain.Entities;
using Amoozeshgah.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Amoozeshgah.WebUI.Areas.AdministratorArea.Controllers
{
    public class ManageAreaUsersController : Controller
    {
        AppContext db = new AppContext();
        public ActionResult Index()
        {
            var siteId = WebUserInfo.SiteId;
            var minSiteId = siteId * 100;
            var maxSiteId = (++siteId * 100) - 1;

            var areaUsers = db.Set<SiteUserRole>().Include("User.Person").Include("Site").Where(sur => sur.RoleId == 3 && sur.SiteId >= minSiteId && sur.SiteId <= maxSiteId).ToList();
            return View(areaUsers);
        }



        [HttpGet]
        public ActionResult CreateNewUser()
        {
            var siteId = WebUserInfo.SiteId;
            var areas = db.Set<Area>().Include("Site").Where(a => a.ProvinceId == siteId).ToList().Select(a => new SelectListItem
            {
                Text = a.Site.Name,
                Value = a.Id.ToString()
            });
            return View(new CreateNewAreaUserDto
            {
                Areas = areas
            });
        }


        [HttpPost]
        public ActionResult CreateNewUser(CreateNewAreaUserDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var sur = new SiteUserRole
            {
                RoleId = 3,
                SiteId = model.AreaId,
                CreatedDate = DateTime.Now,
                User = new User
                {
                    UserName = model.UserName,
                    Password = model.NationalCode,
                    Status = true,
                    CreatedDate = DateTime.Now,
                    Person = new Person
                    {
                        BirthDate = DateTime.Now,
                        SexId = 1,
                        CreatedDate = DateTime.Now,
                        FirstName = model.FirstName,
                        LastName = model.LasttName,
                        NationalCode = model.NationalCode
                    }
                }
            };
            db.Set<SiteUserRole>().Add(sur);
            db.SaveChanges();

            return RedirectToAction("Index");
        }



        [HttpGet]
        public ActionResult EditUser(int id)
        {
            var siteUserRole = db.Set<SiteUserRole>().Include("User.Person").Include("Site").FirstOrDefault(sur => sur.Id == id);
            if (siteUserRole == null)
            {
                return RedirectToAction("Index");
            }

            var siteId = WebUserInfo.SiteId;
            var areas = db.Set<Area>().Include("Site").Where(a => a.ProvinceId == siteId).ToList().Select(a => new SelectListItem
            {
                Text = a.Site.Name,
                Value = a.Id.ToString()
            });

            var x = new CreateNewAreaUserDto
            {
                Id = siteUserRole.Id,
                Areas = areas,
                FirstName = siteUserRole.User.Person.FirstName,
                LasttName = siteUserRole.User.Person.LastName,
                UserName = siteUserRole.User.UserName,
                NationalCode = siteUserRole.User.Person.NationalCode,
                AreaId = siteUserRole.SiteId,
                MobileNo= siteUserRole.User.Person.MobileNo
            };


            return View(x);
        }


        [HttpPost]
        public ActionResult EditUser(CreateNewAreaUserDto model)
        {
            var siteUserRole = db.Set<SiteUserRole>().Include("User.Person").Include("Site").FirstOrDefault(sur => sur.Id == model.Id);
            if (siteUserRole == null)
            {
                return RedirectToAction("Index");
            }

            siteUserRole.User.UserName = model.UserName;
            siteUserRole.User.Person.FirstName = model.FirstName;
            siteUserRole.User.Person.LastName = model.LasttName;
            siteUserRole.User.Person.NationalCode = model.NationalCode;
            siteUserRole.SiteId = model.AreaId;
            siteUserRole.User.Person.MobileNo = model.MobileNo;
            db.Entry(siteUserRole).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}