using System;
using BikeStore.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace BikeStore.App.Persistencia
{
    public class AppContext : DbContext
    {
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Comercial> Comerciales { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            if(!optionsBuilder.IsConfigured){
                optionsBuilder
                .UseSqlServer("Server=HP-PAVILION-GAM; Database=testProyects; Integrated Security=True;");
            }
        }
    }
}
