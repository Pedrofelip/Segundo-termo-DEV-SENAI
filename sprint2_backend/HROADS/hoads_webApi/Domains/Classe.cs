using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace senai.hroads.webApi.Domains
{
    public partial class Classe
    {
        public Classe()
        {
            Personagens = new HashSet<Personagem>();
        }

        public int IdClasse { get; set; }

        [Required(ErrorMessage = "Nome obrigatório !")]
        public string Nome { get; set; }

        public virtual ICollection<Personagem> Personagens { get; set; }
    }
}
