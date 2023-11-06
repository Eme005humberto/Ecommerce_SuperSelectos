using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ecommerce.DTO;
using Ecommerce.Servicio;
using Ecommerce.Servicio.Contrato;
using Ecommerce.Servicio.Implementacion;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        private readonly IVentaServicio _ventaServicio;
        public VentaController(IVentaServicio ventaServicio)
        {
            _ventaServicio = ventaServicio;
        }
        [HttpPost("Registrar")]
        public async Task<IActionResult> Crear([FromBody] VentaDTO modelo)
        {
            var response = new ResponseDTO<VentaDTO>();
            try
            {
                response.EsCorrecto = true;
                //El valor espera va a esparar la lista
                response.Resultado = await _ventaServicio.Registrar(modelo);
            }
            catch (Exception e)
            {
                response.EsCorrecto = false;
                response.Mensaje = e.Message;
            }
            return Ok(response);//Le devolvemos la respuesta
        }
    }
}
