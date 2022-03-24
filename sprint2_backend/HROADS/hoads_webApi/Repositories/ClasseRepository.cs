using Microsoft.EntityFrameworkCore;
using senai.hroads.webApi.Contexts;
using senai.hroads.webApi.Domains;
using senai.hroads.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Repositories
{
    public class ClassRepository : IClasseRepository
    {
        /// <summary>
        /// Objeto contexto por onde serão chamados os métodos do Entity Framework Core
        /// </summary>
        HROADContext ctx = new HROADContext();

        //Implementação dos métodos (CRUD)

        public void Cadastrar(Classe classe)
        {
            ctx.Classes.Add(classe);
            ctx.SaveChanges();
        }

        public List<Classe> Listar()
        {
            return ctx.Classes.Include(c => c.Personagens).ToList();
        }

        public Classe BuscarPorId(int id)
        {
            return ctx.Classes.Find(id);
        }

        public void Atualizar(int id, Classe classeAtualizada)
        {
            Classe classeBuscada = ctx.Classes.Find(id);

            if (classeAtualizada.Nome != null)
            {
                classeBuscada.Nome = classeAtualizada.Nome;
            }

            ctx.Classes.Update(classeBuscada);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Classe classeBuscada = ctx.Classes.Find(id);

            ctx.Classes.Remove(classeBuscada);

            ctx.SaveChanges();
        }

    }
}
