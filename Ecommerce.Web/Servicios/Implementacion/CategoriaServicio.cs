using Ecommerce.DTO;
using Ecommerce.Web.Servicios.Contrato;
using System.Net.Http.Json;

namespace Ecommerce.Web.Servicios.Implementacion
{
    public class CategoriaServicio : ICategoriaServicio
    {
        public readonly HttpClient _httpClient;
        public CategoriaServicio(HttpClient httpClient) {
            _httpClient = httpClient;
        }

        public async Task<ResponseDTO<CategoriaDTO>> Crear(CategoriaDTO modelo)
        {
            //Estamos ejecutando un metodo Post y le enviamos un JSON
            var response = await _httpClient.PostAsJsonAsync("Categoria/Crear", modelo);
            //Nuestra estructura devuelve un Response DTO por lo cual se lo hacemos saber
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<CategoriaDTO>>();
            return result!;//Negammos la posibilidad de que sea nulo
        }

        public async Task<ResponseDTO<bool>> Editar(CategoriaDTO modelo)
        {
            //Estamos ejecutando un metodo Put y le enviamos un JSON
            var response = await _httpClient.PutAsJsonAsync("Categoria/Editar", modelo);
            //Nuestra estructura devuelve un Response DTO por lo cual se lo hacemos saber
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<bool>>();
            return result!;//Negammos la posibilidad de que sea nulo
        }

        public async Task<ResponseDTO<bool>> Eliminar(int id)
        {
            return await _httpClient.DeleteFromJsonAsync<ResponseDTO<bool>>($"Categoria/Eliminar/{id}");
        }

        public async Task<ResponseDTO<List<CategoriaDTO>>> Lista(string buscar)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<List<CategoriaDTO>>>($"Categoria/Lista/{buscar}");
        }

        public async Task<ResponseDTO<CategoriaDTO>> Obtener(int id)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<CategoriaDTO>>($"Categoria/Obtener/{id}");
        }
    }
}
