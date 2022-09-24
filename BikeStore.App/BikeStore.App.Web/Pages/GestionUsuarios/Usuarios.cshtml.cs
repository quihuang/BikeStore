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

namespace BikeStore.App.Web
{
    public class UsuariosModel : PageModel
    {
        // private readonly ILogger<UsuariosModel> _logger;
        public string _sessionIdUser = "_IdUser";
        public string _sessionIdRol = "_idRol";
        public IHttpContextAccessor _httpContextAccessor;
        public string rolValidateSession;

        public UsuariosModel(ILogger<UsuariosModel> logger, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        // video 02/09 min 2:30:20 y en el minuto 2:41:27
        // Instanciar el repositorio, igual como se hizo en la capa Consola
        private IRepositorioTrabajador _repositorioTrabajador = new RepositorioTrabajador( new Persistencia.AppContext() );


        // video 02/09 min 2:49:30
        // crear una variable tipo List que reciba la totalidad de los registros consultados de la DB, debe ser público para que la interface gráfica pueda acceder a él
        public List<Trabajador> listadoTrabajador { get; set; }

        public string mensaje;

        public IActionResult OnGet()
        {
            var userValidateSession = _httpContextAccessor.HttpContext.Session.GetString(_sessionIdUser);
            rolValidateSession = _httpContextAccessor.HttpContext.Session.GetString(_sessionIdRol);

            if( string.IsNullOrEmpty(userValidateSession) || string.IsNullOrEmpty(rolValidateSession))
            {
            return RedirectToPage("/Error");

            }else if(rolValidateSession == "2"){
                // video 02/09 min 2:50:22
                // debo inicializar el objeto listado_____ dentro de OnGet para que lo pueda interpretar
                listadoTrabajador = new List<Trabajador>(); // se instancia vacío

                // llenamos la variable listado____ a traves del método GetAll____()
                // al final se usa el método ToList para convertir a Lista el IEnumerable que genera el método GetAll____.
                listadoTrabajador = _repositorioTrabajador.GetAllTrabajadores().ToList();

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
        public IActionResult OnPost()
        {
            // aquí se debe poner entre [] el nombre de cada campo del formulario
            var cedula = Request.Form["cedula"];
            var nombre = Request.Form["nombre"];
            var apellido = Request.Form["apellido"];
            var numeroTelefono = Request.Form["numeroTelefono"];
            var nombreUsuario = Request.Form["nombreUsuario"];
            var password = Request.Form["password"];
            var rol = Request.Form["rol"];
            var salario = Request.Form["salario"];

            // Creamos el objeto y le pasamos los datos del formulario
            var trabajador = new Trabajador{
                Cedula = cedula,
                Nombre = nombre,
                Apellido = apellido,
                NumeroTelefono = numeroTelefono,
                NombreUsuario = nombreUsuario,
                Contraseña = password,
                Rol = int.Parse(rol),
                Salario = int.Parse(salario),
            };

            // video 02/09 min 2:23:15
            // llamamos el método del Repositorio y le pasamos por parámetro el objeto que acabamos de crear, y el resultado del método lo almacenamos en la variable result.
            var result = _repositorioTrabajador.AddTrabajador(trabajador);

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
        public IActionResult OnPostUpdateJson([FromBody]Trabajador trabajador)
        {
            var trabajadorResult = _repositorioTrabajador.GetTrabajador( trabajador.Id );

            var mensaje = "";

            if( trabajadorResult != null)
            {
                trabajadorResult.Cedula = trabajador.Cedula;
                trabajadorResult.Nombre = trabajador.Nombre;
                trabajadorResult.Apellido = trabajador.Apellido;
                trabajadorResult.NumeroTelefono = trabajador.NumeroTelefono;
                trabajadorResult.NombreUsuario = trabajador.NombreUsuario;
                trabajadorResult.Contraseña = trabajador.Contraseña;
                trabajadorResult.Rol = trabajador.Rol;
                trabajadorResult.Salario = trabajador.Salario;

                var result = _repositorioTrabajador.UpdateTrabajador(trabajadorResult);

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
        public IActionResult OnPostDeleteJson([FromBody]Trabajador trabajador)
        {
            var trabajadorResult = _repositorioTrabajador.GetTrabajador( trabajador.Id );

            var mensaje = "";

            if( trabajadorResult != null)
            {
                var result = _repositorioTrabajador.DeleteTrabajador(trabajadorResult);

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
