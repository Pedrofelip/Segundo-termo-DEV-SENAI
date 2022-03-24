using CZBooks_webApi.Contexts;
using CZBooks_webApi.Domains;
using CZBooks_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CZBooks_webApi.Repositories
{
    public class tipoUsuarioRepository : ITipoUsuarioRepository
    {
        CZContext ctx = new CZContext();

        public void Atualizar(int id, TipoUsuario novoTipo)
        {
            TipoUsuario tipoUsuarioBuscado = ctx.TipoUsuarios.Find(id);

            if (novoTipo != null)
            {
                tipoUsuarioBuscado = novoTipo;
            }
            ctx.TipoUsuarios.Update(tipoUsuarioBuscado);
            ctx.SaveChanges();
        }

        public TipoUsuario BuscarPorId(int id)
        {
            return ctx.TipoUsuarios.FirstOrDefault(e => e.IdTipoUsuario == id);
        }

        public void Cadastrar(TipoUsuario novoTipo)
        {
            ctx.TipoUsuarios.Add(novoTipo);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            TipoUsuario tipoBuscado = ctx.TipoUsuarios.Find(id);
            ctx.TipoUsuarios.Remove(tipoBuscado);
            ctx.SaveChanges();
        }

        public List<TipoUsuario> Listar()
        {
            return ctx.TipoUsuarios.ToList();
        }
    }
}
