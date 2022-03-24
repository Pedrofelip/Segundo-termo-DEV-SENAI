using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Interface;
using Senai.Peoples.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Controllers
{

    [Produces ("application/Json")]
    [Route("api/[controller]")]
    [ApiController]
    public class funcionariosController : ControllerBase
    {
        private IfuncionarioRepository _funcionarioRepository { get; set; }

        public funcionariosController()
        {
            _funcionarioRepository = new funcionarioRepository();
        }

        
        [HttpGet]
        public IActionResult get()
        {
            List<funcionarioDomain> ListaFuncionarios = _funcionarioRepository.ListaTodos();

            return Ok(ListaFuncionarios);
        }

        [HttpGet("{id}")]
        public IActionResult getBuscar(int id)
        {
            try
            {
                funcionarioDomain funcionario = _funcionarioRepository.BuscarPorId(id);
                if (funcionario != null)
                {
                    return Ok(funcionario);
                }
                return NotFound();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpPost]
        public IActionResult Cadastrar(funcionarioDomain funcionario)
        {
            try
            {
            _funcionarioRepository.Cadastrar(funcionario);

            return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                _funcionarioRepository.Deletar(id);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpPut]
        public IActionResult AtulizarPeloCorpo(funcionarioDomain funcionario)
        {
            funcionarioDomain funcionarioBuscado = _funcionarioRepository.BuscarPorId(funcionario.idFuncionario);

            if (funcionarioBuscado != null)
            {
                try
                {
                      _funcionarioRepository.Atualizar(funcionario);

                    return NoContent();
                }
                catch (Exception erro)
                {
                    return BadRequest(erro);
                }
            }
            return NotFound(new {mensagem = "nenhum funcionario foi encontrado" });
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarPelaUrl(int id, funcionarioDomain funcionario)
        {
            funcionarioDomain funcionarioBuscado = _funcionarioRepository.BuscarPorId(id);

            if (funcionarioBuscado != null)
            {
                try
                {
                    _funcionarioRepository.AtualizarPelaUrl(id, funcionario);

                    return NoContent();
                }
                catch (Exception erro)
                {
                    return BadRequest(erro);
                }
            }
            return NotFound(new {mensagem = "nenhum funcionario foi encontrado" });
        }

    }
}
