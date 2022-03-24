using CZBooks_webApi.Contexts;
using CZBooks_webApi.Domains;
using CZBooks_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CZBooks_webApi.Repositories
{
    public class instituicaoRepository : IInstituicaoRepository
    {
        CZContext ctx = new CZContext();

        public void Atualizar(int id, Instituico novaInstituicao)
        {
            Instituico instituicaoBuscado = ctx.Instituicoes.Find(id);

            if (novaInstituicao != null)
            {
                instituicaoBuscado = novaInstituicao;
            }
            ctx.Instituicoes.Update(instituicaoBuscado);
            ctx.SaveChanges();
        }

        public Instituico BuscarPorId(int id)
        {
            return ctx.Instituicoes.FirstOrDefault(e => e.IdInstituicao == id);
        }

        public void Cadastrar(Instituico novaInstituicao)
        {
            ctx.Instituicoes.Add(novaInstituicao);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Instituico instituicaoBuscada = ctx.Instituicoes.Find(id);
            ctx.Instituicoes.Remove(instituicaoBuscada);
            ctx.SaveChanges();
        }

        public List<Instituico> Listar()
        {
            return ctx.Instituicoes.ToList();
        }
    }
}
