using System;
using System.Collections.Generic;

#nullable disable

namespace senai_SpMedical_webApi.Domains
{
    public partial class Paciente
    {
        public Paciente()
        {
            Agendamentos = new HashSet<Agendamento>();
        }

        public int IdPaciente { get; set; }
        public int? IdUsuario { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string Endereco { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Agendamento> Agendamentos { get; set; }
    }
}
