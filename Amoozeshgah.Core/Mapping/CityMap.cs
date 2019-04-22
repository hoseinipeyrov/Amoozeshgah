using Amoozeshgah.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Amoozeshgah.Core.Mapping
{
   public class CityMap : EntityTypeConfiguration<City> 
    {
       public CityMap()
       {
            //Key
            HasKey(t => t.Id);

            //Properties
            Property(t => t.Name).IsRequired().HasMaxLength(50);

            //Table
            ToTable("Cities");
            //Relation
            HasMany(e => e.CityOfBirths).
                WithRequired(e => e.CityOfBirth).
                HasForeignKey(e => e.CityOfBirthId).
                WillCascadeOnDelete(false);

            HasMany(e => e.CityOfHomes).
              WithRequired(e => e.CityOfHome).
              HasForeignKey(e => e.CityOfHomeId).
              WillCascadeOnDelete(false);
        }
    }
}
