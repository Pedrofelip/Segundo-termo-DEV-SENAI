using senai_SpMedical_webApi.Contexts;
using senai_SpMedical_webApi.Domains;
using senai_SpMedical_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_SpMedical_webApi.Repositories
{
    public class especialidadeRepository : IespecialidadeRepository
    {
        SPMedContext ctx = new SPMedContext();
        public void Atualizar(int id, Especialidade especialidadeAtualizada)
        {
            Especialidade especialidadeBuscada = ctx.Especialidades.Find(id);


            if ( especialidadeAtualizada != null)
            {
                especialidadeBuscada = especialidadeAtualizada;
            }

            ctx.Especialidades.Update(especialidadeBuscada);

            ctx.SaveChanges();
        }

        public Especialidade BuscarPorId(int id)
        {
            return ctx.Especialidades.FirstOrDefault(e => e.IdEspecialidade == id);
        }

        public void Cadastrar(Especialidade novaEspecialidade)
        {
            ctx.Especialidades.Add(novaEspecialidade);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Especialidade especialidade = BuscarPorId(id);
            ctx.Especialidades.Remove(especialidade);
            ctx.SaveChanges();
        }

        public List<Especialidade> Listar()
        {
            return ctx.Especialidades.ToList();
        }
    }
}
