using Microsoft.EntityFrameworkCore;
using senai_SpMedical_webApi.Contexts;
using senai_SpMedical_webApi.Domains;
using senai_SpMedical_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_SpMedical_webApi.Repositories
{
    public class agendamentoRepository : IagendamentoRepository
    {
        SPMedContext ctx = new SPMedContext();
        public void Atualizar(int id, Agendamento agendamentoAtualizado)
        {
            Agendamento agendamentoBuscado = ctx.Agendamentos.Find(id);

            
            if (agendamentoAtualizado != null)
            {
                agendamentoBuscado = agendamentoAtualizado;
            }

            ctx.Agendamentos.Update(agendamentoBuscado);

            ctx.SaveChanges();
        }

        public Agendamento BuscarPorId(int id)
        {
            return ctx.Agendamentos.FirstOrDefault(e => e.IdAgendamento == id);
        }

        public void Cadastrar(Agendamento novoAgendamento)
        {
            ctx.Agendamentos.Add(novoAgendamento);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Agendamento agendamento = BuscarPorId(id);
            ctx.Agendamentos.Remove(agendamento);
            ctx.SaveChanges();
        }

        public List<Agendamento> ListaDoMedico(int id)
        {
            return ctx.Agendamentos.Include(e => e.IdMedicoNavigation).ToList();
        }

        public List<Agendamento> ListaDoPaciente(int id)
        {
            return ctx.Agendamentos.Include(e => e.IdPacienteNavigation).ToList();
        }

        public List<Agendamento> Listar()
        {
            return ctx.Agendamentos.ToList();
        }
    }
}
