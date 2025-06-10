using Raizes.Contracts.Repository;
using Raizes.Entity;
using Raizes.Infraestructure;

namespace Raizes.Repository
{
    public class VendaRepository : IVendaRepository
    {
        private readonly Connection _connection = new();

        public async Task<VendaEntity?> GetById(int id)
        {
            var sql = @"
                SELECT Id, ColheitaId, PlantaId, UnidadeMedidaId,
                       Quantidade, PrecoTotal, PrecoUnitario, DataVenda
                FROM raizes.venda
                WHERE Id = @id;
            ";
            return await _connection.ExecuteQueryFirstAsync<VendaEntity>(sql, new { id });
        }

        public async Task<IEnumerable<VendaEntity>> GetAll()
        {
            var sql = @"
                SELECT Id, ColheitaId, PlantaId, UnidadeMedidaId,
                       Quantidade, PrecoTotal, PrecoUnitario, DataVenda
                FROM raizes.venda;
            ";
            return await _connection.ExecuteQueryAsync<VendaEntity>(sql);
        }

        public async Task Insert(VendaEntity entity)
        {
            var sql = @"
                INSERT INTO raizes.venda
                  (ColheitaId, PlantaId, UnidadeMedidaId, Quantidade, PrecoUnitario, DataVenda)
                VALUES
                  (@ColheitaId, @PlantaId, @UnidadeMedidaId, @Quantidade, @PrecoUnitario, @DataVenda);
            ";
            await _connection.ExecuteAsync(sql, entity);
        }

        public async Task Update(VendaEntity entity)
        {
            var sql = @"
                UPDATE raizes.venda
                SET ColheitaId=@ColheitaId, PlantaId=@PlantaId,
                    UnidadeMedidaId=@UnidadeMedidaId, Quantidade=@Quantidade,
                    PrecoUnitario=@PrecoUnitario,
                    DataVenda=@DataVenda
                WHERE Id = @Id;
            ";
            await _connection.ExecuteAsync(sql, entity);
        }

        public async Task Delete(int id)
        {
            var sql = @"DELETE FROM raizes.venda WHERE Id = @id;";
            await _connection.ExecuteAsync(sql, new { id });
        }
    }
}
