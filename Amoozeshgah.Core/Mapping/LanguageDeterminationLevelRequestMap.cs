using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amoozeshgah.Domain.Entities;

namespace Amoozeshgah.Core.Mapping
{
   public class LanguageDeterminationLevelRequestMap:EntityTypeConfiguration<LanguageDeterminationLevelRequest>
    {

        public LanguageDeterminationLevelRequestMap()
        {
            //Key
            HasKey(ldlr => ldlr.Id);

            //Table Name
            ToTable("LanguageDeterminationLevelRequests");
        }
    }
}
