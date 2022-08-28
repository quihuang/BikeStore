using System;

namespace BikeStore.App.Dominio
{   
    public class Cliente : Persona
    {
        public int Id { get; set; }
        public String Email { get; set; }
        public String Direccion { get; set; }
    }
}
