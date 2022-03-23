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
    [Produces("application/Json")]
    [Route("api/[controller]")]
    [ApiController]
    public class generosController : ControllerBase
    {
        private IGenerorepository _generorepository { get; set; }

        public generosController()
        {
            _generorepository = new generoRepository();
        }

        [HttpGet]
        public IActionResult get()
        {
            List<generoDomain> listaGenero = _generorepository.ListarTodos();

            return Ok(listaGenero);
        }
        [HttpGet("{id}")]
        public IActionResult getBusca(int id)
        {
            generoDomain genero = _generorepository.BuscarPorId(id);

            if (genero == null)
            {
                return NotFound("nenhum genero foi encontrado");
            }
            return Ok(genero);
        }

        [HttpPost]
        public IActionResult post(generoDomain novoGenero)
        {
            _generorepository.Cadastrar(novoGenero);

                return StatusCode(201);
        }

        [HttpDelete("{id}")]
        public IActionResult delete (int id)
        {
            _generorepository.Deletar(id);
            return StatusCode(204);
        }
        
        [HttpPut]
        public IActionResult putCorpo(generoDomain generoAtt)
        {
            generoDomain generoBuscado = _generorepository.BuscarPorId(generoAtt.idGenero);

            if (generoBuscado != null)
            {
                try
                {
                    _generorepository.AtualizarIdCorpo(generoAtt);
                    return NoContent();
                }
                catch (Exception erro)
                {
                    return BadRequest(erro);
                }
            }
            return NotFound(new { mensagem = "genero não encontrado" });
        }

        [HttpPut("{id}")]

        public IActionResult putUrl(int id, generoDomain generoAtt)
        {
            generoDomain generoBuscado = _generorepository.BuscarPorId(id);

            if (generoBuscado != null)
            {
                try
                {
                    _generorepository.AtualizarIdUrl(id, generoAtt);
                    return NoContent();
                }
                catch (Exception erro)
                {
                    return BadRequest(erro);
                }
            }
            return NotFound(new { mensagem = "nenhum genero foi encontrado" });
        }
    }
}
