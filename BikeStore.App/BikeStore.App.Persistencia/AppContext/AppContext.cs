using System;
using BikeStore.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace BikeStore.App.Persistencia
{
    public class AppContext : DbContext
    {
        public Dbset<Persona> Personas { get; set; }
        public Dbset<Comercial> Comerciales { get; set; }

        protected override void OnConfiguring(DbContexOptionBuilder optionsBuilder){
            if(!optionsBuilder.IsConfigured){
                optionsBuilder
                .UseSqlServer();
            }
        }
    }
}
