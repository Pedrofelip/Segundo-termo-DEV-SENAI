using Senai.Peoples.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Interface
{
    interface IfuncionarioRepository
    {
        List<funcionarioDomain> ListaTodos();

        funcionarioDomain BuscarPorId(int id);

        void Deletar(int id);

        void Atualizar(funcionarioDomain funcionario);

        void AtualizarPelaUrl(int id, funcionarioDomain funcionario);

        void Cadastrar(funcionarioDomain funcionario);

        
    }
}
