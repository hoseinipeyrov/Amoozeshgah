using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amoozeshgah.Domain.Entities;

namespace Amoozeshgah.Core.Mapping
{
  public  class ReligionMap:EntityTypeConfiguration<Religion>
    {
        public ReligionMap()
        {
            //Key
            HasKey(r => r.Id);

            //Table Name
            ToTable("Religions");
        }
    }
}
