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

    public class EquipesController : ControllerBase
    {

        private IEquipeRepository _equipeRepository { get; set; }


        public EquipesController()
        {
            _equipeRepository = new EquipeRepository();
        }


        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_equipeRepository.ListarEquipes());
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
                return Ok(_equipeRepository.BuscarEquipePorId(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        [HttpPost]
        public IActionResult Post(Equipe novaEquipe)
        {
            try
            {
                _equipeRepository.CadastrarEquipe(novaEquipe);

                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }



        [HttpPut("{id}")]
        public IActionResult Put(int id, Equipe equipeAtualizada)
        {
            try
            {
                _equipeRepository.AtualizarEquipeUrl(id, equipeAtualizada);

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
                _equipeRepository.DeletarEquipe(id);

                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


    }

}

