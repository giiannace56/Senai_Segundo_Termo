using Microsoft.AspNetCore.Mvc;
using senai.hroads.webApi.Domains;
using senai.hroads.webApi.Interfaces;
using senai.hroads.webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PersonagenController : Controller
    {
        private IPersonagemRepository _personagensRepository { get; set; }
        public PersonagenController()
        {
            _personagensRepository = new PersonagenRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_personagensRepository.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_personagensRepository.BuscarPorId(id));
        }

        [HttpPost]
        public IActionResult Post(Personagen novoPersonagem)
        {
            _personagensRepository.Cadastrar(novoPersonagem);

            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Personagen personagemAtualizado)
        {
            _personagensRepository.Atualizar(id, personagemAtualizado);

            return StatusCode(204);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _personagensRepository.Deletar(id);

            return StatusCode(204);
        }
    }
}
