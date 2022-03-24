using System;
using System.Collections.Generic;

#nullable disable

namespace senai_SpMedical_webApi.Domains
{
    public partial class Agendamento
    {
        public int IdAgendamento { get; set; }
        public int? IdSituacao { get; set; }
        public int? IdPaciente { get; set; }
        public int? IdMedico { get; set; }
        public DateTime? DataConsulta { get; set; }
        public string Descricao { get; set; }

        public virtual Medico IdMedicoNavigation { get; set; }
        public virtual Paciente IdPacienteNavigation { get; set; }
        public virtual Situacao IdSituacaoNavigation { get; set; }
    }
}
