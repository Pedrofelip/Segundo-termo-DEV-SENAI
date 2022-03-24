using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.hroads.webApi.Domains;
using senai.hroads.webApi.Interfaces;
using senai.hroads.webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PersonagemController : ControllerBase
    {
        private IPersonagemRepository _personagemRepository { get; set; }


        public PersonagemController()
        {
            _personagemRepository = new PersonagemRepository();
        }

        /// <summary>
        /// Cadastra um novo personagem
        /// </summary>
  
        [Authorize(Roles = "1")]
        [HttpPost("Cadastrar")]
        public IActionResult Post(Personagem novoPersonagem)
        {

            _personagemRepository.Cadastrar(novoPersonagem);

            return StatusCode(201);
        }

        /// <summary>
        /// Lista todos os personagens
        /// </summary>
        [Authorize(Roles = "1,2")]
        [HttpGet("Listar")]
        public IActionResult Get()
        {
            return Ok(_personagemRepository.Listar());
        }

        /// <summary>
        /// Busca um personagem pelo seu id
        /// </summary>
        [Authorize(Roles = "1,2")]
        [HttpGet("Buscar/{id}")]
        public IActionResult GetById(int id)
        {
            if (_personagemRepository.BuscarPorId(id) == null)
            {
                return NotFound("Personagem não encontrado !");
            }
            return Ok(_personagemRepository.BuscarPorId(id));
        }

        /// <summary>
        /// Atualiza um personagem pelo seu id
        /// </summary>
        [Authorize(Roles = "1,2")]
        [HttpPut("Atualizar/{id}")]
        public IActionResult Put(int id, Personagem personagemAtualizado)
        {
            if (_personagemRepository.BuscarPorId(id) == null)
            {
                return NotFound
                    (new
                    {
                        mensagem = "Personagem não encontrado !",
                        erro = true
                    }
                    );
            }

            try
            {
                _personagemRepository.Atualizar(id, personagemAtualizado);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }

        }

        /// <summary>
        /// Deleta um personagem pelo seu id
        /// </summary>
        [Authorize(Roles = "1,2")]
        [HttpDelete("Deletar/{id}")]
        public IActionResult Delete(int id)
        {

            _personagemRepository.Deletar(id);


            return StatusCode(204);
        }
    }
}
