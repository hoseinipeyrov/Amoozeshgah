using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amoozeshgah.Domain.Entities;

namespace Amoozeshgah.Core.Mapping
{
    class CourseHoldingTypeMap:EntityTypeConfiguration<CourseHoldingType>
    {
        public CourseHoldingTypeMap()
        {
            //Key
            HasKey(cht => cht.Id);

            //Table Name
            ToTable("CourseHoldingTypes");
        }
    }
}
