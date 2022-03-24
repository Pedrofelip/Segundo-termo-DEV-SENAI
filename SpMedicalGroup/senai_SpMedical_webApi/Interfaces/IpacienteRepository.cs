using senai_SpMedical_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_SpMedical_webApi.Interfaces
{
    interface IpacienteRepository
    {
        List<Paciente> Listar();
        Paciente BuscarPorId(int id);
        void Cadastrar(Paciente novoPaciente);
        void Atualizar(int id, Paciente pacienteAtualizado);
        void Deletar(int id);
    }
}
