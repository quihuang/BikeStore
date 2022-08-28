using System;

namespace BikeStore.App.Dominio
{
    public class Usuario : Persona
    {
        public int Id { get; set; }
        public String Usuario { get; set; }
        public String Contraseña { get; set; }
        public int Rol { get; set; }
    }
}
