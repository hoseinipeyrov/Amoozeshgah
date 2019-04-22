using Amoozeshgah.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Amoozeshgah.Core.Mapping
{
    public class MenuMap : EntityTypeConfiguration<Menu>
    {
        public MenuMap()
        {
            //Key
            HasKey(t => t.Id);

            //Properties
            //Property(l => l.IsDisable).HasColumnType("bit").IsRequired();
            //Table
            ToTable("Menus");
        }
    }
    public class MenuItemMap : EntityTypeConfiguration<MenuItem>
    {
        public MenuItemMap()
        {
            //Key
            HasKey(t => t.Id);

            //Properties

            //Table
            ToTable("MenuItems");
        }
    }
}
