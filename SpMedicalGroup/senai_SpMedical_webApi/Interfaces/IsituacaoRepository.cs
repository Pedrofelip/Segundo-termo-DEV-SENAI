using senai_SpMedical_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_SpMedical_webApi.Interfaces
{
    interface IsituacaoRepository
    {
        List<Situacao> Listar();
        Situacao BuscarPorId(int id);
        void Cadastrar(Situacao novaSituacao);
        void Atualizar(int id, Situacao situacaoAtualizada);
        void Deletar(int id);
    }
}
