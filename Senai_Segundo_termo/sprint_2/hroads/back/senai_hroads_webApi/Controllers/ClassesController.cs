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
    public class ClassesController : ControllerBase
    {
        private IClasseRepository _classeRepository { get; set; }

        public ClassesController()
        {
            _classeRepository = new ClasseRepository();
        }

        /// <summary>
        /// Lista todas as classes
        /// </summary>
        /// <returns>Uma lista de classes e um status code 200 - Ok</returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_classeRepository.Listar());
        }

        /// <summary>
        /// Busca uma Classe através de seu id
        /// </summary>
        /// <param name="id">Id da Classe a ser buscado</param>
        /// <returns>Uma classe buscada e um status code 200 - Ok</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_classeRepository.BuscarPorId(id));
        }

        /// <summary>
        /// Cadastra uma nova Classe
        /// </summary>
        /// <param name="novaClasse">Nova Classe a ser cadastrado</param>
        /// <returns>Um status code 201 - Created</returns>
        [HttpPost]
        public IActionResult Post(Classe novaClasse)
        {
            _classeRepository.Cadastrar(novaClasse);

            return StatusCode(201);
        }

        /// <summary>
        /// Atualiza uma Classe
        /// </summary>
        /// <param name="id">Id da Classe a ser atualizada</param>
        /// <param name="ClasseAtualizado">Classe atualizada</param>
        /// <returns>Um status code 204 - No Content</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, Classe ClasseAtualizado)
        {
            _classeRepository.Atualizar(id, ClasseAtualizado);

            return StatusCode(204);
        }

        /// <summary>
        /// Deleta a Classe especificado
        /// </summary>
        /// <param name="id">Id da Classe a ser deletada</param>
        /// <returns>Um status code 204 - No Content</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _classeRepository.Deletar(id);

            return StatusCode(204);
        }
    }
}
