using System;
using BikeStore.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace BikeStore.App.Persistencia
{
    public class AppContext : DbContext
    {
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Comercial> Comerciales { get; set; }
        public DbSet<Bodeguero> Bodegueros { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<ConstanciaRecibido> ConstanciaRecibidos { get; set; }
        public DbSet<Inventario> Inventarios { get; set; }
        public DbSet<JefeOperativo> JefeOperativos { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Venta> Venta { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            if(!optionsBuilder.IsConfigured){
                optionsBuilder
                .UseSqlServer("Server=HP-PAVILION-GAM; Database=BikeStoresDB; Integrated Security=True;");
            }
        }
    }
}
