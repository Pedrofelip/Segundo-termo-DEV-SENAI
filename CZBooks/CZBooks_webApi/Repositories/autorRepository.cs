using CZBooks_webApi.Contexts;
using CZBooks_webApi.Domains;
using CZBooks_webApi.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CZBooks_webApi.Repositories
{
    public class autorRepository : IAutorRepository
    {
        CZContext ctx = new CZContext();

        public void Atualizar(int id, Autore autorAtualizado)
        {
            Autore autorBuscado = ctx.Autores.Find(id);

            if(autorAtualizado != null)
            {
                autorBuscado = autorAtualizado;
            }
            ctx.Autores.Update(autorBuscado);
            ctx.SaveChanges();
        }

        public Autore BuscarPorId(int id)
        {
            return ctx.Autores.FirstOrDefault(e => e.IdAutor == id);
        }

        public void Cadastrar(Autore novoAutor)
        {
            ctx.Autores.Add(novoAutor);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Autore autorBuscado = ctx.Autores.Find(id);
            ctx.Autores.Remove(autorBuscado);
            ctx.SaveChanges();
        }

        public List<Autore> Listar()
        {
            return ctx.Autores.ToList();
        }

        public List<Autore> ListarMeusLivros()
        {
            return ctx.Autores.Include(e => e.Livros).ToList();
        }
    }
}
