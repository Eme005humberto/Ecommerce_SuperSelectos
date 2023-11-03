using Ecommerce.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Repositorio.Contrato
{
    //Le decimos que vamos a trabajar con la Interfaz Generica de los
    //metodos y nos enfocamos en la tabla Venta
    public interface IVentaRepositorio :IGenericoRepositorio<Venta>
    {
        //Metodo especiales de proceso de  Venta
        Task<Venta> Registrar(Venta venta);

    }
}
