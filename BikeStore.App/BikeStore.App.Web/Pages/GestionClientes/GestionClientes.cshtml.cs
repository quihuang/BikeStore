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
    public class GestionClientesModel : PageModel
    {
        // video 02/09 min 2:30:20 y en el minuto 2:41:27
        // Instanciar el repositorio, igual como se hizo en la capa Consola
        private IRepositorioCliente _repositorioCliente = new RepositorioCliente( new Persistencia.AppContext() );

        // video 02/09 min 2:49:30
        // crear una variable tipo List que reciba la totalidad de los registros consultados de la DB, debe ser público para que la interface gráfica pueda acceder a él
        public List<Cliente> listadoCliente { get; set; }
        
        public void OnGet()
        {
            // video 02/09 min 2:50:22
            // debo inicializar el objeto listadoProducto dentro de OnGet para que lo pueda interpretar
            listadoCliente = new List<Cliente>(); // se instancia vacío
            listadoCliente = _repositorioCliente.GetAllClientes().ToList();
        }

        // // Método para capturar el Post del formulario
        public void OnPost(){

            var cedula = Request.Form["cedula"];
            var nombre = Request.Form["nombre"];
            var apellido = Request.Form["apellido"];
            var numeroTelefono = Request.Form["numeroTelefono"];
            var email = Request.Form["email"];
            var direccion = Request.Form["direccion"];

            // // Creamos el objeto y le pasamos los datos del formulario
            var cliente = new Cliente{
                Cedula = cedula,
                Nombre = nombre,
                Apellido = apellido,
                NumeroTelefono = numeroTelefono,
                Email = email,
                Direccion = direccion
            };

            // video 02/09 min 2:23:15
            // llamamos el método del Repositorio y le pasamos por parámetro el objeto que acabamos de crear, y el resultado del método lo almacenamos en la variable result.
            var result = _repositorioCliente.AddCliente(cliente);
            if( result > 0){
                Console.WriteLine("Se creó con éxito el Usuario");
            }else{
                Console.WriteLine("Se creó con éxito el Usuario");
            }
        }
    }
}
