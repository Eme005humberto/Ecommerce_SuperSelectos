using Ecommerce.DTO;
using Ecommerce.Web.Servicios.Contrato;
using System.Net.Http.Json;
using System.Reflection;

namespace Ecommerce.Web.Servicios.Implementacion
{
    public class UsuarioServicio : IUsuarioServicio
    {
        public readonly HttpClient _httpClient;
        public UsuarioServicio(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResponseDTO<SesionDTO>> Autorizacion(LoginDTO modelo)
        {
            //Estamos ejecutando un metodo Post y le enviamos un JSON
            var response = await _httpClient.PostAsJsonAsync("Usuario/Autorizacion",modelo);
            //Nuestra estructura devuelve un Response DTO por lo cual se lo hacemos saber
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<SesionDTO>>();
            return result!;//Negammos la posibilidad de que sea nulo
        }
        public async Task<ResponseDTO<UsuarioDTO>> Crear(UsuarioDTO modelo)
        {
            //Estamos ejecutando un metodo Post y le enviamos un JSON
            var response = await _httpClient.PostAsJsonAsync("Usuario/Crear", modelo);
            //Nuestra estructura devuelve un Response DTO por lo cual se lo hacemos saber
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<UsuarioDTO>>();
            return result!;//Negammos la posibilidad de que sea nulo
        }
        public async Task<ResponseDTO<bool>> Editar(UsuarioDTO modelo)
        {
            //Estamos ejecutando un metodo Put y le enviamos un JSON
            var response = await _httpClient.PutAsJsonAsync("Usuario/Editar", modelo);
            //Nuestra estructura devuelve un Response DTO por lo cual se lo hacemos saber
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<bool>>();
            return result!;//Negammos la posibilidad de que sea nulo
        }

        public async Task<ResponseDTO<bool>> Eliminar(int id)
        {
            //Estamos ejecutando un metodo Post y le enviamos un JSON
            return await _httpClient.DeleteFromJsonAsync<ResponseDTO<bool>>($"Usuario/Eliminar/{id}");
        }

        public async Task<ResponseDTO<List<UsuarioDTO>>> Lista(string rol, string buscar)
        {
            return  await _httpClient.GetFromJsonAsync<ResponseDTO<List<UsuarioDTO>>>($"Usuario/Lista/{rol}/{buscar}");
        }

        public async Task<ResponseDTO<UsuarioDTO>> Obtener(int id)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<UsuarioDTO>>($"Usuario/Obtener/{id}");
        }
    }
}
