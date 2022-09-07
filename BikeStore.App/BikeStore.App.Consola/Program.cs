using System;
using BikeStore.App.Dominio;
using BikeStore.App.Persistencia;

namespace BikeStore.App.Consola
{
    class Program
    {

        private static IRepositorioPersona _repositorioPersona = new RepositorioPersona( new Persistencia.AppContext() );
        private static IRepositorioProducto _repositorioProducto = new RepositorioProducto( new Persistencia.AppContext() );

        static void Main(string[] args)
        {
            crearProducto();
            // ObtenerTodosProductos();
            // ObtenerProductosPorNombre("Bicicleta marca specialized Sirrus X 3.0");
            // ActualizarProducto(7);
            // ObtenerProductosPorId(7);
            // EliminarProducto(7);

           //crearTrabajador();
           //ObtenerTodasPersonas();
           //ObtenerPersonasPorNombre("Dario");
           //ActualizarTrabajador();
           //EliminarTrabajador(4);
        }

        // Método para buscar todos los registros
        public static void ObtenerTodosProductos(){

            var listadoProducto = _repositorioProducto.GetAllProducto();

            foreach (var item in listadoProducto)
            {
                Console.WriteLine("Id: " + item.Id + ", \n Nombre: " + item.Nombre + ", \n Descripcion: " + item.Descripcion);
            }
        }

        // Método para buscar por id
        public static void ObtenerProductosPorId(int id){

            var item = _repositorioProducto.GetProducto(id);
                Console.WriteLine("Id: " + item.Id + ", \n Nombre: " + item.Nombre + ", \n Descripcion: " + item.Descripcion);
        }

        // Método para buscar por nombre
        public static void ObtenerProductosPorNombre(string nombre){

            var listadoProducto = _repositorioProducto.GetAllProductosForName(nombre);

            foreach (var item in listadoProducto)
            {
                Console.WriteLine("Id: " + item.Id + ", \n Nombre: " + item.Nombre + ", \n Descripcion: " + item.Descripcion);
            }
        }

        // Método para Crear un Producto
        public static void crearProducto (){
            var producto = new Producto{
                Nombre = "Bicicleta marca specialized Stumpjumper Alloy",
                Descripcion = "Descripcion: The Stumpjumper Alloy brings all-new suspension kinematics and progressive geometry into a full-alloy package that's both lightweight and extremely durable. Outfitted with a no-fuss SRAM SX 12-speed groupset, the Stumpjumper Alloy is your all-access pass for trail adventure",
            };

            var result = _repositorioProducto.AddProducto(producto);
            if( result > 0){
                Console.WriteLine("Se a registrado correctamente");
            }else{
                Console.WriteLine("ocurrió un error");
            }
        }

        // Método para Actualizar un Producto
        public static void ActualizarProducto(int id){

            var item = _repositorioProducto.GetProducto(id);

            if( item != null){
                Console.WriteLine("la búsqueda fué exitosa");

                item.Nombre = "Bicicleta Editada por consola.";
                item.Descripcion = "Descripcion editada por consola.";

                var result = _repositorioProducto.UpdateProducto(item);
                if( result > 0){
                    Console.WriteLine("la actualización fué exitosa");
                }else{
                    Console.WriteLine("ocurrió un error en el método de Actualización");
                }
            }else{
                Console.WriteLine("la búsqueda no tuvo éxito, verifique que el Id existe");
            }
        }

        // Método para Eliminar un Producto
        public static void EliminarProducto(int id){

            var item = _repositorioProducto.GetProducto(id);

            if( item != null){
                Console.WriteLine("la búsqueda fué exitosa");

                var result = _repositorioProducto.DeleteProducto(item);
                if( result > 0){
                    Console.WriteLine("la eliminación fué exitosa");
                }else{
                    Console.WriteLine("ocurrió un error en el método de eliminación");
                }
            }else{
                Console.WriteLine("a búsqueda no tuvo éxito, verifique que el Id existe");
            }
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
