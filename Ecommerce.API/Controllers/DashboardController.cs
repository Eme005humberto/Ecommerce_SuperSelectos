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
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardServicio _dashboardServicio;

        public DashboardController(IDashboardServicio dashboardServicio)
        {
            _dashboardServicio = dashboardServicio;
        }

        [HttpGet("Resumen")]
        public IActionResult Resumen()
        {
            var response = new ResponseDTO<DashboardDTO>();
            try
            {
                response.EsCorrecto = true;
                //El valor espera va a esparar la lista
                response.Resultado = _dashboardServicio.Resumen();
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
