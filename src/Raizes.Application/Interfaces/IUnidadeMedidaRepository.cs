using Raizes.Domain.Entities;
namespace Raizes.Application.Interfaces;
public interface IUnidadeMedidaRepository {
  Task AddAsync(UnidadeMedida entity);
  Task<> GetByIdAsync(Guid id);
  Task UpdateAsync(UnidadeMedida entity);
  Task DeleteAsync(Guid id);
}
