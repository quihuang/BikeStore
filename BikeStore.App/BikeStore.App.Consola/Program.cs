using System;
using BikeStore.App.Dominio;
using BikeStore.App.Persistencia;

namespace BikeStore.App.Consola
{
    class Program
    {

        private static IRepositorioPersona _repositorioPersona = new RepositorioPersona( new Persistencia.AppContext() );

        static void Main(string[] args)
        {
            Console.WriteLine("Ejecutando insercion");

            var persona = new Persona{
                Cedula = "1144213155",
                Nombre = "Franklin",
                Apelido = "Quihuang",
                NumeroTelefono = "3205282231",
                Genero = 0
            };

           var resultInsert = _repositorioPersona.AddPersona(persona);

           if( resultInsert > 0){
            Console.WriteLine("Se a registrado correctamente");
           }else{
            Console.WriteLine("ocurrio un error");
           }
        }
    }
}
