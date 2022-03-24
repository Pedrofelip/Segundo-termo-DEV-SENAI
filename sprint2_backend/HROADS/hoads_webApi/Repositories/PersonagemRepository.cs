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
    public class PersonagemRepository : IPersonagemRepository
    {
        /// <summary>
        /// Objeto contexto por onde serão chamados os métodos do Entity Framework Core
        /// </summary>
        HROADContext ctx = new HROADContext();

        //Implementação dos métodos (CRUD)

        public void Cadastrar(Personagem personagem)
        {
            ctx.Personagens.Add(personagem);

            ctx.SaveChanges();
        }

        public List<Personagem> Listar()
        {
            return ctx.Personagens.Include(p => p.IdClasseNavigation).ToList();
        }

        public Personagem BuscarPorId(int id)
        {
            return ctx.Personagens.Find(id);
        }

        public void Atualizar(int id, Personagem personagem)
        {
            Personagem personagemBuscado = ctx.Personagens.Find(id);

            if (personagem.Nome != null)
            {
                personagemBuscado.Nome = personagem.Nome;
            }
            if (personagemBuscado.MaxVida > 0)
            {
                personagemBuscado.MaxVida = personagem.MaxVida;
            }
            if (personagem.MaxMana > 0)
            {
                personagemBuscado.MaxMana = personagem.MaxMana;
            }

            ctx.Personagens.Update(personagemBuscado);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Personagem personagemBuscado = ctx.Personagens.Find(id);

            ctx.Personagens.Remove(personagemBuscado);

            ctx.SaveChanges();
        }

    }
}
