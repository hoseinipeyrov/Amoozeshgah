using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amoozeshgah.Domain.Entities;

namespace Amoozeshgah.Core.Mapping
{
    public class MilitaryStatusMap:EntityTypeConfiguration<MilitaryStatus>
    {
        public MilitaryStatusMap()
        {
            //Key
            HasKey(ms => ms.Id);

            //Table Name
            ToTable("MilitaryStatus");
        }
    }
}
