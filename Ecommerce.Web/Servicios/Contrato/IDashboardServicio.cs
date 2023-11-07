using Ecommerce.DTO;
namespace Ecommerce.Web.Servicios.Contrato
{
    public interface IDashboardServicio
    {
        Task<ResponseDTO<DashboardDTO>> Resumen();
    }
}
