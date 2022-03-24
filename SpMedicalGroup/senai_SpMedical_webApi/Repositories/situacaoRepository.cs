using senai_SpMedical_webApi.Contexts;
using senai_SpMedical_webApi.Domains;
using senai_SpMedical_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_SpMedical_webApi.Repositories
{
    public class situacaoRepository : IsituacaoRepository
    {
        SPMedContext ctx = new SPMedContext();

        public void Atualizar(int id, Situacao situacaoAtualizada)
        {
            Situacao situacaoBuscada = ctx.Situacoes.Find(id);

            if (situacaoAtualizada != null)
            {
                situacaoBuscada = situacaoAtualizada;
            }

            ctx.Situacoes.Update(situacaoBuscada);

            ctx.SaveChanges();

        }

        public Situacao BuscarPorId(int id)
        {
            return ctx.Situacoes.FirstOrDefault(e => e.IdSituacao == id);

        }

        public void Cadastrar(Situacao novaSituacao)
        {
            ctx.Situacoes.Add(novaSituacao);
            ctx.SaveChanges();

        }

        public void Deletar(int id)
        {
            Situacao situacao = BuscarPorId(id);
            ctx.Situacoes.Remove(situacao);
            ctx.SaveChanges();

        }

        public List<Situacao> Listar()
        {
            return ctx.Situacoes.ToList();
        }
    }
}
