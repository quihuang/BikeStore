using System;
using BikeStore.App.Dominio;
using BikeStore.App.Persistencia;

namespace BikeStore.App.Consola
{
    class Program
    {

        private static IRepositorioCliente _repositorioCliente = new RepositorioCliente( new Persistencia.AppContext() );
        private static IRepositorioConstanciaRecibido _repositorioConstanciaRecibido = new RepositorioConstanciaRecibido( new Persistencia.AppContext() );
        private static IRepositorioInventario _repositorioInventario = new RepositorioInventario( new Persistencia.AppContext() );
        private static IRepositorioPersona _repositorioPersona = new RepositorioPersona( new Persistencia.AppContext() );
        private static IRepositorioProducto _repositorioProducto = new RepositorioProducto( new Persistencia.AppContext() );
        private static IRepositorioTrabajador _repositorioTrabajador = new RepositorioTrabajador( new Persistencia.AppContext() );
        private static IRepositorioUsuario _repositorioUsuario = new RepositorioUsuario( new Persistencia.AppContext() );
        private static IRepositorioVenta _repositorioVenta = new RepositorioVenta( new Persistencia.AppContext() );

        static void Main(string[] args)
        {
            // crearCliente();

            // ObtenerTodosTrabajadores();
            // crearTrabajador();
            // ActualizarTrabajador();
            // EliminarTrabajador(4);

            // ObtenerTodosProductos();
            // ObtenerProductosPorId(7);
            // ObtenerProductosPorNombre("Bicicleta marca specialized Sirrus X 3.0");
            // crearProducto();
            // ActualizarProducto(7);
            // EliminarProducto(7);

            // crearInventario();

            // crearConstanciaRecibido();

            // ObtenerTodasPersonas();
            // ObtenerPersonasPorNombre("Dario");
            // crearPersona();

            // crearVenta();
            // prueba_BuscarTrabajador(1);

        }

        // Método buscar todos los trabajadores
        public static void ObtenerTodosTrabajadores(){

            var listado = _repositorioTrabajador.GetAllTrabajadores();

            foreach (var item in listado)
            {
                Console.WriteLine("Id: " + item.Id + ", Nombre: " + item.Nombre + ", Discriminador: " + item.Discriminator + ", Salario: " + item.Salario);
            }
        }

        // Método para Crear Venta
        public static void crearVenta(){
            DateTime dateTime1 = new DateTime(2022, 09, 01, 16, 00, 00);
            DateTime dateTime2 = new DateTime(2022, 09, 02, 17, 00, 00);
            DateTime dateTime3 = DateTime.Now;

            Trabajador trabajador1 = _repositorioTrabajador.GetTrabajador(1);
            Trabajador trabajador2 = _repositorioTrabajador.GetTrabajador(2);
            Trabajador trabajador3 = _repositorioTrabajador.GetTrabajador(3);

            Cliente cliente1 = _repositorioCliente.GetCliente(1);
            Cliente cliente2 = _repositorioCliente.GetCliente(2);
            Cliente cliente3 = _repositorioCliente.GetCliente(3);

            Inventario inventario1 = _repositorioInventario.GetInventario(1);
            Inventario inventario2 = _repositorioInventario.GetInventario(2);
            Inventario inventario3 = _repositorioInventario.GetInventario(3);

            // var venta1 = new Venta{
            //     Fecha = dateTime1,
            //     CantidadProducto = 1,
            //     ValorVenta = 1,
            //     Trabajador = trabajador1,
            //     Cliente = cliente1,
            //     Inventario = inventario1
            // };
            // var venta2 = new Venta{
            //     Fecha = dateTime2,
            //     CantidadProducto = 2,
            //     ValorVenta = 2,
            //     Trabajador = trabajador2,
            //     Cliente = cliente2,
            //     Inventario = inventario2
            // };
            // var venta3 = new Venta{
            //     Fecha = dateTime3,
            //     CantidadProducto = 3,
            //     ValorVenta = 3,
            //     Trabajador = trabajador3,
            //     Cliente = cliente3,
            //     Inventario = inventario3
            // };


            // var resultInsert1 = _repositorioVenta.AddVenta(venta1);
            // var resultInsert2 = _repositorioVenta.AddVenta(venta2);
            // var resultInsert3 = _repositorioVenta.AddVenta(venta3);
            // if( resultInsert1 > 0){
            //     Console.WriteLine("Se a registrado correctamente");
            // }else{
            //     Console.WriteLine("ocurrió un error");
            // }
        }

