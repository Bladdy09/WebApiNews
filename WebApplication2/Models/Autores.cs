using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication2.Models
{
    public partial class Autores
    {
        public Autores()
        {
            Noticia = new HashSet<Noticia>();
        }

        public int AutorId { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string UrlToImage { get; set; }
        public string Correo { get; set; }
        public string Contrasena { get; set; }
        public int EstadoId { get; set; }

        public virtual Estado Estado { get; set; }
        public virtual ICollection<Noticia> Noticia { get; set; }
    }
}
