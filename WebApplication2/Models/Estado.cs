using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication2.Models
{
    public partial class Estado
    {
        public Estado()
        {
            Autores = new HashSet<Autores>();
            Noticia = new HashSet<Noticia>();
        }

        public int EstadoId { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Autores> Autores { get; set; }
        public virtual ICollection<Noticia> Noticia { get; set; }
    }
}
