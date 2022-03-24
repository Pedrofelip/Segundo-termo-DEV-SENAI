using Microsoft.AspNetCore.Authorization;
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

    [Authorize]
    public class agendamentoController : ControllerBase
    {
        private IagendamentoRepository _agendamentoRepository { get; set; }

        public agendamentoController()
        {
            _agendamentoRepository = new agendamentoRepository();
        }
        /// <summary>
        /// Reponsavel por retornar uma lista das consultas
        /// </summary>
        /// <returns>listaAgendamentos</returns>
        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult get()
        {
            List<Agendamento> listaAgendamentos = _agendamentoRepository.Listar();

            return Ok(listaAgendamentos);
        }
        /// <summary>
        /// Reponsavel por retornar uma lista das consultas de um determinado paciente
        /// </summary>
        /// <returns>listaAgendamentos</returns>
        [Authorize(Roles = "3")]
        [HttpGet("listaDoPaciente/{id}")]
        public IActionResult getPaciente(int id)
        {
            List<Agendamento> listaAgendamentos = _agendamentoRepository.ListaDoPaciente(id);

            return Ok(listaAgendamentos);
        }
        /// <summary>
        /// Reponsavel por retornar uma lista das consultas de um determinado medico
        /// </summary>
        /// <returns>listaAgendamentos</returns>
        [Authorize(Roles = "2")]
        [HttpGet("listaDoMedico/{id}")]
        public IActionResult getMedico(int id)
        {
            List<Agendamento> listaAgendamentos = _agendamentoRepository.ListaDoMedico(id);

            return Ok(listaAgendamentos);
        }

        /// <summary>
        /// Responsavel por fazer a busca de um determinado agendamento
        /// </summary>
        /// <param name="id"></param>
        /// <returns>retorna o agendamento solicitado</returns>
        [HttpGet("{id}")]
        public IActionResult getID(int id)
        {
            try
            {
                return Ok(_agendamentoRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Responsavel por cadastrar uma nova consulta
        /// </summary>
        /// <param name="novoAgendamento"></param>
        /// <returns>se tudo der certo retorna um status code 201(created)</returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(Agendamento novoAgendamento)
        {
            try
            {
                _agendamentoRepository.Cadastrar(novoAgendamento);

                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, Agendamento agendamentoAtualizado)
        {
            try
            {
                _agendamentoRepository.Atualizar(id, agendamentoAtualizado);

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
                _agendamentoRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
