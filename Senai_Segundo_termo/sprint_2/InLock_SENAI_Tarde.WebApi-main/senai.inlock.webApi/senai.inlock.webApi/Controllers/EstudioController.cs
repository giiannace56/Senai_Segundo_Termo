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
    public class EstudioController : ControllerBase
    {

        private IEstudioRepository _estudioRepository { get; set; }

        public EstudioController()
        {

            _estudioRepository = new EstudioRepository();

        }

        //  HOMOLOGAR
        [HttpGet]
        public IActionResult List()
        {

            _estudioRepository.Listar();

            return StatusCode(200);

        }

        //  HOMOLOGAR
        [HttpGet("{id}")]
        public IActionResult ListId(int id)
        {

            _estudioRepository.ListarId(id);

            return StatusCode(200);

        }

        //  HOMOLOGAR
        [HttpPut("{id}")]
        public IActionResult AttId(int id, Estudios estudioatt)
        {

            Estudios estudioBuscado = _estudioRepository.ListarId(id);

            if (estudioBuscado == null)
            {

                return StatusCode(404);

            }

            try
            {

                _estudioRepository.AtualizarId(id, estudioatt);

                return StatusCode(200);

            }
            catch (Exception codErro)
            {

                return BadRequest(codErro);

            }
        }

        //HOMOLOGAR
        [HttpDelete]
        public IActionResult Deletar(int id)
        {

            _estudioRepository.DeletarId(id);

            return StatusCode(204);

        }

    }
}
