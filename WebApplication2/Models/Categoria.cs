using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication2.Models
{
    public partial class Categoria
    {
        public Categoria()
        {
            Noticia = new HashSet<Noticia>();
        }

        public int CategoriaId { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Noticia> Noticia { get; set; }
    }
}
