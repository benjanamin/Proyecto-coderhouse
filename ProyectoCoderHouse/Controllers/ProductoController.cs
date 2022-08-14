using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoCoderHouse.Models;
using ProyectoCoderHouse.Repository;

namespace ProyectoCoderHouse.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class ProductoController : ControllerBase
    {
        [HttpGet(Name = "GetProductos")]
        public List<Producto> GetProductos()
        {
            return ProductoHandler.GetProductos();
        }
    }
}
