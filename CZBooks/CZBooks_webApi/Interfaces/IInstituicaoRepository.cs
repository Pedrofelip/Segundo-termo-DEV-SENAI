using CZBooks_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CZBooks_webApi.Interfaces
{
    interface IInstituicaoRepository
    {
        List<Instituico> Listar();

        Instituico BuscarPorId(int id);

        void Cadastrar(Instituico novaInstituicao);

        void Atualizar(int id, Instituico novaInstituicao);

        void Deletar(int id);
    }

}