        // Método para Crear ConstanciaRecibido
        public static void crearConstanciaRecibido(){
            Trabajador trabajador1 = _repositorioTrabajador.GetTrabajador(1);
            Trabajador trabajador2 = _repositorioTrabajador.GetTrabajador(2);
            Trabajador trabajador3 = _repositorioTrabajador.GetTrabajador(3);

            Inventario inventario1 = _repositorioInventario.GetInventario(1);
            Inventario inventario2 = _repositorioInventario.GetInventario(2);
            Inventario inventario3 = _repositorioInventario.GetInventario(3);

            DateTime dateTime1 = new DateTime(2022, 09, 01, 16, 00, 00);
            DateTime dateTime2 = new DateTime(2022, 09, 02, 17, 00, 00);
            DateTime dateTime3 = DateTime.Now;

            var constanciaRecibido1 = new ConstanciaRecibido{
                Nombre = "constanciaRecibido 1",
                Descripcion = "Descripcion 1",
                Fecha = dateTime1,
                Trabajador = trabajador1,
                Inventario = inventario1
            };
            var constanciaRecibido2 = new ConstanciaRecibido{
                Nombre = "constanciaRecibido 2",
                Descripcion = "Descripcion 2",
                Fecha = dateTime2,
                Trabajador = trabajador1,
                Inventario = inventario1
            };
            var constanciaRecibido3 = new ConstanciaRecibido{
                Nombre = "constanciaRecibido 3",
                Descripcion = "Descripcion 3",
                Fecha = dateTime3,
                Trabajador = trabajador1,
                Inventario = inventario1
            };

            var resultInsert1 = _repositorioConstanciaRecibido.AddConstanciaRecibido(constanciaRecibido1);
            var resultInsert2 = _repositorioConstanciaRecibido.AddConstanciaRecibido(constanciaRecibido2);
            var resultInsert3 = _repositorioConstanciaRecibido.AddConstanciaRecibido(constanciaRecibido3);
            if( resultInsert1 > 0){
                Console.WriteLine("Se a registrado correctamente");
            }else{
                Console.WriteLine("ocurrió un error");
            }
        }

        // Método para Crear Inventario
        public static void crearInventario(){
            Producto producto1 = _repositorioProducto.GetProducto(1);
            Producto producto2 = _repositorioProducto.GetProducto(2);
            Producto producto3 = _repositorioProducto.GetProducto(3);

            // var inventario1 = new Inventario{
            //     Producto = producto1,
            //     Existencias = 10,
            //     NumeroRefCompra = 1,
            //     PrecioUniVenta = 150,
            //     PrecioUniCompra = 100
            // };
            // var inventario2 = new Inventario{
            //     Producto = producto2,
            //     Existencias = 20,
            //     NumeroRefCompra = 2,
            //     PrecioUniVenta = 250,
            //     PrecioUniCompra = 200
            // };
            // var inventario3 = new Inventario{
            //     Producto = producto3,
            //     Existencias = 30,
            //     NumeroRefCompra = 3,
            //     PrecioUniVenta = 350,
            //     PrecioUniCompra = 300
            // };

            // var resultInsert1 = _repositorioInventario.AddInventario(inventario1);
            // var resultInsert2 = _repositorioInventario.AddInventario(inventario2);
            // var resultInsert3 = _repositorioInventario.AddInventario(inventario3);
            // if( resultInsert1 > 0){
            //     Console.WriteLine("Se a registrado correctamente");
            // }else{
            //     Console.WriteLine("ocurrió un error");
            // }
        }

