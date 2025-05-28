using Raizes.Domain.Entities;
namespace Raizes.Application.Interfaces;
public interface IInsumoRepository {
  Task AddAsync(Insumo entity);
  Task<> GetByIdAsync(Guid id);
  Task UpdateAsync(Insumo entity);
  Task DeleteAsync(Guid id);
}
