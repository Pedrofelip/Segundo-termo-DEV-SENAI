using senai_lovePets_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_lovePets_webApi.Interfaces
{
    interface IRacaRepository
    {
        List<Raca> ListarTodos();

        Raca BuscarPorId(int idRaca);

        void cadastrar(Raca novaRaca);

        void atualizar(int idRaca, Raca racaAtualizada);

        void deletar(int idRaca);
    }
}
