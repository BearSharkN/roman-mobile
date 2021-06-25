using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Roman_Projects.webAPI.Domains;
using Roman_Projects.webAPI.Interfaces;
using Roman_Projects.webAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roman_Projects.webAPI.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]

    [ApiController]

    public class TemasController : ControllerBase
    {

        private ITemaRepository _temaRepository { get; set; }


        public TemasController()
        {
            _temaRepository = new TemaRepository();
        }


        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_temaRepository.ListarTemas());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_temaRepository.BuscarTemaPorId(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        [HttpPost]
        public IActionResult Post(Tema novoTema)
        {
            try
            {
                _temaRepository.CadastrarTema(novoTema);

                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }



        [HttpPut("{id}")]
        public IActionResult Put(int id, Tema temaAtualizado)
        {
            try
            {
                _temaRepository.AtualizarTemaUrl(id, temaAtualizado);

                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _temaRepository.DeletarTema(id);

                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


    }

}

