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
    public class ClasseController : ControllerBase
    {
        private IClasseRepository _classeRepository1;

        private IClasseRepository Get_classeRepository()
        {
            return _classeRepository1;
        }

        private void Set_classeRepository(IClasseRepository value)
        {
            _classeRepository1 = value;
        }

        public ClasseController()
        {
            Set_classeRepository(new ClassRepository());
        }

        /// <summary>
        /// Cadastra uma nova classe
        /// </summary>
        [Authorize(Roles = "2")]
        [HttpPost("Cadastrar")]
        public IActionResult Post(Classe novaClasse)
        {

            Get_classeRepository().Cadastrar(novaClasse);

            return StatusCode(201);
        }

        /// <summary>
        /// Lista todas as classes
        /// </summary>
        [HttpGet("Listar")]
        public IActionResult Get()
        {
            return Ok(Get_classeRepository().Listar());
        }

        /// <summary>
        /// Busca uma classe pelo seu id
        /// </summary>
        [Authorize(Roles = "1,2")]
        [HttpGet("Buscar/{id}")]
        public IActionResult GetById(int id)
        {
            if (Get_classeRepository().BuscarPorId(id) == null)
            {
                return NotFound("Classe não encontrada !");
            }
            return Ok(Get_classeRepository().BuscarPorId(id));
        }

        /// <summary>
        /// Atualiza uma classe pelo seu id
        /// </summary>
        [Authorize(Roles = "1,2")]
        [HttpPut("Atualizar/{id}")]
        public IActionResult Put(int id, Classe classeAtualizada)
        {
            if (Get_classeRepository().BuscarPorId(id) == null)
            {
                return NotFound
                    (new
                    {
                        mensagem = "Classe não encontrada !",
                        erro = true
                    }
                    );
            }

            try
            {
                Get_classeRepository().Atualizar(id, classeAtualizada);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }

        }

        /// <summary>
        /// Deleta uma classe pelo seu id
        /// </summary>
        [Authorize(Roles = "1,2")]
        [HttpDelete("Deletar/{id}")]
        public IActionResult Delete(int id)
        {

            Get_classeRepository().Deletar(id);


            return StatusCode(204);
        }

    }
}
