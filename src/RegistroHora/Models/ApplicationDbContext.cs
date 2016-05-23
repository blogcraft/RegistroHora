using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using RegistroHora.Models;

namespace RegistroHora.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            // Cambia el nombre para que se llame Usuarios en vez de AspNetUsers
            //builder.Entity<IdentityUser>()
            //    .ToTable("Usuarios");
            //builder.Entity<ApplicationUser>()
            //    .ToTable("Usuarios");
            //builder.Entity<Cliente>(b => b.HasKey(k => k.ClienteId));
            builder.Entity<Proyecto>().HasOne(m => m.TipoProyecto).WithMany().HasForeignKey(m=> m.TipoProyectoId).OnDelete(DeleteBehavior.SetNull);

        }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Proyecto> Proyectos { get; set; }
        public DbSet<TipoProyecto> TiposProyecto { get; set; }
        public DbSet<Registro> Registros { get; set; }
    }
}
