using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ecommerce.DTO;
using Ecommerce.Servicio.Contrato;
using Ecommerce.Servicio.Implementacion;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaServicio _categoriaServicio;

       public CategoriaController(ICategoriaServicio categoriaServicio)
        {
            _categoriaServicio = categoriaServicio;
        }

        [HttpGet("Lista/{rol:alpha?}")]
        public async Task<IActionResult> Lista(string buscar = "NA")//Buscar por defecto
        {
            var response = new ResponseDTO<List<CategoriaDTO>>();
            try
            {
                //Vamos a validar si buscar es vacio por defecto
                if (buscar == "NA") buscar = "";
                //Luego le decimos que es correcto 
                response.EsCorrecto = true;
                //El valor espera va a esparar la lista
                response.Resultado = await _categoriaServicio.Lista(buscar);
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
            var response = new ResponseDTO<CategoriaDTO>();
            try
            {
                response.EsCorrecto = true;
                //El valor espera va a esparar la lista
                response.Resultado = await _categoriaServicio.Obtener(Id);
            }
            catch (Exception e)
            {
                response.EsCorrecto = false;
                response.Mensaje = e.Message;
            }
            return Ok(response);//Le devolvemos la respuesta
        }

        [HttpPost("Crear")]
        public async Task<IActionResult> Crear([FromBody] CategoriaDTO modelo)
        {
            var response = new ResponseDTO<CategoriaDTO>();
            try
            {
                response.EsCorrecto = true;
                //El valor espera va a esparar la lista
                response.Resultado = await _categoriaServicio .Crear(modelo);
            }
            catch (Exception e)
            {
                response.EsCorrecto = false;
                response.Mensaje = e.Message;
            }
            return Ok(response);//Le devolvemos la respuesta
        }
        [HttpPut("Editar")]
        public async Task<IActionResult> Editar([FromBody] CategoriaDTO modelo)
        {
            var response = new ResponseDTO<bool>();
            try
            {
                response.EsCorrecto = true;
                //El valor espera va a esparar la lista
                response.Resultado = await _categoriaServicio.Editar(modelo);
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
                response.Resultado = await _categoriaServicio.Delete(Id);
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
