using Amoozeshgah.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Amoozeshgah.Core.Mapping
{
    public class StudentMap : EntityTypeConfiguration<Student>
    {
        public StudentMap()
        {
            //Key
            HasKey(t => t.Id);

            //Properties

            //Table
            ToTable("Students");
            //Relation          
            HasRequired(s => s.User).WithRequiredDependent(u => u.Student);

        }
    }
}
