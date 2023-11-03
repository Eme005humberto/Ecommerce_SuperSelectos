using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using Ecommerce.Repositorio.Contrato;
using Ecommerce.Repositorio.DBContext;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Ecommerce.Repositorio.Implementacion
{
    public class GenericoRepositorio<TModelo>: IGenericoRepositorio<TModelo> where TModelo : class
    {
        private readonly DbEcommerceContext _dbContext;
        public GenericoRepositorio(DbEcommerceContext dbContext)
        {
            _dbContext = dbContext;//Inicializamos el servicio dentro de la clase
        }
        //Nos trae todo los metodos del la IGenericoRepositorio
        public IQueryable<TModelo> Consultar(Expression<Func<TModelo, bool>>? filtro = null)
        {
            //Creamos un query con IQueyable
            IQueryable<TModelo> consulta = (filtro == null) ? _dbContext.Set<TModelo>() : _dbContext.Set<TModelo>().Where(filtro);
            return consulta;
        }

        public async Task<TModelo> Crear(TModelo modelo)
        {
            try
            {
                //Le pasamos el contexto establecemos el modelo en este caso TModelo
                //luego Agregamos el Objeto modelo
                //la ejecucion se detendra hasta que hayamos guardado los datos del TModelo
                _dbContext.Set<TModelo>().Add(modelo);
                await _dbContext.SaveChangesAsync();
                return modelo;//retornamos el modelo
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Modificar(TModelo modelo)
        {
            try
            {
                //Le pasamos el contexto establecemos el modelo en este caso TModelo
                //luego modificamos el Objeto modelo
                //la ejecucion se detendra hasta que hayamos guardado los datos del TModelo
                _dbContext.Set<TModelo>().Update(modelo);
                await _dbContext.SaveChangesAsync();
                return true;//retornamos el modelo
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(TModelo modelo)
        {
            try
            {
                //Le pasamos el contexto establecemos el modelo en este caso TModelo
                //luego Removemos el Objeto modelo
                //la ejecucion se detendra hasta que hayamos guardado los datos del TModelo
                _dbContext.Set<TModelo>().Remove(modelo);
                await _dbContext.SaveChangesAsync();
                return true;//retornamos el modelo
            }
            catch
            {
                throw;
            }
        }
    }
}
