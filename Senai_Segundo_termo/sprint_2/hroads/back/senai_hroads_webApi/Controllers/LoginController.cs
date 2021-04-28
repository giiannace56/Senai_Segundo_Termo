using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai_hroads_webApi.Domains;
using senai_hroads_webApi.Interfaces;
using senai_hroads_webApi.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace senai_hroads_webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private ILoginRepository _loginRepository { get; set; }

        public LoginController()
        {
            _loginRepository = new LoginRepository();
        }

        [HttpPost("login")]
        public IActionResult Login(Usuario login)
        {
            Usuario usuarioBuscado = _loginRepository.BuscarPorEmailSenha(login.Email, login.Senha);

            if (usuarioBuscado == null)
            {
                return NotFound("E-mail ou senha inválidos!");
            }
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),
                new Claim(ClaimTypes.Role, usuarioBuscado.IdTipoUsuarioNavigation.Tipo)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("hroads-key"));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                    issuer : "hroads.webApi",
                    audience : "hroads.webApi",
                    claims : claims,
                    expires : DateTime.Now.AddMinutes(30),
                    signingCredentials : creds
                );
            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });
        }
    }
}
