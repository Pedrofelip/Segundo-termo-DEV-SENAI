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
    public class tipoUsuarioController : ControllerBase
    {
        private ItipoUsuarioRepository _tipoUsuarioRepository { get; set; }

        public tipoUsuarioController()
        {
            _tipoUsuarioRepository = new tipoUsuarioRepository();
        }

        /// <summary>
        /// Reponsavel por retornar uma lista dos tipos de usuarios
        /// </summary>
        /// <returns>listaTiposUsuarios</returns>
        [HttpGet]
        public IActionResult get()
        {
            List<TipoUsuario> listaTiposUsuarios = _tipoUsuarioRepository.Listar();

            return Ok(listaTiposUsuarios);
        }

        /// <summary>
        /// Responsavel por fazer a busca de um determinado tipoUsuario
        /// </summary>
        /// <param name="id"></param>
        /// <returns>retorna o tipoUsuario solicitado</returns>
        [HttpGet("{id}")]
        public IActionResult getID(int id)
        {
            try
            {
                return Ok(_tipoUsuarioRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpPost]
        public IActionResult Post(TipoUsuario novo)
        {
            try
            {
                _tipoUsuarioRepository.Cadastrar(novo);

                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, TipoUsuario att)
        {
            try
            {
                _tipoUsuarioRepository.Atualizar(id, att);

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
                _tipoUsuarioRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
