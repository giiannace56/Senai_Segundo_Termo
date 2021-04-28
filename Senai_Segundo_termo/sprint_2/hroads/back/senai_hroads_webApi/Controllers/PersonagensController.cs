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
    public class PersonagensController : ControllerBase
    {
        private IPersonagemRepository _personagensRepository { get; set; }

        public PersonagensController()
        {
            _personagensRepository = new PersonagemRepository();
        }

        /// <summary>
        /// Lista todos os personagens (com suas classes incluidas)
        /// </summary>
        /// <returns>Uma lista de personagens e um status code 200 - Ok</returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_personagensRepository.Listar());
        }

        /// <summary>
        /// Busca um personagem através de seu id
        /// </summary>
        /// <param name="id">Id do personagem a ser buscado</param>
        /// <returns>Um personagem buscado e um status code 200 - Ok</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_personagensRepository.BuscarPorId(id));
        }

        /// <summary>
        /// Cadastra um novo personagem
        /// </summary>
        /// <param name="novoPersonagem">Novo personagem a ser cadastrado</param>
        /// <returns>Um status code 201 - Created</returns>
        [HttpPost]
        public IActionResult Post(Personagem novoPersonagem)
        {
            _personagensRepository.Cadastrar(novoPersonagem);

            return StatusCode(201);
        }

        /// <summary>
        /// Atualiza um personagem
        /// </summary>
        /// <param name="id">Id do personagem a ser atualizado</param>
        /// <param name="personagemAtualizado">Personagem atualizado</param>
        /// <returns>Um status code 204 - No Content</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, Personagem personagemAtualizado)
        {
            _personagensRepository.Atualizar(id, personagemAtualizado);

            return StatusCode(204);
        }

        /// <summary>
        /// Deleta o personagem especificado
        /// </summary>
        /// <param name="id">Id do personagem a ser deletado</param>
        /// <returns>Um status code 204 - No Content</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _personagensRepository.Deletar(id);

            return StatusCode(204);
        }
    }
}