        // Método para Crear Cliente
        public static void crearCliente(){
            var cliente1 = new Cliente{
                Cedula = "123123123",
                Nombre = "Cliente 1",
                Apellido = "Apellido 1",
                NumeroTelefono = "3202222222",
                Email = "email1@gmail.com",
                Direccion = "calle 1"
            };
            var cliente2 = new Cliente{
                Cedula = "234234234",
                Nombre = "Cliente 2",
                Apellido = "Apellido 2",
                NumeroTelefono = "3202222223",
                Email = "email2@gmail.com",
                Direccion = "calle 1"
            };
            var cliente3 = new Cliente{
                Cedula = "345345345",
                Nombre = "Cliente 3",
                Apellido = "Apellido 3",
                NumeroTelefono = "3202222223",
                Email = "email3@gmail.com",
                Direccion = "calle 3"
            };

            var resultInsert1 = _repositorioCliente.AddCliente(cliente1);
            var resultInsert2 = _repositorioCliente.AddCliente(cliente2);
            var resultInsert3 = _repositorioCliente.AddCliente(cliente3);
            if( resultInsert1 > 0){
                Console.WriteLine("Se a registrado correctamente");
            }else{
                Console.WriteLine("ocurrió un error");
            }
        }

        // Método para buscar todos los Productos
        public static void ObtenerTodosProductos(){

            var listadoProducto = _repositorioProducto.GetAllProductos();

            foreach (var item in listadoProducto)
            {
                Console.WriteLine("Id: " + item.Id + ", \n Nombre: " + item.Nombre + ", \n Descripcion: " + item.Descripcion);
            }
        }

        // Método para buscar Producto por id
        public static void ObtenerProductosPorId(int id){

            var item = _repositorioProducto.GetProducto(id);
                Console.WriteLine("Id: " + item.Id + ", \n Nombre: " + item.Nombre + ", \n Descripcion: " + item.Descripcion);
        }

        // Método para buscar Producto por nombre
        public static void ObtenerProductosPorNombre(string nombre){

            var listadoProducto = _repositorioProducto.GetAllProductosForName(nombre);

            foreach (var item in listadoProducto)
            {
                Console.WriteLine("Id: " + item.Id + ", \n Nombre: " + item.Nombre + ", \n Descripcion: " + item.Descripcion);
            }
        }

