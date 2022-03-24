using senai_filmes_webApi.domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webApi.interfaces
{
    public interface IGenerorepository
    {
        List<generoDomain> ListarTodos();

        generoDomain BuscarPorId(int id);

        void Cadastrar(generoDomain novoGenero);

        void AtualizarIdCorpo(generoDomain update);

        void AtualizarIdUrl(int id, generoDomain update);

        void Deletar(int id);


    }
}
