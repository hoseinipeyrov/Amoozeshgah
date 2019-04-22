using Amoozeshgah.Core.UoW;
using System.Collections.Generic;
using System.Data.Entity;
using System;
using System.Linq;
using Amoozeshgah.ViewModel;
using AutoMapper;
using Amoozeshgah.Domain.Entities;

namespace Amoozeshgah.Services
{
    public class SiteUserWithDetailService : Service, IUserWithDetailService
    {
        public SiteUserWithDetailService(UnitOfWork uow) : base(uow)
        {
        }
        //Todelete
        public IEnumerable<SiteUserRole> FindUser(int roleId, string username, string password)
        {
            var x = uow.Repository<SiteUserRole>()
                       .GetAll(pur => pur.RoleId == roleId && pur.User.UserName == username && pur.User.Password == password && pur.User.Status == true)
                       .ToList();
            return x;
        }
        public IEnumerable<SiteUserRole> FindSiteUser(int roleId, string username, string password)
        {
            return uow.Repository<SiteUserRole>()
                       .GetAll(sur => sur.RoleId == roleId && sur.User.UserName == username && sur.User.Password == password && sur.User.Status == true)
                       .ToList();
        }

        public Person FindPersonByUserId(int userId)
        {
            return uow.Repository<Person>()
                      .Get(p => p.Id == userId);
        }

        public IEnumerable<Menu> GetSidebar(int roleId, string currentController, string CurrentAction)
        {
            var menus = uow.Repository<Menu>().GetAll(null, null, "MenuItems")
                .Where(m => m.MenuItems.Any(i => i.RoleId == roleId && i.IsEnable == true))
                .ToList();
            foreach (var menu in menus)
            {
                var menuItems = menu.MenuItems.Where(i=>i.RoleId == roleId).ToList();
                menu.MenuItems = menuItems;
            }
            menus.RemoveAll(m => m.MenuItems.Count == 0);
            return menus;
        }
        public void Create(SiteUserRole siteUserRole)
        {
            uow.Repository<SiteUserRole>().Create(siteUserRole);
            uow.SaveChanges();
        }
    }

}
