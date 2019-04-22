using System;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Data.Entity.ModelConfiguration;
using Amoozeshgah.Domain.Entities;
using EntityFramework.Audit;


namespace Amoozeshgah.Core.Infrastructure
{
    public sealed class AppContext : DbContext, IDbContext
    {
        public DbSet<PageTrack> PageTracks { get; set; }
        public  DbSet<AuditEntry> AuditEntries { get; set; }
        public  DbSet<AuditEntryProperty> AuditEntryProperties { get; set; }
        //private AuditLogger auditLogger;
        public AppContext()
            : base("name=cnn")
        {
            this.Configuration.LazyLoadingEnabled = false;
            Database.SetInitializer<AppContext>(null);
            // AuditConfiguration.Default.DefaultAuditable = true;
            //  auditLogger = this.BeginAudit();

            //   Database.SetInitializer<AppContext>(new CreateDatabaseIfNotExists<AppContext>());

            //  Database.SetInitializer<AppContext>(new DropCreateDatabaseIfModelChanges<AppContext>());
            //  Database.SetInitializer<AppContext>(new DropCreateDatabaseAlways<AppContext>());
            // Database.SetInitializer<AppContext>(new AppContextDBInitializer());

        }
        //public override int SaveChanges()
        //{
        //    var changeCount = base.SaveChanges();
        //    var lastLog = auditLogger.LastLog;

        //    //
        //    // Save AuditLog to file or database....
        //    //

        //    return changeCount;
        //}
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
            .Where(type => !string.IsNullOrEmpty(type.Namespace))
            .Where(type => type.BaseType != null && type.BaseType.IsGenericType && type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));
            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }
            base.OnModelCreating(modelBuilder);
        }
        public new DbSet<T> Set<T>() where T : BaseEntity
        {
            return base.Set<T>();
        }
    }
}
