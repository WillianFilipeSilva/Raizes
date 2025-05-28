using Raizes.Domain.Entities;
namespace Raizes.Application.Interfaces;
public interface IInsumoEstoqueRepository {
  Task AddAsync(InsumoEstoque entity);
  Task<> GetByIdAsync(Guid id);
  Task UpdateAsync(InsumoEstoque entity);
  Task DeleteAsync(Guid id);
}
