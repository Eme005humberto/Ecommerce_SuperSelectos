using Ecommerce.DTO;
namespace Ecommerce.Web.Servicios.Contrato
{
    public interface IVentaServicio
    {
        Task<ResponseDTO<VentaDTO>> Registrar(VentaDTO modelo);
    }
}
