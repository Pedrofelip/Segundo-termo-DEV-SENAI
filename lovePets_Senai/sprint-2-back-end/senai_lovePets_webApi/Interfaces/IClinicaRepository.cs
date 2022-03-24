using senai_lovePets_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_lovePets_webApi.Interfaces
{
    interface IClinicaRepository
    {
        List<Clinica> ListarTodos();

        Clinica BuscarPorId(int idClinica);

        void cadastrar(Clinica novaClinica);

        void atualizar(int idClinica, Clinica clinicaAtualizada);

        void deletar(int idClinica);
    }
}
