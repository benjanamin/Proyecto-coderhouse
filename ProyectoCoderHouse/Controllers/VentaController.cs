using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoCoderHouse.Models;
using ProyectoCoderHouse.Repository;

namespace ProyectoCoderHouse.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class VentaController : ControllerBase
    {
        [HttpGet(Name = "GetVentas")]
        public List<Venta> GetVentas()
        {
            return VentasHandler.GetVentas();
        }
    }
}
