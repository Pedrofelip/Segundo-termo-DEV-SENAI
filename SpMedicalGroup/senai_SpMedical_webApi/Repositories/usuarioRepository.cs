using senai_SpMedical_webApi.Contexts;
using senai_SpMedical_webApi.Domains;
using senai_SpMedical_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_SpMedical_webApi.Repositories
{
    public class usuarioRepository : IusuarioRepository
    {
        SPMedContext ctx = new SPMedContext();
        public void Atualizar(int id, Usuario usuarioAtualizado)
        {
            Usuario usuarioBuscado = ctx.Usuarios.Find(id);

            if (usuarioAtualizado != null)
            {
                usuarioBuscado = usuarioAtualizado;
            }

            ctx.Usuarios.Update(usuarioBuscado);

            ctx.SaveChanges();
        }

        public Usuario BuscarPorId(int id)
        {
            return ctx.Usuarios.FirstOrDefault(e => e.IdUsuario == id);
        }

        public void Cadastrar(Usuario novoUsuario)
        {
            ctx.Usuarios.Add(novoUsuario);
            ctx.SaveChanges();

        }

        public void Deletar(int id)
        {
            Usuario usuario = BuscarPorId(id);
            ctx.Usuarios.Remove(usuario);
            ctx.SaveChanges();

        }

        public List<Usuario> Listar()
        {
            return ctx.Usuarios.ToList();
        }

        public Usuario Login(string email, string senha)
        {         
                return ctx.Usuarios.FirstOrDefault(u => u.Email == email && u.senha == senha);
        }
    }
}
