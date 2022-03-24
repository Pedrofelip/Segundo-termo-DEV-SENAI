using senai_filmes_webApi.domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webApi.interfaces
{
    public interface IFilmeRepository
    {
        List<filmeDomain> ListarTodos();

        filmeDomain BuscarPorId(int id);

        void Cadastrar(filmeDomain novoFilme);

        void AtualizarIdCorpo(filmeDomain update);

        void AtualizarIdUrl(int id, filmeDomain update);

        void Deletar(int id);

    }
}
