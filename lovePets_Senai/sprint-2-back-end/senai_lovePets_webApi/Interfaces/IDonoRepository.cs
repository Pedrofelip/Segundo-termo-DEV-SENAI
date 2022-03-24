using senai_lovePets_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_lovePets_webApi.Interfaces
{
    interface IDonoRepository
    {
        List<Dono> ListarTodos();

        Dono BuscarPorId(int IdDono);

        void cadastrar(Dono novoDono);

        void atualizar(int idDono, Dono donoAtualizado);

        void deletar(int idDono);
    }
}
