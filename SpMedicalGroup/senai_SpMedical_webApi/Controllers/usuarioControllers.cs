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
    [Produces ("application/json")]
    [Route("api/[controller]")]
    [ApiController]

    [Authorize]
    public class usuarioControllers : ControllerBase
    {
        private IusuarioRepository _usuarioRepository { get; set; }

        public usuarioControllers()
        {
            _usuarioRepository = new usuarioRepository();
        }

        /// <summary>
        /// Reponsavel por retornar uma lista dos Usuarios
        /// </summary>
        /// <returns>listaUsuarios</returns>
        [HttpGet]
        public IActionResult get()
        {
            List<Usuario> listaUsuarios = _usuarioRepository.Listar();

            return Ok(listaUsuarios);
        }

        /// <summary>
        /// Responsavel por fazer a busca de um determinado usuario
        /// </summary>
        /// <param name="id"></param>
        /// <returns>retorna o usuario solicitado</returns>
        [HttpGet("{id}")]
        public IActionResult getID(int id)
        {
            try
            {
                return Ok(_usuarioRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(Usuario novo)
        {
            try
            {
                _usuarioRepository.Cadastrar(novo);

                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Usuario att)
        {
            try
            {
                _usuarioRepository.Atualizar(id, att);

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
                _usuarioRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
