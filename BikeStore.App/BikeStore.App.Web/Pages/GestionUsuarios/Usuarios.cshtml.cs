using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BikeStore.App.Dominio;
using BikeStore.App.Persistencia;

namespace BikeStore.App.Web
{
    public class UsuariosModel : PageModel
    {
        // video 02/09 min 2:30:20 y en el minuto 2:41:27
        // Instanciar el repositorio, igual como se hizo en la capa Consola
        private IRepositorioPersona _repositorioPersona = new RepositorioPersona( new Persistencia.AppContext() );
        private IRepositorioTrabajador _repositorioTrabajador = new RepositorioTrabajador( new Persistencia.AppContext() );
        private IRepositorioUsuario _repositorioUsuario = new RepositorioUsuario( new Persistencia.AppContext() );

        // video 02/09 min 2:49:30
        // crear una variable tipo List que reciba la totalidad de los registros consultados de la DB, debe ser público para que la interface gráfica pueda acceder a él
        public List<Trabajador> listadoTrabajador { get; set; }
        // public List<Persona> listadoPersona { get; set; }
        // public List<Usuario> listadoUsuario { get; set; }
        
        public void OnGet()
        {
            // video 02/09 min 2:50:22
            // debo inicializar el objeto listadoProducto dentro de OnGet para que lo pueda interpretar
            listadoTrabajador = new List<Trabajador>(); // se instancia vacío
            listadoTrabajador = _repositorioTrabajador.GetAllTrabajadores().ToList();
            // listadoPersona = new List<Persona>(); // se instancia vacío
            // listadoPersona = _repositorioPersona.GetAllPersonas().ToList();
            // listadoUsuario = new List<Usuario>(); // se instancia vacío
            // listadoUsuario = _repositorioUsuario.GetAllUsuarios().ToList();
        }

        // // Método para capturar el Post del formulario
        public void OnPost(){

            var cedula = Request.Form["cedula"];
            var nombre = Request.Form["nombre"];
            var apellido = Request.Form["apellido"];
            var numeroTelefono = Request.Form["numeroTelefono"];
            var nombreUsuario = Request.Form["nombreUsuario"];
            var contraseña = Request.Form["contraseña"];
            var salario = Request.Form["salario"];
            var rol = Request.Form["rol"];

            // // Creamos el objeto y le pasamos los datos del formulario
            var trabajador = new Trabajador{
                Cedula = cedula,
                Nombre = nombre,
                Apellido = apellido,
                NumeroTelefono = numeroTelefono,
                NombreUsuario = nombreUsuario,
                Contraseña = contraseña,
                Salario = int.Parse(salario),
                Rol = int.Parse(rol)
            };

            // video 02/09 min 2:23:15
            // llamamos el método del Repositorio y le pasamos por parámetro el objeto que acabamos de crear, y el resultado del método lo almacenamos en la variable result.
            var result = _repositorioTrabajador.AddTrabajador(trabajador);
            if( result > 0){
                Console.WriteLine("Se creó con éxito el Usuario");
            }else{
                Console.WriteLine("Se creó con éxito el Usuario");
            }
        }
    }
}
