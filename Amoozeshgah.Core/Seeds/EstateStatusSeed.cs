using Amoozeshgah.Core.Infrastructure;
using Amoozeshgah.Domain.Entities;
using System;
using System.Data.Entity.Migrations;

namespace Amoozeshgah.Core.Seeds
{
    public class EstateStatusSeed
    {
        public static void VandGrow(AppContext context)
        {
            context.Set<EstateStatus>().AddOrUpdate(
                r => r.Code,
                new EstateStatus {Code = 1, Name = "استیجاری", CreatedBy = "System Seed", CreatedDate = DateTime.Now},
                new EstateStatus {Code = 2, Name = "احداثی", CreatedBy = "System Seed", CreatedDate = DateTime.Now},
                new EstateStatus {Code = 3, Name = "خریداری", CreatedBy = "System Seed", CreatedDate = DateTime.Now},
                new EstateStatus {Code = 4, Name = "وقفی", CreatedBy = "System Seed", CreatedDate = DateTime.Now},
                new EstateStatus {Code = 5, Name = "شخصی", CreatedBy = "System Seed", CreatedDate = DateTime.Now});

            context.SaveChanges();
        }
    }
}
