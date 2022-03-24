using CZBooks_webApi.Contexts;
using CZBooks_webApi.Domains;
using CZBooks_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CZBooks_webApi.Repositories
{
    public class categoriaRepository : ICategoriaRepository
    {
        CZContext ctx = new CZContext();

        public void Atualizar(int id, Categoria novaCategoria)
        {
            Categoria categoriaBuscado = ctx.Categorias.Find(id);

            if (novaCategoria != null)
            {
                categoriaBuscado = novaCategoria;
            }
            ctx.Categorias.Update(categoriaBuscado);
            ctx.SaveChanges();
        }

        public Categoria BuscarPorId(int id)
        {
            return ctx.Categorias.FirstOrDefault(e => e.Idcategoria == id);
        }

        public void Cadastrar(Categoria novaCategoria)
        {
            ctx.Categorias.Add(novaCategoria);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Categoria categoriaBuscada = ctx.Categorias.Find(id);
            ctx.Categorias.Remove(categoriaBuscada);
            ctx.SaveChanges();
        }

        public List<Categoria> Listar()
        {
            return ctx.Categorias.ToList();
        }
    }
}
