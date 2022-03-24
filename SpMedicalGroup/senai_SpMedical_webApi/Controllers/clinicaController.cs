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
    public class clinicaController : ControllerBase
    {
        private IclinicaRepository _clinicaRepository { get; set; }

        public clinicaController()
        {
            _clinicaRepository = new clinicaRepository();
        }

        /// <summary>
        /// Reponsavel por retornar uma lista das clinicas
        /// </summary>
        /// <returns>listaClinicas</returns>
        [HttpGet]
        public IActionResult get()
        {
            List<Clinica> listaClinicas = _clinicaRepository.Listar();

            return Ok(listaClinicas);
        }
        /// <summary>
        /// Responsavel por fazer a busca de uma determinada clinica
        /// </summary>
        /// <param name="id"></param>
        /// <returns>retorna a clinica solicitada</returns>
        [HttpGet("{id}")]
        public IActionResult getID(int id)
        {
            try
            {
                return Ok(_clinicaRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(Clinica novo)
        {
            try
            {
                _clinicaRepository.Cadastrar(novo);

                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Clinica att)
        {
            try
            {
                _clinicaRepository.Atualizar(id, att);

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
                _clinicaRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
