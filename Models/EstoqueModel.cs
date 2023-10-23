namespace MorningStartApi.Models
{
    public class EstoqueModel
    {
        public int Id { get; set; }
        public int Quantidade {  get; set; }

        public string? Local {  get; set; }

        public string? Operacao { get; set; }

        public DateTime DataRegistro { get; set; } = DateTime.Now; 

        public int? MercadoriaId { get; set; }

        public virtual MercadoriaModel? Mercadoria { get; set;}


    }
}



        



