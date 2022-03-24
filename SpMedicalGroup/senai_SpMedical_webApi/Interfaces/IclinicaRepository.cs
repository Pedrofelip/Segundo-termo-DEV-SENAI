using senai_SpMedical_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_SpMedical_webApi.Interfaces
{
    interface IclinicaRepository
    {
        List<Clinica> Listar();
        Clinica BuscarPorId(int id);
        void Cadastrar(Clinica novaClinica);
        void Atualizar(int id, Clinica ClinicaAtualizada);
        void Deletar(int id);
    }
}
