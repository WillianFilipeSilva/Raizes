using Raizes.Application.Interfaces;
using Raizes.Domain.Entities;
using Raizes.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Raizes.Infrastructure.Repositories;
public class InsumoGastoRepository : IInsumoGastoRepository
{
  private readonly RaizesDbContext _ctx;
  public InsumoGastoRepository(RaizesDbContext ctx)=>_ctx=ctx;

  public async Task AddAsync(InsumoGasto entity){
    _ctx.Add(entity);
    await _ctx.SaveChangesAsync();
  }
  public Task<> GetByIdAsync(Guid id)=>_ctx.Set<InsumoGasto>().FindAsync(id).AsTask();
  public async Task UpdateAsync(InsumoGasto entity){
    _ctx.Update(entity);
    await _ctx.SaveChangesAsync();
  }
  public async Task DeleteAsync(Guid id){
    var ent = await GetByIdAsync(id);
    if(ent is null) return;
    _ctx.Remove(ent);
    await _ctx.SaveChangesAsync();
  }
}