        // Método para Crear Producto
        public static void crearProducto(){
            var producto1 = new Producto{
                Nombre = "Bicicleta marca specialized turbo levo",
                Descripcion = "Ruedas entre 27'5\" y 29\", dirección puede ajustarse entre 63 y 65,5 grados, Supensión delantera de 160 mm y trasera de 150 mm",
            };
            var producto2 = new Producto{
                Nombre = "Bicicleta marca specialized Sirrus X 3.0",
                Descripcion = "Sirrus X is your ticket to riding more, and to places you never imagined possible. It’s a comfortable, capable, “let’s do stuff” kind of bike that will inspire you to ride more than you ever have before. With bigger, confidence inspiring tires, a slightly more upright riding position, a super intuitive one-by drivetrain, and plenty of mounts for racks and fenders —it’s more than just a solid partner on pavement…",
            };
            var producto3 = new Producto{
                Nombre = "Bicicleta marca specialized Stumpjumper Alloy",
                Descripcion = "Descripcion: The Stumpjumper Alloy brings all-new suspension kinematics and progressive geometry into a full-alloy package that's both lightweight and extremely durable. Outfitted with a no-fuss SRAM SX 12-speed groupset, the Stumpjumper Alloy is your all-access pass for trail adventure",
            };

            var resultInsert1 = _repositorioProducto.AddProducto(producto1);
            var resultInsert2 = _repositorioProducto.AddProducto(producto2);
            var resultInsert3 = _repositorioProducto.AddProducto(producto3);
            if( resultInsert1 > 0){
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

        public static void crearTrabajador(){
            var trabajador1 = new Trabajador{
                Cedula = "1111111111",
                Nombre = "Fulano",
                Apellido = "De Tal",
                NumeroTelefono = "3001112233",
                NombreUsuario = "FulanoDeTal",
                Contraseña = "passwordDeFulanodetal123#$.*",
                Rol = 1,
                Salario = 11223344
            };
            var trabajador2 = new Trabajador{
                Cedula = "2222222222",
                Nombre = "Sutano",
                Apellido = "Absalon",
                NumeroTelefono = "3102223344",
                NombreUsuario = "SutanoAbsalon",
                Contraseña = "passwordDeSutano123#$.*",
                Rol = 2,
                Salario = 55667788
            };
            var trabajador3 = new Trabajador{
                Cedula = "3333333333",
                Nombre = "Juana",
                Apellido = "De Arco",
                NumeroTelefono = "3205556677",
                NombreUsuario = "JuanaDeArco",
                Contraseña = "passwordDeJuanita123#$.*",
                Rol = 3,
                Salario = 99001122
            };
            var trabajador4 = new Trabajador{
                Cedula = "4444444444",
                Nombre = "Pedro",
                Apellido = "Perez",
                NumeroTelefono = "3308889900",
                NombreUsuario = "PedroPerez",
                Contraseña = "passwordDePedrito123#$.*",
                Rol = 3,
                Salario = 33445566
            };

            var resultInsert1 = _repositorioPersona.AddTrabajador(trabajador1);
            var resultInsert2 = _repositorioPersona.AddTrabajador(trabajador2);
            var resultInsert3 = _repositorioPersona.AddTrabajador(trabajador3);
            var resultInsert4 = _repositorioPersona.AddTrabajador(trabajador4);

            if( resultInsert1 > 0){
                Console.WriteLine("Se a registrado correctamente");
            }else{
                Console.WriteLine("ocurrió un error");
            }
        }

        public static void crearPersona(){

            Console.WriteLine("Ejecutando inserción");

            var persona1 = new Persona{
                Cedula = "1111111111",
                Nombre = "Franklin",
                Apellido = "Quihuang",
                NumeroTelefono = "3205282231"
            };

            var persona2 = new Persona{
                Cedula = "2222222222",
                Nombre = "Dairo",
                Apellido = "Camacho",
                NumeroTelefono = "3201112233"
            };

            var persona3 = new Persona{
                Cedula = "3333333333",
                Nombre = "Briham",
                Apellido = "Sterling",
                NumeroTelefono = "3204445566"
            };

            var persona4 = new Persona{
                Cedula = "4444444444",
                Nombre = "Jose Stiven",
                Apellido = "Diaz",
                NumeroTelefono = "3207778899"
            };

           var resultInsert1 = _repositorioPersona.AddPersona(persona1);
           var resultInsert2 = _repositorioPersona.AddPersona(persona2);
           var resultInsert3 = _repositorioPersona.AddPersona(persona3);
           var resultInsert4 = _repositorioPersona.AddPersona(persona4);

           if( resultInsert1 > 0){
            Console.WriteLine("Se a registrado correctamente");
           }else{
            Console.WriteLine("ocurrió un error");
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

        public static void prueba_BuscarTrabajador(int id){
            var trabajador = _repositorioPersona.Buscar(2);
            if( trabajador != null){
                Console.WriteLine("Encontró al trabajador");
                Console.WriteLine("id= ", trabajador.Id, ", Nombre= ", trabajador.Nombre);
            }else{
                Console.WriteLine("trabajador no existe");
            }
        }

        public static void ActualizarTrabajador(int id){

            var trabajador = _repositorioPersona.Buscar(id);

            if( trabajador != null){

                Console.WriteLine("Encontró al trabajador");

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
