using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BikeStore.App.Dominio;
using BikeStore.App.Persistencia;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Session;

namespace BikeStore.App.Web.Pages
{
    public class GestionClientesModel : PageModel
    {
        public string _sessionIdUser = "_IdUser";
        public string _sessionIdRol = "_idRol";
        public IHttpContextAccessor _httpContextAccessor;
        public string rolValidateSession;

        public GestionClientesModel(ILogger<GestionClientesModel> logger, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        // video 02/09 min 2:30:20 y en el minuto 2:41:27
        // Instanciar el repositorio, igual como se hizo en la capa Consola
        private IRepositorioCliente _repositorioCliente = new RepositorioCliente( new Persistencia.AppContext() );

        // video 02/09 min 2:49:30
        // crear una variable tipo List que reciba la totalidad de los registros consultados de la DB, debe ser público para que la interface gráfica pueda acceder a él
        public List<Cliente> listadoCliente { get; set; }

        public string mensaje;
        
        public IActionResult OnGet()
        {

            var userValidateSession = _httpContextAccessor.HttpContext.Session.GetString(_sessionIdUser);
            rolValidateSession = _httpContextAccessor.HttpContext.Session.GetString(_sessionIdRol);

            if( string.IsNullOrEmpty(userValidateSession) || string.IsNullOrEmpty(rolValidateSession))
            {

                return RedirectToPage("/Error");
            
            }else if(rolValidateSession == "1" || rolValidateSession == "2"){

                 // video 02/09 min 2:50:22
                // debo inicializar el objeto listado____ dentro de OnGet para que lo pueda interpretar
                listadoCliente = new List<Cliente>(); // se instancia vacío
            
                // llenamos la variable listado____ a traves del método GetAll____()
                // al final se usa el método ToList para convertir a Lista el IEnumerable que genera el método GetAll____.
                listadoCliente = _repositorioCliente.GetAllClientes().ToList();

                // PARA MOSTRAR UN MENSAJE - PENDIENTE POR PROBAR
                if(ViewData["mensaje"] != null){
                    mensaje = ViewData["mensaje"].ToString();
                } else {
                    mensaje = "";
                }

                return Page();

            }else{

                return RedirectToPage("/Error");

            }
           
        }

        // video 02/09 min 2:09:20
        // // METODO PARA POST DE CREAR
        public IActionResult OnPost(){

            var cedula = Request.Form["cedula"];
            var nombre = Request.Form["nombre"];
            var apellido = Request.Form["apellido"];
            var numeroTelefono = Request.Form["numeroTelefono"];
            var email = Request.Form["email"];
            var direccion = Request.Form["direccion"];

            // Creamos el objeto y le pasamos los datos del formulario
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

            // video del 09/09 min 2:53:00
            if( result > 0){
                mensaje = "Creación realizada con éxito";
                return RedirectToPage();
            }else{
                mensaje = "Falla en el método de creación";
                return RedirectToPage("Error");
            }
        }


        // // METODO PARA POST DE ACTUALIZAR MEDIANTE AJAX CON JSON
        public IActionResult OnPostUpdateJson([FromBody]Cliente cliente)
        {
            var clienteResult = _repositorioCliente.GetCliente( cliente.Id );

            var mensaje = "";

            if( clienteResult != null){

                clienteResult.Cedula = cliente.Cedula;
                clienteResult.Nombre = cliente.Nombre;
                clienteResult.Apellido = cliente.Apellido;
                clienteResult.NumeroTelefono = cliente.NumeroTelefono;
                clienteResult.Email = cliente.Email;
                clienteResult.Direccion = cliente.Direccion;

                var result = _repositorioCliente.UpdateCliente(clienteResult);

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
        public IActionResult OnPostDeleteJson([FromBody]Cliente cliente)
        {
            var clienteResult = _repositorioCliente.GetCliente( cliente.Id );

            var mensaje = "";

            if( clienteResult != null){

                var result = _repositorioCliente.DeleteCliente(clienteResult);

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
