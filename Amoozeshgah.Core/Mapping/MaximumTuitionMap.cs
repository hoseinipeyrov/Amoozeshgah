using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amoozeshgah.Domain.Entities;

namespace Amoozeshgah.Core.Mapping
{
   public class MaximumTuitionMap:EntityTypeConfiguration<MaximumTuition>
    {
        public MaximumTuitionMap()
        {
            //Table Key
            HasKey(mt => mt.Id);

            //Table Name
            ToTable("MaximumTuitions");
        }
    }
}
