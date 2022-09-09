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
        private IRepositorioTrabajador _repositorioTrabajador = new RepositorioTrabajador( new Persistencia.AppContext() );


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
        }

        // // Método para capturar el Post del formulario
        public void OnPost(){

            var cedula = Request.Form["cedula"];
            var nombre = Request.Form["nombre"];
            var apellido = Request.Form["apellido"];
            var numeroTelefono = Request.Form["numeroTelefono"];
            var nombreUsuario = Request.Form["nombreUsuario"];
            var contraseña = Request.Form["contraseña"];
            var rol = Request.Form["rol"];
            var salario = Request.Form["salario"];

            // // Creamos el objeto y le pasamos los datos del formulario
            var trabajador = new Trabajador{
                Cedula = cedula,
                Nombre = nombre,
                Apellido = apellido,
                NumeroTelefono = numeroTelefono,
                NombreUsuario = nombreUsuario,
                Contraseña = contraseña,
                Rol = int.Parse(rol),
                Salario = int.Parse(salario),
            };

            Console.WriteLine("Cedula = " + trabajador.Cedula + "Nombre= " + trabajador.Nombre + "Apellido =" + trabajador.Apellido + "NumeroTelefono = " + trabajador.NumeroTelefono + "NombreUsuario =" + trabajador.NombreUsuario + "Contraseña =" + trabajador.Contraseña + "Rol =" + trabajador.Rol + "Salario =" + trabajador.Salario);

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
