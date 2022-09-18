using System;
//using System.Web.Script.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BikeStore.App.Dominio;
using BikeStore.App.Persistencia;
using System.Collections;
//dotnet add reference ..\System.Web.Script.Serialization\
namespace BikeStore.App.Web.Pages
{
    public class VentasModel : PageModel
    {
        // video 02/09 min 2:30:20 y en el minuto 2:41:27
        // Instanciar el repositorio, igual como se hizo en la capa Consola
        private IRepositorioVenta _repositorioVenta = new RepositorioVenta( new BikeStore.App.Persistencia.AppContext() );
        private IRepositorioTrabajador _repositorioTrabajador = new RepositorioTrabajador( new BikeStore.App.Persistencia.AppContext() );
        private IRepositorioCliente _repositorioCliente = new RepositorioCliente( new BikeStore.App.Persistencia.AppContext() );
        private IRepositorioInventario _repositorioInventario = new RepositorioInventario( new BikeStore.App.Persistencia.AppContext() );
        private IRepositorioProducto _repositorioProducto = new RepositorioProducto( new BikeStore.App.Persistencia.AppContext() );

        // video 02/09 min 2:49:30
        // crear una variable tipo List que reciba la totalidad de los registros consultados de la DB, debe ser público para que la interface gráfica pueda acceder a él
        public List<Venta> listadoVenta { get; set; }
        public List<Trabajador> listadoTrabajador { get; set; }
        public List<Cliente> listadoCliente { get; set; }
        public List<Inventario> listadoInventario { get; set; }
        public Producto producto { get; set; }
        public List<Producto> listadoProductos { get; set; }
        DateTime fechaActual = DateTime.Now;

        public string mensaje;


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

            listadoInventario = new List<Inventario>();
            listadoInventario = _repositorioInventario.GetAllInventarios().ToList();

            listadoProductos = new List<Producto>();
            listadoProductos = _repositorioProducto.GetAllProductos().ToList();

            // PARA MOSTRAR UN MENSAJE - PENDIENTE POR PROBAR
            if(ViewData["mensaje"] != null){
                mensaje = ViewData["mensaje"].ToString();
            } else {
                mensaje = "";
            }
        }


        // video 02/09 min 2:09:20
        // // METODO PARA POST DE CREAR
        public IActionResult OnPost()
        {
            var inventario = Request.Form["inventario"];
            var cantidadProducto = Request.Form["cantidadProducto"];
            var inventarioUpdate = _repositorioInventario.GetInventario(int.Parse(inventario));
            Double restaInventario = inventarioUpdate.Existencias - Double.Parse(cantidadProducto);

            if(restaInventario > 0){
                // aquí se debe poner entre [] el nombre de cada campo del formulario
                var fecha = fechaActual;
                var trabajador = Request.Form["trabajador"];
                var cliente = Request.Form["cliente"];        

                Double valorVentaCal = inventarioUpdate.PrecioUniVenta * Double.Parse(cantidadProducto);

                Console.WriteLine("restaInventario : " + restaInventario);
                Console.WriteLine("valorVenta : " + valorVentaCal);
                Console.WriteLine("inventarioUpdate : " + inventarioUpdate.Id);

                inventarioUpdate.Existencias = (int) restaInventario;
    
                var resultInventario = _repositorioInventario.UpdateInventario(inventarioUpdate);

                // Creamos el objeto Venta y le pasamos los datos del formulario
                var venta = new Venta{
                    Fecha = fecha,
                    CantidadProducto = int.Parse(cantidadProducto),
                    ValorVenta = (int) valorVentaCal,
                    TrabajadorId = int.Parse(trabajador),
                    ClienteId = int.Parse(cliente),
                    InventarioId = int.Parse(inventario)
                };

                // video 02/09 min 2:23:15
                // llamamos el método del Repositorio y le pasamos por parámetro el objeto que acabamos de crear, y el resultado del método lo almacenamos en la variable result.
            
                var result = _repositorioVenta.AddVenta(venta);

                // video del 09/09 min 2:53:00
                if( result > 0){
                    mensaje = "Creación realizada con éxito";
                    return RedirectToPage();
                }else{
                    mensaje = "Falla en el método de creación";
                    return RedirectToPage("Error");
                }

            }else{
                mensaje = "No hay inventario disponible";
                return RedirectToPage("Error");
            }

        }


        // // METODO PARA POST DE ACTUALIZAR MEDIANTE AJAX CON JSON
        public IActionResult OnPostUpdateJson([FromBody]Venta venta)
        {
            var ventaResult = _repositorioVenta.GetVenta( venta.Id );

            var mensaje = "";

            if( ventaResult != null)
            {
                ventaResult.CantidadProducto = venta.CantidadProducto;
                ventaResult.ValorVenta = venta.ValorVenta;
                ventaResult.TrabajadorId = venta.TrabajadorId;
                ventaResult.ClienteId = venta.ClienteId;
                ventaResult.InventarioId = venta.InventarioId;

                var result = _repositorioVenta.UpdateVenta(ventaResult);

                if( result > 0){
                    mensaje = "Se actualizó correctamente";
                }else{
                    mensaje = "No se pudo actualizar";
                }

            }else{
                mensaje = "La consulta no encontró ningún registro";
            }

            return Content(mensaje);
        } 


        // // METODO PARA POST DE ELIMINAR MEDIANTE AJAX CON JSON
        public IActionResult OnPostDeleteJson([FromBody]Venta venta)
        {
            var ventaResult = _repositorioVenta.GetVenta( venta.Id );

            var mensaje = "";

            if( ventaResult != null)
            {
                var result = _repositorioVenta.DeleteVenta(ventaResult);

                if( result > 0){
                    mensaje = "Se eliminó correctamente";
                }else{
                    mensaje = "No se pudo eliminar";
                }

            }else{
                mensaje = "La consulta no encontró ningún registro";
            }

            return Content(mensaje);
        }
    }
}
