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
    public class medicoController : ControllerBase
    {
        private ImedicoRepository _medicoRepository { get; set; }

        public medicoController()
        {
            _medicoRepository = new medicoRepository();
        }

        /// <summary>
        /// Reponsavel por retornar uma lista dos medicos
        /// </summary>
        /// <returns>listaMedicos</returns>
        [HttpGet]
        public IActionResult get()
        {
            List<Medico> listaMedicos = _medicoRepository.Listar();

            return Ok(listaMedicos);
        }

        /// <summary>
        /// Responsavel por fazer a busca de um determinado medico
        /// </summary>
        /// <param name="id"></param>
        /// <returns>retorna o medico solicitado</returns>
        [HttpGet("{id}")]
        public IActionResult getID(int id)
        {
            try
            {
                return Ok(_medicoRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpPost]
        public IActionResult Post(Medico novo)
        {
            try
            {
                _medicoRepository.Cadastrar(novo);

                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Medico att)
        {
            try
            {
                _medicoRepository.Atualizar(id, att);

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
                _medicoRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
