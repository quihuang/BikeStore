using System;
using BikeStore.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace BikeStore.App.Persistencia
{
    public class AppContext : DbContext
    {
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Trabajador> Trabajadores { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<ConstanciaRecibido> ConstanciaRecibidos { get; set; }
        public DbSet<Inventario> Inventarios { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Venta> Venta { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            if(!optionsBuilder.IsConfigured){
                optionsBuilder
                .UseSqlServer("Server=HP-PAVILION-GAM; Database=BikeStoresDB; Integrated Security=True;");
                // .UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = BikeStoresDB");
                // No borrar: los dos comandos para crear la migración con Entity Framework:
                // dotnet ef migrations add BikeStoreDB --startup-project ..\BikeStore.App.Consola\
                // dotnet ef database update --startup-project ..\BikeStore.App.Consola\
                // Nota: si es una nueva migración, primero debe borrar el contenido de la carpeta Migrations que está dentro de BikeStore.App.Persistencia
            }
        }
    }
}
