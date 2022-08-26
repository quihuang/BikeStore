using System;

namespace BikeStore.App.Dominio
{
    public class Persona
    {
        public String Cedula { get; set; }
        public String Nombre { get; set; }
        public String Apelido { get; set; }
        public String NumeroTelefono { get; set; }
        public Genero Genero { get; set; }
    }
}
