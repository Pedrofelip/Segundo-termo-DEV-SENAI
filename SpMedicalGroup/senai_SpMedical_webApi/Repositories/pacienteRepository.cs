using senai_SpMedical_webApi.Contexts;
using senai_SpMedical_webApi.Domains;
using senai_SpMedical_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_SpMedical_webApi.Repositories
{
    public class pacienteRepository : IpacienteRepository
    {
        SPMedContext ctx = new SPMedContext();


        public void Atualizar(int id, Paciente pacienteAtualizado)
        {
            Paciente pacienteBuscado = ctx.Pacientes.Find(id);

            if (pacienteAtualizado != null)
            {
                pacienteBuscado = pacienteAtualizado;
            }

            ctx.Pacientes.Update(pacienteBuscado);

            ctx.SaveChanges();
        }

        public Paciente BuscarPorId(int id)
        {
            return ctx.Pacientes.FirstOrDefault(e => e.IdPaciente == id);
        }

        public void Cadastrar(Paciente novoPaciente)
        {
            ctx.Pacientes.Add(novoPaciente);
            ctx.SaveChanges();

        }

        public void Deletar(int id)
        {
            Paciente paciente = BuscarPorId(id);
            ctx.Pacientes.Remove(paciente);
            ctx.SaveChanges();
        }

        public List<Paciente> Listar()
        {
            return ctx.Pacientes.ToList();
        }
    }
}
