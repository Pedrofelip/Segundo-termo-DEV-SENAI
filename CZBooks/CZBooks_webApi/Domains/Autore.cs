﻿using System;
using System.Collections.Generic;

#nullable disable

namespace CZBooks_webApi.Domains
{
    public partial class Autore
    {
        public Autore()
        {
            Livros = new HashSet<Livro>();
        }

        public int IdAutor { get; set; }
        public int? IdUsuario { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Livro> Livros { get; set; }
    }
}
