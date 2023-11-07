using Ecommerce.DTO;
using Ecommerce.Web.Servicios.Contrato;
using System.Net.Http.Json;

namespace Ecommerce.Web.Servicios.Implementacion
{
    public class VentaServicio :IVentaServicio
    {
        public readonly HttpClient _httpClient;
        public VentaServicio(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResponseDTO<VentaDTO>> Registrar(VentaDTO modelo)
        {
            //Estamos ejecutando un metodo Post y le enviamos un JSON
            var response = await _httpClient.PostAsJsonAsync("Venta/Registrar", modelo);
            //Nuestra estructura devuelve un Response DTO por lo cual se lo hacemos saber
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<VentaDTO>>();
            return result!;//Negammos la posibilidad de que sea nulo
        }
    }
}
