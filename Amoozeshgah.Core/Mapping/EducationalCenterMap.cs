using Amoozeshgah.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Amoozeshgah.Core.Mapping
{
    public class EducationalCenterMap : EntityTypeConfiguration<EducationalCenter>
    {
        public EducationalCenterMap()
        {
            //Key
            HasKey(t => t.Id);
            //Properties
            //Table
            ToTable("EducationalCenters");

            //Relation
            HasMany(ec => ec.Terms).
                WithRequired(t=>t.EducationalCenter).
                HasForeignKey(t=>t.EducationalCenterId).
                WillCascadeOnDelete(false);

            HasMany(ec => ec.Classrooms).
                WithRequired(cr => cr.EducationalCenter).
                HasForeignKey(cr => cr.EducationalCenterId).
                WillCascadeOnDelete(false);


            // Join Table for Many-to-Many tables of CategoryItems and EducationalCenters
            HasMany(ec => ec.CategoryItems)
                .WithMany(c => c.EducationalCenters)
                .Map(ecc =>
                {
                    ecc.ToTable("EducationalCentersJoinCategoryItems");
                    ecc.MapLeftKey("EducationalCenterId"); 
                    ecc.MapRightKey("CategoryItemId");
                });

            // Join Table for Many-to-Many tables of CourseHoldingTypes and EducationalCenters
            HasMany(ec => ec.CourseHoldingTypes)
                .WithMany(cht => cht.EducationalCenters)
                .Map(eccht =>
                {
                    eccht.ToTable("EducationalCentersJoinCourseHoldingTypes");
                    eccht.MapLeftKey("EducationalCenterId");
                    eccht.MapRightKey("CourseHoldingTypeId");
                });
            //// Join Table for Many-to-Many tables of Teachers and EducationalCenters
            //HasMany(ec => ec.Teachers)
            //    .WithMany(t => t.EducationalCenters)
            //    .Map(ect =>
            //    {
            //        ect.ToTable("EducationalCentersJoinTeachers");
            //        ect.MapLeftKey("EducationalCenterId");
            //        ect.MapRightKey("TeacherId");
            //    });

            // One-to-One Shared Key
            HasRequired(s => s.Site).WithRequiredDependent(s=> s.EducationalCenter).WillCascadeOnDelete(true);
        }
    }
}
