using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.inlock.webApi_.Interfaces;
using senai.inlock.webApi_.Models;
using senai.inlock.webApi_.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi_.Controllers
{

    [Produces("application/JSON")]
    [Route("api/[controller]")]
    [ApiController]
    public class JogosController : ControllerBase
    {

        private IJogosRepository _jogosRepository { get; set; }

        public JogosController()
        {

            _jogosRepository = new JogosRepository();

        }

        //Funcionando
        [HttpGet]
        public IActionResult Get()
        {

            List<Jogos> listarjogos = _jogosRepository.ListarJogos();

            return Ok(listarjogos);

        }

        //Funcionando

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {

            Jogos jogoBuscado = _jogosRepository.ListarId(id);

            if (jogoBuscado == null)
            {

                return NotFound("Nenhum Jogo Encontrado");

            }

            return Ok(jogoBuscado);

        }

        //Homologar
        [HttpPut("id")]
        public IActionResult AttId(int id, Jogos jogoatt)
        {

            Jogos jogoBuscado = _jogosRepository.ListarId(id);

            if (jogoBuscado == null)
            {

                return NotFound();

            }

            try
            {

                _jogosRepository.AtualizarPorId(id, jogoatt);
                return NoContent();

            }
            catch (Exception codErro)
            {

                return BadRequest(codErro);

            }

        }

        // HOMOLOGAR
        [HttpDelete]
        public IActionResult Excluir(int id)
        {

            _jogosRepository.ApagarPorId(id);

            return StatusCode(204);

        }

        //  HOMOLOGAR
        [HttpPost]
        public IActionResult Adicionar(Jogos novoJogo)
        {

            _jogosRepository.Cadastrar(novoJogo);

            return StatusCode(201);

        }

    }
}
