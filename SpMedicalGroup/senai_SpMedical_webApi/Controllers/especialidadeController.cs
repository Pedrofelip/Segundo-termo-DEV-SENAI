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
    public class especialidadeController : ControllerBase
    {
        private IespecialidadeRepository _especialidadeRepository { get; set; }

        public especialidadeController()
        {
            _especialidadeRepository = new especialidadeRepository();
        }

        /// <summary>
        /// Reponsavel por retornar uma lista das especialidades
        /// </summary>
        /// <returns>listaEspecialidades</returns>
        [HttpGet]
        public IActionResult get()
        {
            List<Especialidade> listaEspecialidade = _especialidadeRepository.Listar();

            return Ok(listaEspecialidade);
        }

        /// <summary>
        /// Responsavel por fazer a busca de uma determinada especialidade
        /// </summary>
        /// <param name="id"></param>
        /// <returns>retorna a especialidade solicitado</returns>
        [HttpGet("{id}")]
        public IActionResult getID(int id)
        {
            try
            {
                return Ok(_especialidadeRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpPost]
        public IActionResult Post(Especialidade novo)
        {
            try
            {
                _especialidadeRepository.Cadastrar(novo);

                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Especialidade att)
        {
            try
            {
                _especialidadeRepository.Atualizar(id, att);

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
                _especialidadeRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
