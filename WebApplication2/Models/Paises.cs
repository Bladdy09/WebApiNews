using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication2.Models
{
    public partial class Paises
    {
        public Paises()
        {
            Noticia = new HashSet<Noticia>();
        }

        public int PaisId { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Noticia> Noticia { get; set; }
    }
}
