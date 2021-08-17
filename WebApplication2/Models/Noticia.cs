using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication2.Models
{
    public partial class Noticia
    {
        public int NoticiaId { get; set; }
        public string Titulo { get; set; }
        public string UrlToImage { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaDePublicacion { get; set; }
        public int AutorId { get; set; }
        public int CategoriaId { get; set; }
        public int PaisId { get; set; }
        public int EstadoId { get; set; }

        public virtual Autores Autor { get; set; }
        public virtual Categoria Categoria { get; set; }
        public virtual Estado Estado { get; set; }
        public virtual Paises Pais { get; set; }
    }
}
