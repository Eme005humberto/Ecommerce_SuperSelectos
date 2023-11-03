using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DTO
{
    public class UsuarioDTO
    {
        //Esta clase nos sirve para enviar y recibir los datos del usuario
        public int IdUsuario { get; set; }
        [Required(ErrorMessage = "Ingrese nombre completo")]
        public string? NombreCompleto { get; set; }
        [Required(ErrorMessage = "Ingrese su correo")]
        public string? Correo { get; set; }
        [Required(ErrorMessage = "Ingrese su contraseña")]
        public string? Clave { get; set; }

        public string? ConfirmarClave {  get; set; }

        public string? Rol { get; set; }

    }
}
