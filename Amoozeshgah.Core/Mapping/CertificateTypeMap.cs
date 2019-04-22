using System.Data.Entity.ModelConfiguration;
using Amoozeshgah.Domain.Entities;


namespace Amoozeshgah.Core.Mapping
{
    public class CertificateTypeMap : EntityTypeConfiguration<CertificateType>
    {
        public CertificateTypeMap()
        {
            //Key
            HasKey(t => t.Id);

            //Properties

            //Table
            ToTable("CertificateTypes");
        }
    }
}
