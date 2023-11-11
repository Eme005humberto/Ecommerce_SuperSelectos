using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Ecommerce.DTO;
using Ecommerce.Servicio.Contrato;
using Ecommerce.Servicio.Implementacion;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly IProductoServicio _productoServicio;

       public ProductosController(IProductoServicio productoServicio)
        {
            _productoServicio = productoServicio;
        }
        [HttpGet("Lista/{buscar:alpha?}")]
        public async Task<IActionResult> Lista(string buscar = "NA")//Buscar por defecto
        {
            var response = new ResponseDTO<List<ProductoDTO>>();
            try
            {
                //Vamos a validar si buscar es vacio por defecto
                if (buscar == "NA") buscar = "";
                //Luego le decimos que es correcto 
                response.EsCorrecto = true;
                //El valor espera va a esparar la lista
                response.Resultado = await _productoServicio.Lista(buscar);
            }
            catch (Exception e)
            {
                response.EsCorrecto = false;
                response.Mensaje = e.Message;
            }
            return Ok(response);//Le devolvemos la respuesta
        }
        [HttpGet("Catalogo/{categoria}/{buscar?}")]
        public async Task<IActionResult> Catalogo(string categoria,string buscar = "NA")//Buscar por defecto
        {
            var response = new ResponseDTO<List<ProductoDTO>>();
            try
            {
                //Validamos si es vacio nos trae todos los datos
                if (categoria.ToLower() == "todos") categoria = "";
                if (buscar == "NA") buscar = "";

                response.EsCorrecto = true;
                //El valor espera va a esparar la lista
                response.Resultado = await _productoServicio.Catalogo(categoria,buscar);
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
            var response = new ResponseDTO<ProductoDTO>();
            try
            {
                response.EsCorrecto = true;
                //El valor espera va a esparar la lista
                response.Resultado = await _productoServicio.Obtener(Id);
            }
            catch (Exception e)
            {
                response.EsCorrecto = false;
                response.Mensaje = e.Message;
            }
            return Ok(response);//Le devolvemos la respuesta
        }
        [HttpPost("Crear")]
        public async Task<IActionResult> Crear([FromBody] ProductoDTO modelo)
        {
            var response = new ResponseDTO<ProductoDTO>();
            try
            {
                response.EsCorrecto = true;
                //El valor espera va a esparar la lista
                response.Resultado = await _productoServicio.Crear(modelo);
            }
            catch (Exception e)
            {
                response.EsCorrecto = false;
                response.Mensaje = e.Message;
            }
            return Ok(response);//Le devolvemos la respuesta
        }

        [HttpPut("Editar")]
        public async Task<IActionResult> Editar([FromBody] ProductoDTO modelo)
        {
            var response = new ResponseDTO<bool>();
            try
            {
                response.EsCorrecto = true;
                //El valor espera va a esparar la lista
                response.Resultado = await _productoServicio.Editar(modelo);
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
                response.Resultado = await _productoServicio.Delete(Id);
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
