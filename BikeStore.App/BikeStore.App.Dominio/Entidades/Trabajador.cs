using System;

namespace BikeStore.App.Dominio
{
    public class Trabajador : Usuario
    {
        public int Id { get; set; }
        public int Salario { get; set; }
        public string Discriminator { get; set; }
    }
}
