using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MorningStartApi.Models;
using MorningStartApi.Repository.Interfaces;
using System.Net;

namespace MorningStartApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MercadoriaController : ControllerBase
    {

        private readonly IMercadoriaRepository _mercacadoriaRepository;
        public MercadoriaController(IMercadoriaRepository mercadoriaRepository)
        {
            _mercacadoriaRepository = mercadoriaRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<MercadoriaModel>>> BuscarTodasMercadorias()
        {
            List<MercadoriaModel> mercadorias = await _mercacadoriaRepository.BuscarTodasMercadorias();
                return Ok(mercadorias);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MercadoriaModel>> BuscarPorId(int id)
        {
            MercadoriaModel mercadoria = await _mercacadoriaRepository.BuscarPorId(id);
            return Ok(mercadoria);
        }
        


        [HttpPost]
        public async Task<ActionResult<MercadoriaModel>> Cadastrar([FromBody] MercadoriaModel mercadoriaModel)
        {   
            MercadoriaModel mercadoria = await _mercacadoriaRepository.Adicionar(mercadoriaModel);
            return Ok(mercadoria);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<MercadoriaModel>> Apagar(int id)
        {
            try { 
            bool apagar = await _mercacadoriaRepository.Apagar(id);
            return Ok(apagar);
            
            }
            catch
            {
                return BadRequest(new { mensagem = "Não é possivel excluir uma mercadoria que possui estoque" });
            }
        }
    }

}



