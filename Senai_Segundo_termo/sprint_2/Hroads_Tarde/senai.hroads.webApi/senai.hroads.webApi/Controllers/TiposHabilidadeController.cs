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
    public class TiposHabilidadeController : Controller
    {
        private ITipoHabilidadeRepository _tiposRepository { get; set; }
        public TiposHabilidadeController()
        {
            _tiposRepository = new TipoHabilidadeRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_tiposRepository.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_tiposRepository.BuscarPorId(id));
        }

        [HttpPost]
        public IActionResult Post(TiposHabilidade novoTipo)
        {
            _tiposRepository.Cadastrar(novoTipo);

            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, TiposHabilidade tipoAtualizado)
        {
            _tiposRepository.Atualizar(id, tipoAtualizado);

            return StatusCode(204);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _tiposRepository.Deletar(id);

            return StatusCode(204);
        }
    }
}
