using Ecommerce.DTO;
using Ecommerce.Web.Servicios.Contrato;
using System.Net.Http.Json;

namespace Ecommerce.Web.Servicios.Implementacion
{
    public class ProductoServicio :IProductoService
    {
        public readonly HttpClient _httpClient;
        public ProductoServicio(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResponseDTO<List<ProductoDTO>>> Catalogo(string categoria, string buscar)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<List<ProductoDTO>>>($"Producto/Catalogo/{categoria}/{buscar}");
        }

        public async Task<ResponseDTO<ProductoDTO>> Crear(ProductoDTO modelo)
        {
            //Estamos ejecutando un metodo Post y le enviamos un JSON
            var response = await _httpClient.PostAsJsonAsync("Producto/Crear", modelo);
            //Nuestra estructura devuelve un Response DTO por lo cual se lo hacemos saber
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<ProductoDTO>>();
            return result!;//Negammos la posibilidad de que sea nulo
        }

        public async Task<ResponseDTO<bool>> Editar(ProductoDTO modelo)
        {
            //Estamos ejecutando un metodo Put y le enviamos un JSON
            var response = await _httpClient.PutAsJsonAsync("Producto/Editar", modelo);
            //Nuestra estructura devuelve un Response DTO por lo cual se lo hacemos saber
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<bool>>();
            return result!;//Negammos la posibilidad de que sea nulo
        }

        public async Task<ResponseDTO<bool>> Eliminar(int id)
        {
            //Estamos ejecutando un metodo Post y le enviamos un JSON
            return await _httpClient.DeleteFromJsonAsync<ResponseDTO<bool>>($"Producto/Eliminar/{id}");
        }

        public async Task<ResponseDTO<List<ProductoDTO>>> Lista(string buscar)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<List<ProductoDTO>>>($"Producto/Catalogo/{buscar}");
        }

        public async Task<ResponseDTO<ProductoDTO>> Obtener(int id)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<ProductoDTO>>($"Producto/Obtener/{id}");
        }
    }
}
