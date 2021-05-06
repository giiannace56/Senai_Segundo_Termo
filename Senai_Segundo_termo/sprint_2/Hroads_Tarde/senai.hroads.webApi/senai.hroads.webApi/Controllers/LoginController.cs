using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai.hroads.webApi.Domains;
using senai.hroads.webApi.Interfaces;
using senai.hroads.webApi.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private ILoginRepository _loginRepository { get; set; }

        public LoginController()
        {
            _loginRepository = new LoginRepository();
        }

        [HttpPost("login")]
        public IActionResult Login(Usuario login)
        {
            Usuario usuarioBuscado = _loginRepository.BuscarPorEmailSenha(login.EmailsUsuarios, login.SenhasUsuarios);

            if (usuarioBuscado == null)
            {
                return NotFound("E-mail ou senha inválidos!");
            }
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.EmailsUsuarios),
                new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuarios.ToString()),
                new Claim(ClaimTypes.Role, usuarioBuscado.IdTiposUsuariosNavigation.TiposUsuarios)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("hroads-key"));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                    issuer: "hroads.webApi",
                    audience: "hroads.webApi",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds
                );
            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });
        }
    }
}
