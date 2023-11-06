using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DTO
{
    public class ResponseDTO<T>//Hacemos la clase generica por lo cual podemos trabajar
        //con cualquier clase del modelo
    {
        //Va a contener todas las solicitudes vamos a realizar en nuestra API
        public T? Resultado { get; set; }//Con este campo lo utilizaremos para poder trabajar
        //con algun campo para enviar el resultado de la clase con la que trabajemos
        public bool EsCorrecto { get; set; }//Para determinar el proceso si fue tRUE O FALSE
        public string? Mensaje { get; set; }//Mensaje de exito o error
    }
}
