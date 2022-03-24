using senai_SpMedical_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_SpMedical_webApi.Interfaces
{
    interface IespecialidadeRepository
    {
        List<Especialidade> Listar();
        Especialidade BuscarPorId(int id);
        void Cadastrar(Especialidade novoMedico);
        void Atualizar(int id, Especialidade tipoEventoAtualizado);
        void Deletar(int id);
    }
}
