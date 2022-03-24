using Senai.Peoples.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Interface
{
    interface ItipoUsuarioRepository
    {
        List<tipoUsuarioDomain> ListarTodos();

        tipoUsuarioDomain BuscarPorId(int id);

        void Atualizar(tipoUsuarioDomain novainfos);

        void Deletar(int id);
    }
}
