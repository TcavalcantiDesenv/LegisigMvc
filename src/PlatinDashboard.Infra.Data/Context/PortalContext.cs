using PlatinDashboard.Domain.Entities;
using PlatinDashboard.Infra.Data.EntityConfig;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace PlatinDashboard.Infra.Data.Context
{
    public class PortalContext : DbContext
    {
        public PortalContext() : base("PortalConnection")
        {
            Database.SetInitializer<PortalContext>(null);
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Validadores> Validadores { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<UserClaim> UserClaims { get; set; }
        public DbSet<Chart> Charts { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<UserStore> UsersStores { get; set; }
        //public DbSet<LegisGeral> LegisGeral { get; set; }
        //public DbSet<Parametros> Parametros { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(255));

            modelBuilder.Configurations.Add(new CompanyConfiguration());
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new UserClaimConfiguration());
            modelBuilder.Configurations.Add(new ChartConfiguration());
            modelBuilder.Configurations.Add(new VideoConfiguration());
            modelBuilder.Configurations.Add(new StoreConfiguration());
            modelBuilder.Configurations.Add(new UserStoreConfiguration());
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("CreatedAt") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("CreatedAt").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("CreatedAt").IsModified = false;
                }
            }

            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("UpdatedAt") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("UpdatedAt").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("UpdatedAt").CurrentValue = DateTime.Now;
                }
            }
            try
            {
                return base.SaveChanges();
            }
            catch (Exception e)
            {
                var erro = e.Message;
                throw new Exception();
            }
        }

    }
}
