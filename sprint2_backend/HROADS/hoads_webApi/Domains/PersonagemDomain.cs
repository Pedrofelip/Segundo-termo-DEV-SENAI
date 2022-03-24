using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace senai.hroads.webApi.Domains
{
    public partial class Personagem
    {
        public int IdPersonagem { get; set; }
        public int IdClasse { get; set; }

        [Required(ErrorMessage = "Nome obrigatório !")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Capacidade de Vida obrigatório !")]
        public int MaxVida { get; set; }

        [Required(ErrorMessage = "Capacidade de Mana obrigatório !")]
        public int MaxMana { get; set; }

        [Required(ErrorMessage = "Data de Atualizacao obrigatório !")]
        public DateTime DataAtualizacao { get; set; }

        [Required(ErrorMessage = "Data de Criacao obrigatório !")]
        public DateTime DataCriacao { get; set; }

        public virtual Classe IdClasseNavigation { get; set; }
    }
}
