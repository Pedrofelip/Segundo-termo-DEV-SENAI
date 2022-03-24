using System;
using System.Collections.Generic;

#nullable disable

namespace senai_SpMedical_webApi.Domains
{
    public partial class Situacao
    {
        public Situacao()
        {
            Agendamentos = new HashSet<Agendamento>();
        }

        public int IdSituacao { get; set; }
        public string Situacao1 { get; set; }

        public virtual ICollection<Agendamento> Agendamentos { get; set; }
    }
}
