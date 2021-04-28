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
    public class HabilidadesController : ControllerBase
    {
        private IHabilidadeRepository _habilidadeRepository { get; set; }

        public HabilidadesController()
        {
            _habilidadeRepository = new HabilidadeRepository();
        }

        /// <summary>
        /// Lista todas as habilidades
        /// </summary>
        /// <returns>Uma lista de habilidades e um status code 200 - Ok</returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_habilidadeRepository.Listar());
        }

        /// <summary>
        /// Busca uma habilidade através de seu id
        /// </summary>
        /// <param name="id">Id da habilidade a ser buscado</param>
        /// <returns>Uma habilidade buscada e um status code 200 - Ok</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_habilidadeRepository.BuscarPorId(id));
        }

        /// <summary>
        /// Cadastra uma nova habilidade
        /// </summary>
        /// <param name="novahabilidade">Nova habilidade a ser cadastrado</param>
        /// <returns>Um status code 201 - Created</returns>
        [HttpPost]
        public IActionResult Post(Habilidade novaHabilidade)
        {
            _habilidadeRepository.Cadastrar(novaHabilidade);

            return StatusCode(201);
        }

        /// <summary>
        /// Atualiza uma habilidade
        /// </summary>
        /// <param name="id">Id da habilidade a ser atualizada</param>
        /// <param name="habilidadeAtualizada">habilidade atualizada</param>
        /// <returns>Um status code 204 - No Content</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, Habilidade habilidadeAtualizada)
        {
            _habilidadeRepository.Atualizar(id,habilidadeAtualizada);

            return StatusCode(204);
        }

        /// <summary>
        /// Deleta a habilidade especificado
        /// </summary>
        /// <param name="id">Id da habilidade a ser deletada</param>
        /// <returns>Um status code 204 - No Content</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _habilidadeRepository.Deletar(id);

            return StatusCode(204);
        }
    }
}
