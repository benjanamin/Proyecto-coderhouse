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
    }
}
