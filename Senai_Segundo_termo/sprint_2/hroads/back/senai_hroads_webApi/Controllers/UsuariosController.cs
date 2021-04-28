using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_hroads_webApi.Domains;
using senai_hroads_webApi.Interfaces;
using senai_hroads_webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_hroads_webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private IUsuarioRepository _usuariosRepository { get; set; }

        public UsuariosController()
        {
            _usuariosRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Lista todos os usuários (com suas classes incluidas)
        /// </summary>
        /// <returns>Uma lista de usuários e um status code 200 - Ok</returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_usuariosRepository.Listar());
        }

        /// <summary>
        /// Busca um usuário através de seu id
        /// </summary>
        /// <param name="id">Id do usuário a ser buscado</param>
        /// <returns>Um usuário buscado e um status code 200 - Ok</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_usuariosRepository.BuscarPorId(id));
        }

        /// <summary>
        /// Cadastra um novo usuário
        /// </summary>
        /// <param name="novoUsuario">Novo usuário a ser cadastrado</param>
        /// <returns>Um status code 201 - Created</returns>
        [HttpPost]
        public IActionResult Post(Usuario novoUsuario)
        {
            _usuariosRepository.Cadastrar(novoUsuario);

            return StatusCode(201);
        }

        /// <summary>
        /// Atualiza um usuário
        /// </summary>
        /// <param name="id">Id do usuário a ser atualizado</param>
        /// <param name="usuarioAtualizado">usuário atualizado</param>
        /// <returns>Um status code 204 - No Content</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, Usuario usuarioAtualizado)
        {
            _usuariosRepository.Atualizar(id, usuarioAtualizado);

            return StatusCode(204);
        }

        /// <summary>
        /// Deleta o usuário especificado
        /// </summary>
        /// <param name="id">Id do usuário a ser deletado</param>
        /// <returns>Um status code 204 - No Content</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _usuariosRepository.Deletar(id);

            return StatusCode(204);
        }
    }
}
