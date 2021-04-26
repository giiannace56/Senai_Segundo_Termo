using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai.inlock.webApi_.Interfaces;
using senai.inlock.webApi_.Models;
using senai.inlock.webApi_.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace senai.inlock.webApi_.Controllers
{
    [Produces("application/JSON")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private ILoginRepository _loginRepository { get; set; }

        public LoginController() 
        {
            _loginRepository = new LoginRepository();
        }

        public IActionResult BuscarLogin(string email, string senha)
        {

            Login LoginBuscado = _loginRepository.BuscarLogin(email, senha);

            if (LoginBuscado == null)
            {

                return NotFound("Usuário ou senha inválidos");

            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, LoginBuscado.Email)
                ,new Claim(JwtRegisteredClaimNames.Jti, LoginBuscado.IdUsuario.ToString())
                ,new Claim( ClaimTypes.Role , LoginBuscado.IdTipoUsuario.ToString()) 
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("chave-de-segurança-autenticação"));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(

                issuer: "senai.Inlock.webApi",
                audience: "senai.Inlock.webApi",
                claims: claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: cred

             );
            

            return StatusCode(200);
        }
    }
}
