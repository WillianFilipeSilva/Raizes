namespace Raizes.Entity
{
    public class VendaEntity
    {
        public int Id { get; set; }

        public int ColheitaId { get; set; }

        public int PlantaId { get; set; }

        public int UnidadeMedidaId { get; set; }
        
        public int Quantidade { get; set; }

        public Decimal PrecoTotal { get; set; }

        public Decimal PrecoUnitario { get; set; }

        public DateTime DataVenda { get; set; }

        public VendaEntity() { }

        public VendaEntity(int id, int colheitaId, int plantaId, int unidadeMedidaId, int quantidade, decimal precoTotal, decimal precoUnitario, DateTime dataVenda)
        {
            Id = id;
            ColheitaId = colheitaId;
            PlantaId = plantaId;
            UnidadeMedidaId = unidadeMedidaId;
            Quantidade = quantidade;
            PrecoTotal = precoTotal;
            PrecoUnitario = precoUnitario;
            DataVenda = dataVenda;
        }
    }
}
