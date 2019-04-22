using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amoozeshgah.Domain.Entities;

namespace Amoozeshgah.Core.Mapping
{
    public class RefundRequestMap : EntityTypeConfiguration<RefundRequest>
    {
        public RefundRequestMap()
        {
            HasKey(rr => rr.Id);
            ToTable("RefundRequests");
        }
    }
}
