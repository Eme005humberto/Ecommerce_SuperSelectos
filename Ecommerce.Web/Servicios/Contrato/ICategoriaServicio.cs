using Ecommerce.DTO;

namespace Ecommerce.Web.Servicios.Contrato
{
    public interface ICategoriaServicio
    {
        //Metodos que vamos a usar de la Api de Usuario
        Task<ResponseDTO<List<CategoriaDTO>>> Lista(string buscar);
        Task<ResponseDTO<CategoriaDTO>> Obtener(int id);
        Task<ResponseDTO<CategoriaDTO>> Crear(CategoriaDTO modelo);
        Task<ResponseDTO<bool>> Editar(CategoriaDTO modelo);
        Task<ResponseDTO<bool>> Eliminar(int id);
    }
}
