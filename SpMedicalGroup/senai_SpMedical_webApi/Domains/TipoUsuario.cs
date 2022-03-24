using System;
using System.Collections.Generic;

#nullable disable

namespace senai_SpMedical_webApi.Domains
{
    public partial class TipoUsuario
    {
        public TipoUsuario()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int IdTipoUsuario { get; set; }
        public string Tipos { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
