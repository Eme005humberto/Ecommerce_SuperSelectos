using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DTO
{
    public class SesionDTO
    {
        //Nos va a servir para guardar la informacion del usuario una vez alla
        //iniciado sesion
        public int IdUsuario { get; set; }

        public string? NombreCompleto { get; set; }

        public string? Correo { get; set; }

        public string? Rol { get; set; }

    }
}
