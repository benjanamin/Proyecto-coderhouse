using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoCoderHouse.Models;
using ProyectoCoderHouse.Repository;

namespace ProyectoCoderHouse.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ProductoVendidoController : ControllerBase
    {
        [HttpGet(Name = "GetProductosVendidos")]
        public List<ProductoVendido> GetProductosVendidos()
        {
            return ProductoVendidoHandler.GetProductosVendidos();
        }

    }
}
