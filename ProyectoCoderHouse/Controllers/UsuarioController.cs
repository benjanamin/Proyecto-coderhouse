using Microsoft.AspNetCore.Mvc;
using ProyectoCoderHouse.Models;
using ProyectoCoderHouse.Repository;

namespace ProyectoCoderHouse.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        [HttpGet(Name = "GetUsuarios")]
        public List<Usuario> GetUsuarios()
        {
            return UsuarioHandler.GetUsuarios();
        }

        [HttpGet("{nombreUsuario}/{contraseña}")]
        public bool GetUsuarioByNombreUsuarioAndContraseña(string nombreUsuario, string contraseña)
        {
            Usuario usuario = UsuarioHandler.GetUsuarioByNombreUsuarioAndContraseña(nombreUsuario, contraseña);
            if(usuario.NombreUsuario == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
