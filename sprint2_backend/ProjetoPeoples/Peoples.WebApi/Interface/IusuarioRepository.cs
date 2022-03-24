using Senai.Peoples.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Interface
{
    interface IusuarioRepository
    {
        List<usuarioDomain> ListarTodos();

        usuarioDomain BuscarPorId(int id);

        usuarioDomain Login(string email, string senha);

        void Atualizar(usuarioDomain novaInfos);

        void Deletar(int id);

        void Cadastrar(usuarioDomain novoUsuario);
    }
}
