using Raizes.Application.Interfaces;
using Raizes.Domain.Entities;
using Raizes.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Raizes.Infrastructure.Repositories;
public class InsumoRepository : IInsumoRepository
{
  private readonly RaizesDbContext _ctx;
  public InsumoRepository(RaizesDbContext ctx)=>_ctx=ctx;

  public async Task AddAsync(Insumo entity){
    _ctx.Add(entity);
    await _ctx.SaveChangesAsync();
  }
  public Task<> GetByIdAsync(Guid id)=>_ctx.Set<Insumo>().FindAsync(id).AsTask();
  public async Task UpdateAsync(Insumo entity){
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
