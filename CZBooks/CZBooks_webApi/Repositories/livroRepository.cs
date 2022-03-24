using CZBooks_webApi.Contexts;
using CZBooks_webApi.Domains;
using CZBooks_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CZBooks_webApi.Repositories
{
    public class livroRepository : ILivroRepository
    {
        CZContext ctx = new CZContext();

        public void Atualizar(int id, Livro novoLivro)
        {
            Livro livroBuscado = ctx.Livros.Find(id);

            if (novoLivro != null)
            {
                livroBuscado = novoLivro;
            }
            ctx.Livros.Update(livroBuscado);
            ctx.SaveChanges();
        }

        public Livro BuscarPorId(int id)
        {
            return ctx.Livros.FirstOrDefault(e => e.IdLivro == id);
        }

        public void Cadastrar(Livro novoLivro)
        {
            ctx.Livros.Add(novoLivro);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Livro livroBuscado = ctx.Livros.Find(id);
            ctx.Livros.Remove(livroBuscado);
            ctx.SaveChanges();
        }

        public List<Livro> Listar()
        {
            return ctx.Livros.ToList();
        }
    }
}
