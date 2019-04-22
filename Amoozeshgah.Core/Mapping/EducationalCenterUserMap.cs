using Amoozeshgah.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amoozeshgah.Core.Mapping
{
         public class EducationalCenterUserMap : EntityTypeConfiguration<EducationalCenterUser>
    {
        public EducationalCenterUserMap()
        {
            //Key
            HasKey(t => t.Id);

            //Properties

            //Table
            ToTable("EducationalCenterUsers");

            //Relation          
            HasRequired(e=>e.User).WithRequiredDependent(u=>u.EducationalCenterUser);
        }
    }
}
