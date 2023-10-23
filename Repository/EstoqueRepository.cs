using Microsoft.EntityFrameworkCore;
using MorningStartApi.Data;
using MorningStartApi.Models;
using MorningStartApi.Repository.Interfaces;

namespace MorningStartApi.Repository
{


    public class EstoqueRepository : IEstoqueRepository
    {

        private readonly SistemaMercadoriasDBContex _dbContext;
        public EstoqueRepository(SistemaMercadoriasDBContex sistemasMercadoriasDBContex)
        {
            _dbContext = sistemasMercadoriasDBContex;
        }

        public async Task<EstoqueModel> BuscarPorId(int id)
        {
            return await _dbContext.Estoque
                .Include(x=> x.Mercadoria)
                .FirstAsync(x => x.Id == id);
        }


        public async Task<List<EstoqueModel>> BuscarTodasEntradas(string operacao)
        {
            if (operacao == null) {
                return await _dbContext.Estoque
                    .Include(x => x.Mercadoria)
                    .ToListAsync();
            } else

            {
                return await _dbContext.Estoque
                     .Where(e => e.Operacao == operacao)
                     .Include(x => x.Mercadoria)
                     .ToListAsync();
            }
        }


        public async Task<List<EstoqueModel>> SomaDeEstoque(int ano, int mercadoriaId)
        {
            var result = await _dbContext.Estoque
                .Where(x => x.DataRegistro.Year == ano && x.MercadoriaId == mercadoriaId)
                .GroupBy(x => new { x.DataRegistro.Month, x.Operacao })
                .Select(g => new
                {
                    Month = g.Key.Month,
                    Operacao = g.Key.Operacao,
                    SumQuantity = g.Sum(x => x.Quantidade)
                })
                .ToListAsync();

            List<EstoqueModel> entradasPorAno = result
                .Select(item => new EstoqueModel
                {
                    DataRegistro = new DateTime(ano, item.Month, 1),
                    Quantidade = item.SumQuantity,
                    Operacao = item.Operacao
                })
                .ToList();

            return entradasPorAno;
        }


        public async Task<EstoqueModel> Adicionar (EstoqueModel estoque)
        {
           await _dbContext.Estoque.AddAsync(estoque);
           await  _dbContext.SaveChangesAsync();

            return estoque;
        }

        public async Task<bool> Apagar(int id)
        {
            EstoqueModel EstoquePorId = await BuscarPorId(id);

            _dbContext.Estoque.Remove(EstoquePorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }

    }
}
