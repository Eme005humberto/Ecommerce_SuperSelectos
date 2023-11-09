using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ecommerce.DTO;
using Ecommerce.Servicio.Contrato;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioServicio _usuarioServicio;

        public UsuarioController(IUsuarioServicio usuarioServicio)
        {
            _usuarioServicio = usuarioServicio;//Listo para usar el servicio
        }
        [HttpGet("Lista/{rol:alpha}/{buscar:alpha?}")]
        public async Task <IActionResult> Lista(string rol,string buscar = "NA")//Buscar por defecto
        {
            var response = new ResponseDTO<List<UsuarioDTO>>();
            try
            {
                //Vamos a validar si buscar es vacio por defecto
                if (buscar == "NA") buscar = "";
                //Luego le decimos que es correcto 
                response.EsCorrecto = true;
                //El valor espera va a esparar la lista
                response.Resultado = await _usuarioServicio.Lista(rol, buscar);
            }
            catch (Exception e)
            {
                response.EsCorrecto = false;
                response.Mensaje = e.Message;
            }
            return Ok(response);//Le devolvemos la respuesta
        }

        [HttpGet("Obtener/{id:int}")]
        public async Task<IActionResult> Obtener(int Id)//Buscar por defecto
        {
            var response = new ResponseDTO<UsuarioDTO>();
            try
            {
                response.EsCorrecto = true;
                //El valor espera va a esparar la lista
                response.Resultado = await _usuarioServicio.Obtener(Id);
            }
            catch (Exception e)
            {
                response.EsCorrecto = false;
                response.Mensaje = e.Message;
            }
            return Ok(response);//Le devolvemos la respuesta
        }

        [HttpPost("Crear")]
        public async Task<IActionResult> Crear([FromBody]UsuarioDTO modelo)
        {
            var response = new ResponseDTO<UsuarioDTO>();
            try
            {
                response.EsCorrecto = true;
                //El valor espera va a esparar la lista
                response.Resultado = await _usuarioServicio.Crear(modelo);
            }
            catch (Exception e)
            {
                response.EsCorrecto = false;
                response.Mensaje = e.Message;
            }
            return Ok(response);//Le devolvemos la respuesta
        }


        [HttpPost("Autorizacion")]
        public async Task<IActionResult> Crear([FromBody] LoginDTO modelo)
        {
            var response = new ResponseDTO<SesionDTO>();
            try
            {
                response.EsCorrecto = true;
                //El valor espera va a esparar la lista
                response.Resultado = await _usuarioServicio.Autorizacion(modelo);
            }
            catch (Exception e)
            {
                response.EsCorrecto = false;
                response.Mensaje = e.Message;
            }
            return Ok(response);//Le devolvemos la respuesta
        }

        [HttpPut("Editar")]
        public async Task<IActionResult> Editar([FromBody] UsuarioDTO modelo)
        {
            var response = new ResponseDTO<bool>();
            try
            {
                response.EsCorrecto = true;
                //El valor espera va a esparar la lista
                response.Resultado = await _usuarioServicio.Editar(modelo);
            }
            catch (Exception e)
            {
                response.EsCorrecto = false;
                response.Mensaje = e.Message;
            }
            return Ok(response);//Le devolvemos la respuesta
        }

        [HttpDelete("Eliminar/{Id:int}")]
        public async Task<IActionResult> Eliminar(int Id)
        {
            var response = new ResponseDTO<bool>();
            try
            {
                response.EsCorrecto = true;
                //El valor espera va a esparar la lista
                response.Resultado = await _usuarioServicio.Delete(Id);
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
