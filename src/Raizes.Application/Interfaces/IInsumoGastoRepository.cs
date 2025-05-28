using Raizes.Domain.Entities;
namespace Raizes.Application.Interfaces;
public interface IInsumoGastoRepository {
  Task AddAsync(InsumoGasto entity);
  Task<> GetByIdAsync(Guid id);
  Task UpdateAsync(InsumoGasto entity);
  Task DeleteAsync(Guid id);
}
