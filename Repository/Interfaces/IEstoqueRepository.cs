using MorningStartApi.Models;

namespace MorningStartApi.Repository.Interfaces
{
    public interface IEstoqueRepository
    {
        Task<List<EstoqueModel>> BuscarTodasEntradas(string operacao);

        Task<EstoqueModel> BuscarPorId(int id);
        Task<EstoqueModel> Adicionar(EstoqueModel estoque);

        Task<List<EstoqueModel>> SomaDeEstoque(int ano, int mercadoriaId);


        Task<bool> Apagar(int id);
    }
}
