using senai_SpMedical_webApi.Contexts;
using senai_SpMedical_webApi.Domains;
using senai_SpMedical_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_SpMedical_webApi.Repositories
{
    public class medicoRepository : ImedicoRepository
    {
        SPMedContext ctx = new SPMedContext(); 
        public void Atualizar(int id, Medico medicoAtualizado)
        {
            Medico medicoBuscado = ctx.Medicos.Find(id);

            if (medicoAtualizado != null)
            {
                medicoBuscado = medicoAtualizado;
            }

            ctx.Medicos.Update(medicoBuscado);

            ctx.SaveChanges();

        }

        public Medico BuscarPorId(int id)
        {
            return ctx.Medicos.FirstOrDefault(e => e.IdMedico == id);
        }

        public void Cadastrar(Medico novoMedico)
        {
            ctx.Medicos.Add(novoMedico);
            ctx.SaveChanges();

        }

        public void Deletar(int id)
        {
            Medico medico = BuscarPorId(id);
            ctx.Medicos.Remove(medico);
            ctx.SaveChanges();

        }

        public List<Medico> Listar()
        {
            return ctx.Medicos.ToList();
        }
    }
}
