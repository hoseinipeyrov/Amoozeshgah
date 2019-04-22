using Amoozeshgah.Domain.Entities;

using System.Data.Entity.ModelConfiguration;

namespace Amoozeshgah.Core.Mapping
{
    public class DepartmentMap : EntityTypeConfiguration<Department>
    {
        public DepartmentMap()
        {
            //Key
            HasKey(t => t.Id);

            //Properties

            //Table
            ToTable("Departments");
        }
    }
    public class DepartmentTypeMap : EntityTypeConfiguration<DepartmentType>
    {
        public DepartmentTypeMap()
        {
            //Key
            HasKey(t => t.Id);

            //Properties

            //Table
            ToTable("DepartmentTypes");
        }
    }
}
