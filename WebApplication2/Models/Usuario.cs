using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication2.Models
{
    public partial class Usuario
    {
        public int UsuariosId { get; set; }
        public string NombreApellido { get; set; }
        public string NombreUsuario { get; set; }
        public string Contrasena { get; set; }
    }
}
