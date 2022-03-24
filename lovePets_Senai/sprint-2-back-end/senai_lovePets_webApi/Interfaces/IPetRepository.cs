using senai_lovePets_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_lovePets_webApi.Interfaces
{
    interface IPetRepository
    {
        List<Pet> ListarTodos();

        Pet BuscarPorId(int idPet);

        void cadastrar(Pet novoPet);

        void atualizar(int idpet, Pet petAtualizado);

        void deletar(int idPet);
    }
}
