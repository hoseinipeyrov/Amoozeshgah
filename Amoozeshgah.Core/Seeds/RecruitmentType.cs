using Amoozeshgah.Core.Infrastructure;
using Amoozeshgah.Domain.Entities;
using System;
using System.Data.Entity.Migrations;

namespace Amoozeshgah.Core.Seeds
{
    public class RecruitmentTypeSeed
    {
        public static void VandGrow(AppContext context)
        {
            context.Set<RecruitmentType>().AddOrUpdate(
                rt=>rt.Name,
                  new RecruitmentType { Name = "رسمی",CreatedBy="System Seed",CreatedDate=DateTime.Now},
                  new RecruitmentType { Name = "قراردادی", CreatedBy = "System Seed", CreatedDate = DateTime.Now }
           );

        }
    }
}
