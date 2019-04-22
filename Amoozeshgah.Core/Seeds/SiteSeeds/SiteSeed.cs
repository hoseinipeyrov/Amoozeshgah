using Amoozeshgah.Core.Infrastructure;
using Amoozeshgah.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;

namespace Amoozeshgah.Core.Seeds
{
    public class SiteSeed
    {
        public static void VandGrow(IDbContext context)
        {
            context.Set<Site>().AddOrUpdate(
                  new Site
                  {
                      Id = 11,
                      Name = "اداره کل استان تهران",
                      Province = new Province
                      {
                          Id = 11,
                          Name = "تهران"
                      }
                  },
                  new Site
                  {
                      Id = 12,
                      Name = "اداره کل شهرستان های استان تهران",
                      Province = new Province
                      {
                         Id = 12,
                          Name = "شهرستان های تهران"
                      }
                  },
                  new Site
                  {
                      Id = 13,
                      Name = "اداره کل استان همدان",
                      Province = new Province
                      {
                          Id=13,
                          Name = "همدان"
                      }
                  },
                  new Site
                  {
                      Id = 14,
                      Name = "اداره کل استان لرستان",
                      Province = new Province
                      {
                          Id = 14,
                          Name = "لرستان"
                      }
                  },

                  //Areas

                  new Site
                  {
                      Id = 1111,
                      Name = "ناحیه یک استان تهران",
                      Area=new Area
                      {
                          Id = 1111,
                          ProvinceId = 11
                      }
                  },
                  new Site
                  {
                      Id = 1112,
                      Name = "ناحیه دو استان تهران",
                      Area = new Area
                      {
                          Id = 1112,
                          ProvinceId = 11
                      }
                  },
                  new Site
                  {
                      Id = 1311,
                      Name = "ناحیه یک استان همدان",
                      Area = new Area
                      {
                          Id = 1311,
                          ProvinceId = 13
                      }
                  },
                  new Site
                  {
                      Id = 1312,
                      Name = "ناحیه دو استان همدان",
                      Area = new Area
                      {
                          Id = 1312,
                          ProvinceId = 13
                      }
                  },
                  new Site
                  {
                      Id = 1411,
                      Name = "ناحیه دو استان لرستان",
                      Area = new Area
                      {
                          Id = 1411,
                          ProvinceId = 14
                      }
                  },
                  new Site
                  {
                      Id = 1412,
                      Name = "ناحیه دو استان لرستان",
                      Area = new Area
                      {
                          Id = 1412,
                          ProvinceId = 14
                      }
                  }
              

           );
            context.SaveChanges();
        }
    }
}
