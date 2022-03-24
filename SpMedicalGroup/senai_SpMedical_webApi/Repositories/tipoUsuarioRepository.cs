using senai_SpMedical_webApi.Contexts;
using senai_SpMedical_webApi.Domains;
using senai_SpMedical_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_SpMedical_webApi.Repositories
{
    public class tipoUsuarioRepository : ItipoUsuarioRepository
    {
        SPMedContext ctx = new SPMedContext(); 
        public void Atualizar(int id, TipoUsuario tipoUsuarioAtualizado)
        {
           TipoUsuario tipoUsuarioBuscado = ctx.TipoUsuarios.Find(id);

            if (tipoUsuarioAtualizado != null)
            {
                tipoUsuarioBuscado = tipoUsuarioAtualizado;
            }

            ctx.TipoUsuarios.Update(tipoUsuarioBuscado);

            ctx.SaveChanges();
        }

        public TipoUsuario BuscarPorId(int id)
        {
            return ctx.TipoUsuarios.FirstOrDefault(e => e.IdTipoUsuario == id);
        }

        public void Cadastrar(TipoUsuario novoTipoUsuario)
        {
            ctx.TipoUsuarios.Add(novoTipoUsuario);
            ctx.SaveChanges();

        }

        public void Deletar(int id)
        {
            TipoUsuario tipoUsuario = BuscarPorId(id);
            ctx.TipoUsuarios.Remove(tipoUsuario);
            ctx.SaveChanges();

        }

        public List<TipoUsuario> Listar()
        {
            return ctx.TipoUsuarios.ToList();
        }
    }
}
