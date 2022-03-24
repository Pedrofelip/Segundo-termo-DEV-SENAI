using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai_SpMedical_webApi.Domains;
using senai_SpMedical_webApi.Interfaces;
using senai_SpMedical_webApi.Repositories;
using senai_SpMedical_webApi.viewModel;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace senai_SpMedical_webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class loginController : ControllerBase
    {
        private IusuarioRepository _usuarioRepository { get; set; }

        public loginController()
        {
            _usuarioRepository = new usuarioRepository();
        }

        [HttpPost]
        public IActionResult Post(loginViewModel login)
        {
            try
            {

                Usuario usuarioBuscado = _usuarioRepository.Login(login.Email, login.senha);

                if (usuarioBuscado == null)
                {
                    return NotFound("E-mail ou senha inválidos!");
                }


                var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),

                        new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),

                        new Claim(ClaimTypes.Role, usuarioBuscado.IdTipoUsuario.ToString()),

                        new Claim("role", usuarioBuscado.IdTipoUsuario.ToString()),

                        new Claim(JwtRegisteredClaimNames.Name, usuarioBuscado.Nome)
                    };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("pedrinho-lindinho-davovo"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "SPMedGroup.webApi",
                    audience: "SPMedGroup.webApi",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds
                );


                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }

            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
