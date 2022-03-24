using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Interface;
using Senai.Peoples.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Controllers
{
    [Produces("application/Json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private IusuarioRepository _usuarioRepository { get; set; }

        public UsuariosController()
        {
            _usuarioRepository = new usuarioRepository();
        }

        [HttpPost("Login")]
        public IActionResult Login(usuarioDomain login)
        {
            usuarioDomain usuario = _usuarioRepository.Login(login.email, login.senha);

            if (usuario == null)
            {
                return NotFound("login incorreto, verifique se email e senha estão corretos");
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, usuario.email),
                new Claim(JwtRegisteredClaimNames.Jti, usuario.idUsuario.ToString()),
                new Claim(ClaimTypes.Role, usuario.permissao.ToString())
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("pedro-felipe-barros"));

            var credencial = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token1 = new JwtSecurityToken(
                issuer: "Peoples.webApi",
                audience: "Peoples.webApi",
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credencial);

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token1)
            });
        }

        [Authorize]
        [HttpGet]
        public IActionResult ListarTodos()
        {
            List<usuarioDomain> ListaUsuarios = _usuarioRepository.ListarTodos();

            return Ok(ListaUsuarios);

        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            _usuarioRepository.Deletar(id);

            return StatusCode(204);
        }

        [HttpPost]
        public IActionResult Cadastrar(usuarioDomain infos)
        {
            _usuarioRepository.Cadastrar(infos);

            return StatusCode(201);
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            usuarioDomain usuario = _usuarioRepository.BuscarPorId(id);

            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }

        [HttpPut]
        public IActionResult Atualizar(int id, usuarioDomain novasinfos)
        {
            usuarioDomain usuario = _usuarioRepository.BuscarPorId(id);

            if (usuario != null)
            {
                _usuarioRepository.Atualizar(novasinfos);

                return StatusCode(204);
            }
            return NotFound("O usuario que vc quer atualizar não existe");

        }

    }
}
