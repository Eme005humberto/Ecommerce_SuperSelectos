using Ecommerce.DTO;

namespace Ecommerce.Web.Servicios.Contrato
{
    public interface ICarritoServicio
    {
        //Mostrar eventos para el carrito
        event Action MostrarItems;

        int CantidadProductos();

        Task AgregarCarrito(CarritoDTO modelo);

        Task EliminarCarrito(int idProducto);

        Task<List<CarritoDTO>> DevolverCarrito();

        Task limpiarCarrito();
    }
}
