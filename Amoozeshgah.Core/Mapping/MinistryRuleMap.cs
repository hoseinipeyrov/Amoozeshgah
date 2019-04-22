using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amoozeshgah.Domain.Entities;

namespace Amoozeshgah.Core.Mapping
{
    public class MinistryRuleMap:EntityTypeConfiguration<MinistryRule>
    {
        public MinistryRuleMap()
        {
            //Key
            HasKey(mr => mr.Id);

            //Table Name
            ToTable("MinistryRules");
        }
    }
}
