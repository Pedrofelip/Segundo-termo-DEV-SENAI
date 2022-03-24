using senai_lovePets_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_lovePets_webApi.Interfaces
{
    interface ISituacaoRepository
    {
        List<Situacao> ListarTodos();

        Situacao BuscarPorId(int idSituacao);

        void cadastrar(Situacao novaSituacao);

        void atualizar(int idSituacao, Situacao situacaoAtualizada);

        void deletar(int idSituacao);
    }
}
