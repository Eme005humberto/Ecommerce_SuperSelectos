using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DTO
{
    public class CarritoDTO
    {
        //Va almacenar los datos de la compra
        public ProductoDTO? Producto { get; set; }//Permitimos nulos ?
        public int? Cantidad {  get; set; }
        public decimal? Precio { get; set; }
        public decimal? Total { get; set; }
    }
}
