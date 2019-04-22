using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amoozeshgah.Core.Infrastructure;
using Amoozeshgah.Domain.Entities;

namespace Amoozeshgah.Core.Seeds
{
    public class BankSeed
    {
        public static void VandGrow(AppContext context)
        {
            context.Set<Bank>().AddOrUpdate(
                c => c.Name,
                new Bank { Name = "ملت", Code = 1, CreatedDate = DateTime.Now },
                new Bank { Name = "ملی", Code = 2, CreatedDate = DateTime.Now },
                new Bank { Name = "پارسیان", Code = 3, CreatedDate = DateTime.Now },
                new Bank { Name = "پاسارگاد", Code = 4, CreatedDate = DateTime.Now }
            );
            context.SaveChanges();
        }
    }
}
