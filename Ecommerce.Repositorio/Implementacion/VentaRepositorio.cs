using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Modelo;
using Ecommerce.Repositorio.Contrato;
using Ecommerce.Repositorio.DBContext;


namespace Ecommerce.Repositorio.Implementacion
{
    public class VentaRepositorio :GenericoRepositorio<Venta> , IVentaRepositorio
    {
        private readonly DbEcommerceContext _dbContext;
        
        public VentaRepositorio(DbEcommerceContext dbContext) : base(dbContext)//la base es generica
        {
            _dbContext = dbContext; //Usamos el Servicio
        }

        public async Task<Venta> Registrar(Venta modelo)
        {
            Venta ventaGenerada = new Venta();

            //Vamos a usar transacciones
            using(var Transaction = _dbContext.Database.BeginTransaction())//Inicio de transaction
            {
                try
                {
                    foreach(DetalleVenta dv  in modelo.DetalleVenta)
                    {
                        //Obtenemos el producto
                        Producto producto_encontrado = _dbContext.Productos.Where(p => p.IdProducto == dv.IdProducto).First();
                        //Vamos a restar el producto encontrado - la cantidad
                        producto_encontrado.Cantidad = producto_encontrado.Cantidad - dv.Cantidad;
                        //Actualizamos la informacion de la tabla
                        _dbContext.Productos.Update(producto_encontrado);
                    }
                    //Procedemos a guardar los cambios
                    await _dbContext.SaveChangesAsync();
                    //Creamos la informacion en la tabla de ventas
                    await _dbContext.Venta.AddAsync(modelo);

                    await _dbContext.SaveChangesAsync();//Guardamos los cambios
                    ventaGenerada = modelo; //Le pasamos el objeto en donde se almacenaron
                    //los procesos de la transaction
                    Transaction.Commit();//Fue Exitosa!!
                }
                catch (Exception)
                {
                    Transaction.Rollback();//Restablecemos todo
                    throw;
                }
            }
            return ventaGenerada;
        }
    }
}
