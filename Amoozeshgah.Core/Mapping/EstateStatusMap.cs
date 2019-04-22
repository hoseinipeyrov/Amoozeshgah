using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amoozeshgah.Domain.Entities;

namespace Amoozeshgah.Core.Mapping
{
   public class EstateStatusMap:EntityTypeConfiguration<EstateStatus>
    {
        public EstateStatusMap()
        {
            //Key
            HasKey(es => es.Id);

            //Table Name
            ToTable("EstateStatus");
        }
    }
}
