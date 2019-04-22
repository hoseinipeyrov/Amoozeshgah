using Amoozeshgah.Core.Infrastructure;
using Amoozeshgah.Domain.Entities;
using System;
using System.Data.Entity.Migrations;

namespace Amoozeshgah.Core.Seeds
{
    public class ShiftSeed
    {
        public static void VandGrow(AppContext context)
        {
            context.Set<Shift>().AddOrUpdate(
                  new Shift { Id = 1, Name = "صبح", CreatedBy = "System Seed", CreatedDate = DateTime.Now },
                  new Shift { Id = 2, Name = "عصر", CreatedBy = "System Seed", CreatedDate = DateTime.Now },
                  new Shift { Id = 3, Name = "تمام وقت", CreatedBy = "System Seed", CreatedDate = DateTime.Now }
           );
            context.SaveChanges();
        }
    }
}
