using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_peoples_webAPI.Domains;
using senai_peoples_webAPI.Interfaces;
using senai_peoples_webAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_peoples_webAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TipoUsuariosController : ControllerBase
    {
        private ITipoUsuarioRepository _tipoUsuarioRepository { get; set; }

        public TipoUsuariosController()
        {
            _tipoUsuarioRepository = new TipoUsuarioRepository();
        }

        [Authorize(Roles = "1")] // verifica se o usuário está logado com a permissão de Administrador, caso não esteja, retornará um erro
        [HttpGet]
        public IActionResult Get()
        {
            List<TipoUsuarioDomain> listaTipoUsuario = _tipoUsuarioRepository.Listar();

            return Ok(listaTipoUsuario);
        }

        [Authorize(Roles = "1")] // verifica se o usuário está logado com a permissão de Administrador, caso não esteja, retornará um erro
        /// http://localhost:5000/api/funcionarios/idFuncionario
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            TipoUsuarioDomain tipoUsuarioBuscado = _tipoUsuarioRepository.BuscarPorId(id);

            if (tipoUsuarioBuscado == null)
            {
                return NotFound("Nenhum Tipo de Usuário encontrado!");
            }

            return Ok(tipoUsuarioBuscado);
        }

        [Authorize(Roles = "1")] // verifica se o usuário está logado com a permissão de Administrador, caso não esteja, retornará um erro
        /// http://localhost:5000/api/funcionarios/idFuncionario
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // faz a chamada para o método .Deletar
            _tipoUsuarioRepository.Deletar(id);

            // retorna o status code 204 - No Content
            return StatusCode(204);
        }

        [Authorize(Roles = "1")] // verifica se o usuário está logado com a permissão de Administrador, caso não esteja, retornará um erro        /// http://localhost:5000/api/funcionarios/idFuncionario
        [HttpPut("{id}")]
        public IActionResult PutIdUrl(int id, TipoUsuarioDomain tipoUsuarioAtualizado)
        {
            // cria um objeto "tipoUsuarioBuscado" que irá receber o gênero buscado do banco de dados
            TipoUsuarioDomain tipoUsuarioBuscado = _tipoUsuarioRepository.BuscarPorId(id);

            // caso ele não seja encontrado, retorna um NotFoud com uma mensagem personalizada
            // e um bool para apresentar que houve um erro
            if (tipoUsuarioBuscado == null)
            {
                return NotFound(new { mensagem = "Tipo Usuário não encontrado!" });
            }

            // o "try/catch" serve para tratamento de erros
            // tenta atualizar o registro(tipoUsuario) || se não acontece nenhum erro...
            try
            {
                // faz a chamada para o método .AtualizarIdUrl()
                _tipoUsuarioRepository.Atualizar(id, tipoUsuarioAtualizado);

                // retorna um status code 204 - No Content
                return NoContent();
            }

            // caso ocorra algum erro...
            catch (Exception codErro)
            {
                // retorna um status code 400 - BadRequest e o código do erro
                return BadRequest(codErro);
            }
        }
    }
}
