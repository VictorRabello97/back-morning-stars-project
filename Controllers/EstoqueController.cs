using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MorningStartApi.Models;
using MorningStartApi.Repository;
using MorningStartApi.Repository.Interfaces;
using System.Net;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MorningStartApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstoqueController : ControllerBase
    {

        private readonly IEstoqueRepository _estoqueRepository;
        public EstoqueController(IEstoqueRepository entradaRepository)
        {
            _estoqueRepository = entradaRepository;
        }

      
        [HttpGet]
        public async Task<ActionResult<List<EstoqueModel>>> BuscarTodasEntradas(string operacao)
        {
            List<EstoqueModel> entrada = await _estoqueRepository.BuscarTodasEntradas(operacao);
            return Ok(entrada);
        }


        //localhost:7060/api/Entrada/date?ano=2023
        [HttpGet("informacoesEstoque")]
        public async Task<ActionResult<List<EstoqueModel>>> SomaDeEstoque(int ano, int mercadoriaId)
        {
            List<EstoqueModel> operacaoEstoque = await _estoqueRepository.SomaDeEstoque(ano, mercadoriaId);
            return Ok(operacaoEstoque);
        }

 

        [HttpGet("{id}")]
        public async Task<ActionResult<MercadoriaModel>> BuscarPorId(int id)
        {
            EstoqueModel entrada = await _estoqueRepository.BuscarPorId(id);
            return Ok(entrada);
        }
        

        [HttpPost]

        public async Task<ActionResult<EstoqueModel>> Adicionar ([FromBody] EstoqueModel estoqueModel)
        {
            EstoqueModel estoque = await _estoqueRepository.Adicionar(estoqueModel);

            return Ok(estoque);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<EstoqueModel>> Apagar(int id)
        {
            try
            {
                bool apagar = await _estoqueRepository.Apagar(id);
                return Ok(apagar);
            }
            catch
            {
                return StatusCode(400);
            }
        }
    }

}
