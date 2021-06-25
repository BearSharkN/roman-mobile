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

    
    public class ProjetosController : ControllerBase
    {
        //para mensagens de erro de nomenclatura quando executar:
        //ir em ferramentas -> opções -> editor de texto -> C# -> estilo do código -> nomenclatura para desabilitar

        // objeto que irá receber os métodos definidos na interface
        private IProjetoRepository  _projetoRepository { get; set; }


        // método construtor -> método especial de mesmo nome da classe aonde ele é invocado automaticamente
        // toda a vez em que uma instância de um objeto (ProjetosController) for criada
       
        // portanto toda a vez em que uma instância do objeto ProjetosController() for criada:
        // 1- o método construtor será automaticamente invocado e será executado o que está dentro dele
        // 2- será instanciado um objeto _projetoRepository do tipo ProjetoRepository contendo os métodos do repositório
        public ProjetosController()
        {
            _projetoRepository = new ProjetoRepository();
        }


        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_projetoRepository.ListarProjetos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex); //Bad Request -> status code 400 / NotFound -> status code 404  
            }
        }

        
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_projetoRepository.BuscarProjetoPorId(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);   
            }
        }


        [HttpPost]
        public IActionResult Post(Projeto novoProjeto)
        {
            try
            {
                _projetoRepository.CadastrarProjeto(novoProjeto);

                return StatusCode(201); //created
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        

        [HttpPut("{id}")]
        public IActionResult Put(int id, Projeto projetoAtualizado)
        {
            try
            {
                _projetoRepository.AtualizarProjetoUrl(id,projetoAtualizado);

                return StatusCode(204); //no content
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
                _projetoRepository.DeletarProjeto(id);

                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


    }

}
