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
    public class situacaoController : ControllerBase
    {
        private IsituacaoRepository _situacaoRepository { get; set; }

        public situacaoController()
        {
            _situacaoRepository = new situacaoRepository();
        }

        /// <summary>
        /// Reponsavel por retornar uma lista das situacoes
        /// </summary>
        /// <returns>listaSituacoes</returns>
        [HttpGet]
        public IActionResult get()
        {
            List<Situacao> listaSituacoes = _situacaoRepository.Listar();

            return Ok(listaSituacoes);
        }

        /// <summary>
        /// Responsavel por fazer a busca de uma determinada situacao
        /// </summary>
        /// <param name="id"></param>
        /// <returns>retorna a situacao solicitada</returns>
        [HttpGet("{id}")]
        public IActionResult getID(int id)
        {
            try
            {
                return Ok(_situacaoRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpPost]
        public IActionResult Post(Situacao novo)
        {
            try
            {
                _situacaoRepository.Cadastrar(novo);

                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Situacao att)
        {
            try
            {
                _situacaoRepository.Atualizar(id, att);

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
                _situacaoRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
