using senai_SpMedical_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_SpMedical_webApi.Interfaces
{
    interface ImedicoRepository
    {
        List<Medico> Listar();
        Medico BuscarPorId(int id);
        void Cadastrar(Medico novoMedico);
        void Atualizar(int id, Medico medicoAtualizada);
        void Deletar(int id);
    }
}
