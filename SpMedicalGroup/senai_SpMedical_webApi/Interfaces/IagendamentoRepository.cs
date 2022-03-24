using senai_SpMedical_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_SpMedical_webApi.Interfaces
{
    interface IagendamentoRepository
    {
        List<Agendamento> Listar();
        List<Agendamento> ListaDoPaciente(int id);
        List<Agendamento> ListaDoMedico(int id);
        Agendamento BuscarPorId(int id);
        void Cadastrar(Agendamento novoAgendamento);
        void Atualizar(int id, Agendamento agendamentoAtualizado);
        void Deletar(int id);
    }
}
