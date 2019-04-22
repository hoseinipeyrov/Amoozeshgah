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
    public class ProvinceSeed
    {
        public static void VandGrow(IDbContext context)
        {
            context.Set<Province>().AddOrUpdate(
                p => new { p.Name },
                new Province
                {
                    Name = "تهران",
                    CreatedBy = "System Seed",
                    Cities = new List<City>()
                              {
                                  new City
                                  {
                                      Code=21,
                                      Name="تهران",
                                      CreatedBy="System Seed",
                                  },
                                   new City
                                  {
                                      Code=22,
                                      Name="رودهن",
                                      CreatedBy="System Seed",
                                  }
                              }
                },
                  new Province
                  {
                      Name = "همدان",
                      CreatedBy = "System Seed",
                      CreatedDate = DateTime.Now,
                      Cities = new List<City>()
                              {
                                  new City
                                  {
                                      CreatedDate =DateTime.Now,
                                      Code=1,
                                      Name="همدان",
                                      CreatedBy="System Seed",
                                  },
                                   new City
                                  {
                                      CreatedDate =DateTime.Now,
                                      Code=2,
                                      Name="نهاوند",
                                      CreatedBy="System Seed",
                                  }
                              }
                  },
                  new Province
                  {
                      Name = "لرستان",
                      CreatedBy = "System Seed",
                      CreatedDate = DateTime.Now,
                      Cities = new List<City>()
                              {
                                  new City
                                  {
                                      CreatedDate =DateTime.Now,
                                      Code=3,
                                      Name="خرم آباد",
                                      CreatedBy="System Seed",
                                  },
                                   new City
                                  {
                                      CreatedDate =DateTime.Now,
                                      Code=4,
                                      Name="بروجرد",
                                      CreatedBy="System Seed",
                                  }
                              }
                  }
           );
            context.SaveChanges();
            //   context.Set<SiteUserRole>().AddOrUpdate(
            //       new SiteUserRole { SiteId = 1, UserId = 2, RoleId = 2, CreatedBy = "System Seed" }
            //);
            //   context.SaveChanges();

        }
    }
}


