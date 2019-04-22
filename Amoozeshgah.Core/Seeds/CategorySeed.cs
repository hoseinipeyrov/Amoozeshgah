using Amoozeshgah.Core.Infrastructure;
using Amoozeshgah.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amoozeshgah.Core.Seeds
{
    public class CategorySeed
    {
        public static void VandGrow(IDbContext context)
        {
            context.Set<Category>().AddOrUpdate(
                m => m.Name,
                  new Category
                  {
                      Name = "مرکز زبان خارجه",
                      Code=1,
                      CategoryItems = new List<CategoryItem>
                      {
                          new CategoryItem {
                              Name = "موسسه زبان های خارجه",
                              CreatedBy = "System Seed" }
                      },
                      LessonLevels = new List<LessonLevel>
                      {
                          new LessonLevel
                          {
                              Name="مقدماتی",
                              CreatedBy = "System Seed"
                          },
                          new LessonLevel
                          {
                              Name="میانی",
                              CreatedBy = "System Seed"
                          },
                          new LessonLevel
                          {
                              Name="پیشرفته",
                              CreatedBy = "System Seed"
                          }
                      }
                  },

                  new Category
                  {
                      Name = "مرکز علمی آزاد",
                      Code = 2,
                      CategoryItems = new List<CategoryItem>
                      {
                          new CategoryItem {
                              Name = "موسسه علمی ابتدایی",
                              CreatedBy = "System Seed"
                          },
                          new CategoryItem {
                              Name = "موسسه علمی متوسطه اول",
                              CreatedBy = "System Seed"
                          },
                          new CategoryItem {
                              Name = "موسسه علمی متوسطه دوم",
                              CreatedBy = "System Seed"
                          }
                          ,
                          new CategoryItem {
                              Name = "موسسه علمی کنکور",
                              CreatedBy = "System Seed"
                          }

                      },
                      LessonLevels = new List<LessonLevel>
                      {
                          new LessonLevel
                          {
                              Name="ابتدایی",
                              CreatedBy = "System Seed"
                          },
                          new LessonLevel
                          {
                              Name="متوسط اول",
                              CreatedBy = "System Seed"
                          },
                          new LessonLevel
                          {
                              Name="متوسط دوم",
                              CreatedBy = "System Seed"
                          },
                          new LessonLevel
                          {
                              Name="کنکور",
                              CreatedBy = "System Seed"
                          }
                      }
                  },

                  new Category
                  {
                      Name = "مرکز برگزاری آزمون های ادواری",
                      Code = 3,
                      CategoryItems = new List<CategoryItem>
                      {
                          new CategoryItem {
                              Name = "موسسه برگزاری آزمون های ادواری",
                              CreatedBy = "System Seed"
                          }

                      },
                      LessonLevels = new List<LessonLevel>
                      {
                          new LessonLevel
                          {
                              Name="آزمون",
                              CreatedBy = "System Seed"
                          }
                      }
                  }
           );
            context.SaveChanges();
        }
    }
}
