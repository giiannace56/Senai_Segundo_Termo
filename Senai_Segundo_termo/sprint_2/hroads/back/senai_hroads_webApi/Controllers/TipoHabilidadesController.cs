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
    public class TipoHabilidadesController : ControllerBase
    {
        private ITipoHabilidadeRepository _tiposRepository { get; set; }

        public TipoHabilidadesController()
        {
            _tiposRepository = new TipoHabilidadeRepository();
        }

        /// <summary>
        /// Lista todos os tipos de habilidade (com suas classes incluidas)
        /// </summary>
        /// <returns>Uma lista de personagens e um status code 200 - Ok</returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_tiposRepository.Listar());
        }

        /// <summary>
        /// Busca um tipo de habilidade através de seu id
        /// </summary>
        /// <param name="id">Id do tipo de habilidade a ser buscado</param>
        /// <returns>Um tipo de habilidade buscado e um status code 200 - Ok</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_tiposRepository.BuscarPorId(id));
        }

        /// <summary>
        /// Cadastra um novo tipo de habilidade
        /// </summary>
        /// <param name="novoTipo">Novo tipo de habilidade a ser cadastrado</param>
        /// <returns>Um status code 201 - Created</returns>
        [HttpPost]
        public IActionResult Post(TipoHabilidade novoTipo)
        {
            _tiposRepository.Cadastrar(novoTipo);

            return StatusCode(201);
        }

        /// <summary>
        /// Atualiza um tipo de habilidade
        /// </summary>
        /// <param name="id">Id do tipo de habilidade a ser atualizado</param>
        /// <param name="tipoAtualizado">tipo de habilidade atualizado</param>
        /// <returns>Um status code 204 - No Content</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, TipoHabilidade tipoAtualizado)
        {
            _tiposRepository.Atualizar(id, tipoAtualizado);

            return StatusCode(204);
        }

        /// <summary>
        /// Deleta o tipo de habilidade especificado
        /// </summary>
        /// <param name="id">Id do tipo de habilidade a ser deletado</param>
        /// <returns>Um status code 204 - No Content</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _tiposRepository.Deletar(id);

            return StatusCode(204);
        }
    }
}
