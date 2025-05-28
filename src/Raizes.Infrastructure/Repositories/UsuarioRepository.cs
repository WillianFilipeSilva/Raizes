using Raizes.Application.Interfaces;
using Raizes.Domain.Entities;
using Raizes.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Raizes.Infrastructure.Repositories;
public class UsuarioRepository : IUsuarioRepository
{
  private readonly RaizesDbContext _ctx;
  public UsuarioRepository(RaizesDbContext ctx)=>_ctx=ctx;

  public async Task AddAsync(Usuario entity){
    _ctx.Add(entity);
    await _ctx.SaveChangesAsync();
  }
  public Task<> GetByIdAsync(Guid id)=>_ctx.Set<Usuario>().FindAsync(id).AsTask();
  public async Task UpdateAsync(Usuario entity){
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
