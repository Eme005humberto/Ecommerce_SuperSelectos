using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Repositorio.Contrato
{
    public interface IGenericoRepositorio<TModelo> where TModelo : class//Solo recibimos clases
        //nada de enteros ni strings solo clases
    {
        //Creamos los metodos con los que podremos trabajar con cualquier modelo

        //Esta interface servira para cominicarnos con todos los modelos
        //en donde estaran nuestros metodos a realizar

        //Realizamos un filtro para el TModelo que recibe un bool
        IQueryable<TModelo> Consultar(Expression<Func<TModelo,bool>>?filtro=null);

        Task<TModelo> Crear(TModelo modelo);//Metodo asincrono de Crear

        Task<bool> Modificar(TModelo modelo);//Metodo asincrono de Modificar

        Task<bool> Eliminar(TModelo modelo);//Metodo asincrono de Eliminar

    }
}
