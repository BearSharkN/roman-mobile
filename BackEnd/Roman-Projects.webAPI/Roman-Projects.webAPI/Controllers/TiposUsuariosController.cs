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

    public class TiposUsuariosController : ControllerBase
    {

        private ITiposUsuarioRepository _tipoUsuarioRepository { get; set; }


        public TiposUsuariosController()
        {
            _tipoUsuarioRepository = new TiposUsuarioRepository();
        }


        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_tipoUsuarioRepository.ListarTiposUsuarios());
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
                return Ok(_tipoUsuarioRepository.BuscarTipoUsuarioPorId(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        [HttpPost]
        public IActionResult Post(TiposUsuario novoTipoUsuario)
        {
            try
            {
                _tipoUsuarioRepository.CadastrarTipoUsuario(novoTipoUsuario);

                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }



        [HttpPut("{id}")]
        public IActionResult Put(int id, TiposUsuario tipoUsuarioAtualizado)
        {
            try
            {
                _tipoUsuarioRepository.AtualizarTipoUsuarioUrl(id, tipoUsuarioAtualizado);

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
                _tipoUsuarioRepository.DeletarTipoUsuario(id);

                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


    }

}

