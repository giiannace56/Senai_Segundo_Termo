using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai_peoples_webAPI.Domains;
using senai_peoples_webAPI.Interfaces;
using senai_peoples_webAPI.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace senai_peoples_webAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public UsuariosController()
        {
            _usuarioRepository = new UsuarioRepository();
        }


        // LOGIN:

        public DateTime? DataTime { get; set; }

        [HttpPost("login")]
        public IActionResult Login(UsuarioDomain login)
        {
            // armazena a resposta do dado buscado
            UsuarioDomain usuarioBuscado = _usuarioRepository.Logar(login.email, login.senha);

            if (usuarioBuscado == null)
            {
                return NotFound("E-mail ou senha inválidos");
            }

            // caso encontre, prossegue para a criação do token:
            // define os dados que serão fornecidos no token
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.email),
                new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.idUsuario.ToString()),
                new Claim(ClaimTypes.Role, usuarioBuscado.idTipoUsuario.ToString()),
            };

            // define a chave secreta de acesso ao token:
            var secretkey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("peoples-chave-autenticacao"));

            var credentials = new SigningCredentials(secretkey, SecurityAlgorithms.HmacSha256);

            // gera o token:
            // define a composição do token
            var token = new JwtSecurityToken
            (
                issuer: "Peoples.webAPI",                // quem é o emissor do token - "Peoples.webAPI"
                audience: "Peoples.webAPI",              // quem é o desnitinatário do token - "Peoples.webAPI"
                claims: claims,                         // foi declarado tudo em cima (em array)
                expires: DateTime.Now.AddMinutes(30),   // valor de tempo que o token vai ter de vida (hora atual + 30min)
                signingCredentials: credentials         // credenciais do token
            );

            // retorna um status code 200 - Ok (com o token criado):
            return Ok(new
            {
                // pegou todos os campos de "token" e jogou dentro do return
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });
        }



        [Authorize(Roles = "1")] // verifica se o usuário está logado com a permissão de Administrador, caso não esteja, retornará um erro
        [HttpGet]
        public IActionResult Get()
        {
            List<UsuarioDomain> listaUsuario = _usuarioRepository.Listar();

            return Ok(listaUsuario);
        }

        [Authorize(Roles = "1")] // verifica se o usuário está logado com a permissão de Administrador, caso não esteja, retornará um erro
        /// http://localhost:5000/api/funcionarios/idFuncionario
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            UsuarioDomain usuarioBuscado = _usuarioRepository.BuscarPorId(id);

            if (usuarioBuscado == null)
            {
                return NotFound("Nenhum Usuário encontrado!");
            }

            return Ok(usuarioBuscado);
        }

        [Authorize(Roles = "1")] // verifica se o usuário está logado com a permissão de Administrador, caso não esteja, retornará um erro
        /// http://localhost:5000/api/funcionarios/idFuncionario
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // faz a chamada para o método .Deletar
            _usuarioRepository.Deletar(id);

            // retorna o status code 204 - No Content
            return StatusCode(204);
        }

        [Authorize] // verifica se o usuário está logado, caso não esteja, retorna um erro 401
        /// exemplo: http://localhost:5000/api/usuarios
        [HttpPost("cadastrar")]
        public IActionResult Post(UsuarioDomain novoUsuario)
        {
            try // tenta executar...
            {
                // se o conteúdo do email e/ou da senha do novo usuário estar vazio ou com um espaço em branco...
                if (String.IsNullOrWhiteSpace(novoUsuario.email))
                {
                    // retorna um status code 404 - Not Found com uma mensagem personalizada
                    return NotFound("Campo 'email' obrigatório!");
                }
                if (String.IsNullOrWhiteSpace(novoUsuario.senha))
                {
                    // retorna um status code 404 - Not Found com uma mensagem personalizada
                    return NotFound("Campo 'senha' obrigatório!");
                }

                // se estiver tudo preenchido...
                else
                    // faz a chamada para o método Cadastrar
                    _usuarioRepository.Cadastrar(novoUsuario);

                // e retorna o status code 201 - Created
                return StatusCode(201);
            }

            // se não conseguiu executar...
            catch (Exception codErro)
            {
                // retorna um status code 400 - BadRequest e o código do erro
                return BadRequest(codErro);
            }
        }
    }
}
