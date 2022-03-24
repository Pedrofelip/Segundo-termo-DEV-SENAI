using senai_lovePets_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_lovePets_webApi.Interfaces
{
    interface ITipoPetRepository
    {
        List<TipoPet> ListarTodos();

        TipoPet BuscarPorId(int idTipoPet);

        void cadastrar(TipoPet novoTipoPet);

        void atualizar(int idTipoPet, TipoPet tipoPetAtualizado);

        void deletar(int idTipoPet);
    }
}
