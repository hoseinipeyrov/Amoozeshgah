using Amoozeshgah.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Amoozeshgah.Core.Mapping
{
    public class PageTrackMap : EntityTypeConfiguration<PageTrack>
    {
        public PageTrackMap()
        {
            //Key
            HasKey(t => t.Id);

            //Properties

            //Table
            ToTable("PageTracks");
        }
    }
}
