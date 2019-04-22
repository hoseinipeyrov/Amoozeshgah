
using Amoozeshgah.Domain.Entities;
using System;
using System.Data.Entity;

namespace Amoozeshgah.Core.Infrastructure
{
    public interface IDbContext : IDisposable
    {
        DbSet<PageTrack> PageTracks { get; set; }
        DbSet<AuditEntry> AuditEntries { get; set; }
        DbSet<AuditEntryProperty> AuditEntryProperties { get; set; }
        DbSet<T> Set<T>() where T : BaseEntity;
        int SaveChanges();
    }

}
