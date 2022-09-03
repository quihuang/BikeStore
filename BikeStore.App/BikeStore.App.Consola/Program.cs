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
           crearTrabajador();
           //ObtenerTodasPersonas();
           //ObtenerPersonasPorNombre("Dario");
           //ActualizarTrabajador();
           //EliminarTrabajador(4);
        }

        public static void crearTrabajador (){
            var trabajador = new Trabajador{
                Cedula = "00000",
                Nombre = "Gabrial",
                Apellido = "Zapaata",
                NumeroTelefono = "sdad",
                NombreUsuario = "Stesadasasdrling",
                Contraseña = "adlajdnawanw",
                Rol = 2,
                Salario = 4324324
            };

            var resultInsert = _repositorioPersona.AddTrabajador(trabajador);

            if( resultInsert > 0){
                Console.WriteLine("Se a registrado correctamente");
            }else{
                Console.WriteLine("ocurrio un error");
            }
        }

        public static void crearPersona (){

            Console.WriteLine("Ejecutando insercion");

            var persona = new Persona{
                Cedula = "1144213155",
                Nombre = "Franklin",
                Apellido = "Quihuang",
                NumeroTelefono = "3205282231"
            };

           var resultInsert = _repositorioPersona.AddPersona(persona);

           if( resultInsert > 0){
            Console.WriteLine("Se a registrado correctamente");
           }else{
            Console.WriteLine("ocurrio un error");
           }

        }

        public static void ObtenerTodasPersonas(){
            var listadoPersona = _repositorioPersona.GetAllPersonas();

            foreach (var persona in listadoPersona)
            {
                Console.WriteLine("Id: " + persona.Id + ", Nombre: " + persona.Nombre + ",Apellido: " + persona.Apellido);
            }
        }


        public static void ObtenerPersonasPorNombre(string nombre){

            var listadoPersona = _repositorioPersona.GetAllPersonasForName(nombre);

            foreach (var persona in listadoPersona)
            {
                Console.WriteLine("Id: " + persona.Id + ", Nombre: " + persona.Nombre + ",Apellido: " + persona.Apellido);
            }

        }

        public static void ActualizarTrabajador(int id){

            var trabajador = _repositorioPersona.Buscar(4);

            if( trabajador != null){

                Console.WriteLine("Encontro al trabajador");

                trabajador.NumeroTelefono = "00000000";
                trabajador.Apellido = "Guzman";

                _repositorioPersona.ActualizarTrabajador(trabajador);
            }else{
                Console.WriteLine("trabajador no existe");
            }
        }

        public static void EliminarTrabajador(int idTrabajador){

            var trabajador = _repositorioPersona.Buscar(idTrabajador);

            if( trabajador != null){

                Console.WriteLine("Encontro al trabajador");
                _repositorioPersona.EliminarTrabajador(trabajador);
            }else{
                Console.WriteLine("trabajador no existe");
            }
        }
    }
}
