using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_filmes_webApi.domains;
using senai_filmes_webApi.interfaces;
using senai_filmes_webApi.repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webApi.controllers
{
    [Produces ("application/Json")]
    [Route("api/[controller]")]
    [ApiController]
    public class filmesController : ControllerBase
    {
        private IFilmeRepository _filmesRepository { get; set; }

        public filmesController()
        {
            _filmesRepository = new filmeRepository();
        }

        [HttpGet]
        public IActionResult get()
        {
            List<filmeDomain> listaFilmes = _filmesRepository.ListarTodos();

            return Ok(listaFilmes);
        }
        [HttpGet ("{id}")]
        public IActionResult getBusca(int id)
        {
            filmeDomain filme = _filmesRepository.BuscarPorId(id);
            if (filme == null)
            {
                return NotFound("nenhum filme foi encontrado");
            }
            return Ok(filme);
        }

        [HttpPost]
        public IActionResult post(filmeDomain novoFilme)
        {
            _filmesRepository.Cadastrar(novoFilme);

            return StatusCode(201);
        }
        [HttpDelete("{id}")]
        public IActionResult delete(int id)
        {
            _filmesRepository.Deletar(id);
            return StatusCode(204);
        }
        [HttpPut]
        public IActionResult putCorpo(filmeDomain filmeAtt)
        {
            filmeDomain filmeBuscado = _filmesRepository.BuscarPorId(filmeAtt.idFilme);

            if ( filmeBuscado != null)
            {
                try
                {
                    _filmesRepository.AtualizarIdCorpo(filmeAtt);
                    return NoContent();
                }
                catch (Exception erro)
                {
                    return BadRequest(erro);
                }
            }
            return NotFound(new { mensagem = "filme não encontrado" });
        }

        [HttpPut("{id}")]

        public IActionResult putUrl(int id, filmeDomain filmeAtt)
        {
            filmeDomain filmeBuscado = _filmesRepository.BuscarPorId(id);

            if (filmeBuscado != null)
            {
                try
                {
                    _filmesRepository.AtualizarIdUrl(id, filmeAtt);
                    return NoContent();
                }
                catch (Exception erro)
                {
                    return BadRequest(erro);
                }
            }
            return NotFound(new { mensagem = "nenhum filme foi encontrado" });
        }
    }
}
