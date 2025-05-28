using Microsoft.EntityFrameworkCore;
using Raizes.Domain.Entities;

namespace Raizes.Infrastructure.Persistence;
public class RaizesDbContext : DbContext {
  public RaizesDbContext(DbContextOptions<RaizesDbContext> opt) : base(opt){}
@(
Usuario Cidade Propriedade TipoSolo HistoricoSolo Planta Plantio Colheita Fornecedor Insumo InsumoEstoque InsumoGasto UnidadeMedida Venda | ForEach-Object { "  public DbSet<> s => Set<>();" }
) -join "
"
  protected override void OnModelCreating(ModelBuilder mb){
    base.OnModelCreating(mb);
    // TODO: configurations especÃ­ficas
  }
}
