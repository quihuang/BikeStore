using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BikeStore.App.Dominio;
using BikeStore.App.Persistencia;

namespace BikeStore.App.Web.Pages
{
    public class VentasModel : PageModel
    {
        // video 02/09 min 2:30:20 y en el minuto 2:41:27
        // Instanciar el repositorio, igual como se hizo en la capa Consola
        private IRepositorioVenta _repositorioVenta = new RepositorioVenta( new BikeStore.App.Persistencia.AppContext() );
        private IRepositorioTrabajador _repositorioTrabajador = new RepositorioTrabajador( new BikeStore.App.Persistencia.AppContext() );
        private IRepositorioCliente _repositorioCliente = new RepositorioCliente( new BikeStore.App.Persistencia.AppContext() );

        // video 02/09 min 2:49:30
        // crear una variable tipo List que reciba la totalidad de los registros consultados de la DB, debe ser público para que la interface gráfica pueda acceder a él
        public List<Venta> listadoVenta { get; set; }
        public List<Trabajador> listadoTrabajador { get; set; }
        public List<Cliente> listadoCliente { get; set; }
        DateTime fechaActual = DateTime.Now;

        public void OnGet()
        {
            // Método para listar todas las Ventas y mostrarlas en la tabla
            listadoVenta = new List<Venta>(); // se instancia vacío
            listadoVenta = _repositorioVenta.GetAllVentas().ToList();

            // Método para listar los trabajadores y mostrarlos en una lista desplegable en la ventana Modal de Crear Venta
            listadoTrabajador = new List<Trabajador>(); // se instancia vacío
            listadoTrabajador = _repositorioTrabajador.GetAllTrabajadores().ToList();

            // Método para listar los trabajadores y mostrarlos en una lista desplegable en la ventana Modal de Crear Venta
            listadoCliente = new List<Cliente>();
            listadoCliente = _repositorioCliente.GetAllClientes().ToList();

        }

        // video 02/09 min 2:09:20
        // // Método para capturar el Post del formulario
        public void OnPost()
        {
            // aquí se debe poner entre [] el nombre de cada campo del formulario
            var Fecha = fechaActual;
            // var cantidadProducto = Request.Form["cantidadProducto"]; // ! Error: al capturar el dato, lo recibe string
            // var valorVenta = Request.Form["valorVenta"]; // ! Error: al capturar el dato, lo recibe string
            var trabajador = Request.Form["trabajador"];
            var cliente = Request.Form["cliente"];
            var inventario = Request.Form["inventario"];

            // // Creamos el objeto Venta y le pasamos los datos del formulario
            var venta = new Venta
            {
                // CantidadProducto = cantidadProducto, // ! Error: debe ser un Entero
                // ValorVenta = valorVenta,    // ! Error: debe ser un Entero
                // Trabajador = trabajador,    // ! Error: debe ser un tipo Objeto
                // Cliente = cliente,       // ! Error: debe ser un tipo Objeto
                // Inventario = inventario  // ! Error: debe ser un tipo Objeto
            };

            // video 02/09 min 2:23:15
            // llamamos el método del Repositorio y le pasamos por parámetro el objeto que acabamos de crear, y el resultado del método lo almacenamos en la variable result.
            var result = _repositorioVenta.AddVenta(venta);
            if( result > 0){
                Console.WriteLine("Se creó con éxito el venta");
            }else{
                Console.WriteLine("Falló el registro de la venta");
            }
        }
    }
}
