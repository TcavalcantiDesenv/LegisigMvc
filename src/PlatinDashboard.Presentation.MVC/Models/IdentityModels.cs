using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Model.Entity;
using PlatinDashboard.Presentation.MVC.ModelConfiguration;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PlatinDashboard.Presentation.MVC.Models
{
    public class IdentityModels
    {
        public class ApplicationUser : IdentityUser
        {
            public bool Ativo { get; set; }
            public DateTime WhenCreated { get; set; }
            public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
            {
                // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
                var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
                // Add custom user claims here
                return userIdentity;
            }
        }

        public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
        {
            public ApplicationDbContext()
                : base("ConnectionString", throwIfV1Schema: false)
            {
               // PortalConnection
            }

            public DbSet<LegisGeral> LegisGeral { get; set; }
            public DbSet<Parametros> Parametros { get; set; }
            public DbSet<ParametrosCliente> ParametrosCliente { get; set; }
            public DbSet<LeisClientes> LeisClientes { get; set; }
            public DbSet<Conformidade> Conformidade { get; set; }
            public DbSet<PlanoAcao> PlanoAcao { get; set; }
            public DbSet<LegisClientes> LegisClientes { get; set; }
            public DbSet<Empresas> Empresas { get; set; }

            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
                modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
                modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

                modelBuilder.Configurations.Add(new LegisGeralConfiguration());
                modelBuilder.Configurations.Add(new ParametrosConfiguration());
                modelBuilder.Configurations.Add(new LeisClientesConfiguration());
                modelBuilder.Configurations.Add(new ConformidadeConfiguration());
                modelBuilder.Configurations.Add(new PlanoAcaoConfiguration());
                modelBuilder.Configurations.Add(new LegisClientesConfiguration());
                modelBuilder.Configurations.Add(new EmpresasConfiguration());

                base.OnModelCreating(modelBuilder);
            }

            public static ApplicationDbContext Create()
            {
                return new ApplicationDbContext();
            }

            public override int SaveChanges()
            {
                try
                {
                    return base.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }
    }
}