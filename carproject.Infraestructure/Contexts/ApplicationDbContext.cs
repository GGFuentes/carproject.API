using carproject.Domain.Entities;
using carproject.Infraestructure.Configuration;
using Microsoft.EntityFrameworkCore;

namespace carproject.Infraestructure.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<MarcasAutos> MarcasAutos { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
       : base(options)
        {
        }       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new MarcasAutosConfiguration());

            // Data Seed: se cargarán automáticamente al aplicar migraciones
            modelBuilder.Entity<MarcasAutos>().HasData(
                new MarcasAutos { Id = 1, Brand = "Toyota", Model = "Hilux", Year = 2023, Price = 35000 },
                new MarcasAutos { Id = 2, Brand = "Ford", Model = "Raptor", Year = 2022, Price = 55000 },
                new MarcasAutos { Id = 3, Brand = "Hyundai", Model = "Tucson", Year = 2021, Price = 28000 }
            );

            base.OnModelCreating(modelBuilder);
           
        }
      
    }
}
