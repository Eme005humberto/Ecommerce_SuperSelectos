using Blazored.LocalStorage;
using Blazored.Toast;
using Blazored.Toast.Services;
using Ecommerce.DTO;
using Ecommerce.Web.Servicios.Contrato;

namespace Ecommerce.Web.Servicios.Implementacion
{
    public class CarritoServicio : ICarritoServicio
    {
        private ILocalStorageService _localStorageService;

        private ISyncLocalStorageService _syncLocalStorageService;

        private IToastService _toastService;
        
        public CarritoServicio(ILocalStorageService localStorageService,
            ISyncLocalStorageService syncLocalStorageService,
            IToastService toastService
            )
        {
            _localStorageService = localStorageService;
            _syncLocalStorageService = syncLocalStorageService;
            _toastService = toastService;
        }

        public event Action MostrarItems;

        public async Task AgregarCarrito(CarritoDTO modelo)
        {
            try
            {
                //Traere toda mi lista datos osea los productos que esten en mi carrito
                var carrito = await _localStorageService.GetItemAsync<List<CarritoDTO>>("carrito");
                if (carrito == null)
                    carrito = new List<CarritoDTO>();

                var encontrado = carrito.FirstOrDefault(c => c.Producto.IdProducto == modelo.Producto.IdProducto);
                if (encontrado != null)
                    carrito.Remove(encontrado);

                carrito.Add(modelo);
                await _localStorageService.SetItemAsync("carrito", carrito);

                if (encontrado != null)
                    _toastService.ShowSuccess("Producto fue actualizado");
                else
                    _toastService.ShowSuccess("Producto fue agregado al carrito");

                MostrarItems.Invoke();//Actualiza nuestra vista
            }
            catch
            {
                _toastService.ShowError("No se pudo agregar al carrito");
            }
        }

        public int CantidadProductos()
        {
            var carrito = _syncLocalStorageService.GetItem<List<CarritoDTO>>("carrito");
            return carrito == null ? 0 : carrito.Count();
        }

        public async Task<List<CarritoDTO>> DevolverCarrito()
        {
            //devolvemos el carrito
            var carrito = await _localStorageService.GetItemAsync<List<CarritoDTO>>("carrito");
            if (carrito != null)
               carrito = new List<CarritoDTO>();
            return carrito;
        }

        public async Task EliminarCarrito(int idProducto)
        {
            try
            {
                var carrito = await _localStorageService.GetItemAsync<List<CarritoDTO>>("carrito");
                if(carrito != null)
                {
                    var elemento = carrito.FirstOrDefault(c => c.Producto.IdProducto == idProducto);
                    if(elemento!= null)
                    {
                        carrito.Remove(elemento);
                        await _localStorageService.SetItemAsync("carrito", carrito);
                        MostrarItems.Invoke();//Mostramos la vista
                    }
                }
            }
            catch
            {

            }
        }

        public async Task limpiarCarrito()
        {
            await _localStorageService.RemoveItemAsync("carrito");
            MostrarItems.Invoke();
        }
    }
}
