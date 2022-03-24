using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_SpMedical_webApi.Domains;
using senai_SpMedical_webApi.Interfaces;
using senai_SpMedical_webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_SpMedical_webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class pacienteController : ControllerBase
    {
        private IpacienteRepository _pacienteRepository { get; set; }

        public pacienteController()
        {
            _pacienteRepository = new pacienteRepository();
        }

        /// <summary>
        /// Reponsavel por retornar uma lista dos pacientes
        /// </summary>
        /// <returns>listaPacientes</returns>
        [HttpGet]
        public IActionResult get()
        {
            List<Paciente> listaPacientes = _pacienteRepository.Listar();

            return Ok(listaPacientes);
        }

        /// <summary>
        /// Responsavel por fazer a busca de um determinado paciente
        /// </summary>
        /// <param name="id"></param>
        /// <returns>retorna o paciente solicitado</returns>
        [HttpGet("{id}")]
        public IActionResult getID(int id)
        {
            try
            {
                return Ok(_pacienteRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpPost]
        public IActionResult Post(Paciente novo)
        {
            try
            {
                _pacienteRepository.Cadastrar(novo);

                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Paciente att)
        {
            try
            {
                _pacienteRepository.Atualizar(id, att);

                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _pacienteRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
