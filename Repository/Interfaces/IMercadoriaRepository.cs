using MorningStartApi.Models;

namespace MorningStartApi.Repository.Interfaces
{
    public interface IMercadoriaRepository
    {
        Task<List<MercadoriaModel>> BuscarTodasMercadorias();

        Task<MercadoriaModel> Adicionar(MercadoriaModel mercadoria);

        Task<MercadoriaModel> BuscarPorId(int id);

        Task<bool> Apagar(int id);
    }
}

