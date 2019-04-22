using Amoozeshgah.Core.Infrastructure;
using Amoozeshgah.Domain.Entities;
using Amoozeshgah.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Amoozeshgah.WebUI.Areas.AdministratorArea.Controllers
{
    public class ManageProvinceUsersController : Controller
    {
        AppContext db = new AppContext();
        public ActionResult Index()
        {
            var setadUsers = db.Set<SiteUserRole>().Include("User.Person").Include("Site").Where(sur => sur.RoleId == 2).ToList();
            return View(setadUsers);
        }

        [HttpGet]
        public ActionResult CreateNewUser()
        {
            var administrations = db.Set<Province>().Include(p=>p.Site).ToList().Select(a => new SelectListItem
            {
                Text = a.Site.Name,
                Value = a.Id.ToString()
            });

            return View(new CreateNewAdministrationsUserDto
            {
                Administrations = administrations
            });
        }
        [HttpPost]
        public ActionResult CreateNewUser(CreateNewAdministrationsUserDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var sur = new SiteUserRole
            {
                RoleId = 2,
                SiteId = model.AdministrationId,
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
                        NationalCode = model.NationalCode,
                        MobileNo=model.MobileNo
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
            var siteUserRole= db.Set<SiteUserRole>().Include("User.Person").Include("Site").FirstOrDefault(sur => sur.Id == id);
            if (siteUserRole==null)
            {
                return RedirectToAction("Index");
            }

            var administrations = db.Set<Province>().Include("Site").ToList().Select(a => new SelectListItem
            {
                Text = a.Site.Name,
                Value = a.Id.ToString()
            });

            var x = new CreateNewAdministrationsUserDto
            {
                Id=siteUserRole.Id,
                Administrations = administrations,
                FirstName = siteUserRole.User.Person.FirstName,
                LasttName = siteUserRole.User.Person.LastName,
                UserName = siteUserRole.User.UserName,
                NationalCode = siteUserRole.User.Person.NationalCode,
                AdministrationId=siteUserRole.SiteId,
                MobileNo = siteUserRole.User.Person.MobileNo
            };


            return View(x);
        }


        [HttpPost]
        public ActionResult EditUser(CreateNewAdministrationsUserDto model)
        {
            var siteUserRole = db.Set<SiteUserRole>().Include("User.Person").Include("Site").FirstOrDefault(sur => sur.Id == model.Id);
            if (siteUserRole == null)
            {
                return RedirectToAction("Index");
            }

            siteUserRole.User.UserName = model.UserName;
            siteUserRole.User.Person.FirstName = model.FirstName;
            siteUserRole.User.Person.LastName = model.LasttName;
            siteUserRole.User.Person.MobileNo = model.MobileNo;

            siteUserRole.User.Person.NationalCode = model.NationalCode;
            siteUserRole.SiteId = model.AdministrationId;
            db.Entry(siteUserRole).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}