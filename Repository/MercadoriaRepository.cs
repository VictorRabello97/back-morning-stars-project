using Microsoft.EntityFrameworkCore;
using MorningStartApi.Data;
using MorningStartApi.Models;
using MorningStartApi.Repository.Interfaces;

namespace MorningStartApi.Repository
{
    public class MercadoriaRepository : IMercadoriaRepository
    {

        private readonly SistemaMercadoriasDBContex _dbContext;
        public MercadoriaRepository(SistemaMercadoriasDBContex sistemasMercadoriasDBContex)
        {
            _dbContext = sistemasMercadoriasDBContex;
        }

        public async Task<MercadoriaModel> BuscarPorId(int id)
        {
            return await _dbContext.Mercadoria.FirstAsync(x => x.Id == id);
        }

        public async Task<List<MercadoriaModel>> BuscarTodasMercadorias()
        {
            return await _dbContext.Mercadoria.ToListAsync();
        }

        public async Task<MercadoriaModel> Adicionar(MercadoriaModel mercadoria)
        {
           await _dbContext.Mercadoria.AddAsync(mercadoria);
           await  _dbContext.SaveChangesAsync();

            return  mercadoria;
        }

        public async Task<bool> Apagar(int id)
        {
            MercadoriaModel mercadoriaPorId = await BuscarPorId(id);

            _dbContext.Mercadoria.Remove(mercadoriaPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }

    }
}
