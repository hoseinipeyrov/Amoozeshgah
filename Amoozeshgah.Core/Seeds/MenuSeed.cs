using Amoozeshgah.Core.Infrastructure;
using Amoozeshgah.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;

namespace Amoozeshgah.Core.Seeds
{
    public class MenuSeed
    {
        public static void VandGrow(AppContext context)
        {
            context.Set<Menu>().AddOrUpdate(
                m => m.Name,
                  new Menu
                  {
                      Name = "اطلاعات پایه",
                      IsEnable = true,
                      CssClass = "livicon",
                      IconName = "thumbnails-small",
                      CreatedBy = "System Seed",
                      MenuItems = new List<MenuItem>
                      {
                            new MenuItem
                            {
                                Name = "پروفایل من",
                                RoleId = 5,
                                IsEnable = true,
                                Area = "EducationalCenterUserArea",
                                Controller = "Dashboard",
                                Action = "Index",
                                CssClass = "gg",
                                CreatedBy = "System Seed"
                            },
                            new MenuItem
                            {
                                Name = "نوع دپارتمان",
                                RoleId = 5,
                                IsEnable = true,
                                Area = "EducationalCenterUserArea",
                                Controller = "DepartmentTypes",
                                Action = "Index",
                                CssClass = "gg",
                                CreatedBy = "System Seed"
                            },
                            new MenuItem
                            {
                                Name = "دپارتمان",
                                RoleId = 5,
                                IsEnable = true,
                                Area = "EducationalCenterUserArea",
                                Controller = "Departments",
                                Action = "Index",
                                CssClass = "gg",
                                CreatedBy = "System Seed"
                            },
                            new MenuItem
                            {
                                Name = "رشته",
                                RoleId = 5,
                                IsEnable = true,
                                Area = "EducationalCenterUserArea",
                                Controller = "Fields",
                                Action = "Index",
                                CssClass = "gg",
                                CreatedBy = "System Seed"
                            },
                            new MenuItem
                            {
                                Name = "درس",
                                RoleId = 5,
                                IsEnable = true,
                                Area = "EducationalCenterUserArea",
                                Controller = "Lessons",
                                Action = "Index",
                                CssClass = "gg",
                                CreatedBy = "System Seed"
                            },
                            new MenuItem
                            {
                                Name = "اتاق درس",
                                RoleId = 5,
                                IsEnable = true,
                                Area = "EducationalCenterUserArea",
                                Controller = "Classrooms",
                                Action = "Index",
                                CssClass = "gg",
                                CreatedBy = "System Seed"
                            },
                            new MenuItem
                            {
                                Name = "تشکیل کلاس",
                                RoleId = 5,
                                IsEnable = true,
                                Area = "EducationalCenterUserArea",
                                Controller = "Courses",
                                Action = "Index",
                                CssClass = "gg",
                                CreatedBy = "System Seed"
                            }
                      }
                  },
                  new Menu
                  {
                      Name = "عملیات جاری",
                      IsEnable = true,
                      CssClass = "livicon",
                      IconName = "desktop",
                      CreatedBy = "System Seed"
                  },
                  new Menu
                  {
                      Name = "گزارش",
                      IsEnable = true,
                      CssClass = "livicon",
                      IconName = "barchart",
                      CreatedBy = "System Seed"
                  }
           );
            context.SaveChanges();


            //  context.Set<MenuItem>().AddOrUpdate(
            //       new MenuItem { Name = "پروفایل من", MenuId = 1, RoleId = 1, IsDisable = true, Area = "", Controller = "Dashboard", Action = "Index", CssClass = "gg", CreatedBy = "System Seed", CreatedDate = DateTime.Now },
            //       new MenuItem { Name = "دپارتمان ها", MenuId = 1, RoleId = 1, IsDisable = true, Area = "", Controller = "Departments", Action = "Index", CssClass = "gg", CreatedBy = "System Seed", CreatedDate = DateTime.Now },
            //       new MenuItem { Name = "نوع دپارتمان", MenuId = 1, RoleId = 1, IsDisable = true, Area = "", Controller = "DepartmentTypes", Action = "Index", CssClass = "gg", CreatedBy = "System Seed", CreatedDate = DateTime.Now },
            //       new MenuItem { Name = "کلاس ها", MenuId = 1, RoleId = 1, IsDisable = true, Area = "", Controller = "Classes", Action = "Index", CssClass = "gg", CreatedBy = "System Seed", CreatedDate = DateTime.Now },
            //       new MenuItem { Name = "اتاق ها", MenuId = 1, RoleId = 1, IsDisable = true, Area = "", Controller = "Classrooms", Action = "Index", CssClass = "gg", CreatedBy = "System Seed", CreatedDate = DateTime.Now },
            //       new MenuItem { Name = "مدرس ها", MenuId = 1, RoleId = 1, IsDisable = true, Area = "", Controller = "Teachers", Action = "Index", CssClass = "gg", CreatedBy = "System Seed", CreatedDate = DateTime.Now },
            //       new MenuItem { Name = "رشته ها", MenuId = 1, RoleId = 1, IsDisable = true, Area = "", Controller = "Fields", Action = "Index", CssClass = "gg", CreatedBy = "System Seed", CreatedDate = DateTime.Now },
            //       new MenuItem { Name = "درس ها", MenuId = 1, RoleId = 1, IsDisable = true, Area = "", Controller = "Lessons", Action = "Index", CssClass = "gg", CreatedBy = "System Seed", CreatedDate = DateTime.Now }
            //);
            //  context.SaveChanges();
        }
    }
}
