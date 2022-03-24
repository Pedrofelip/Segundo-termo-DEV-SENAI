using System;
using System.Collections.Generic;

#nullable disable

namespace CZBooks_webApi.Domains
{
    public partial class Categoria
    {
        public Categoria()
        {
            Livros = new HashSet<Livro>();
        }

        public int Idcategoria { get; set; }
        public string Categoria1 { get; set; }

        public virtual ICollection<Livro> Livros { get; set; }
    }
}
