using Raizes.Domain.Entities;
namespace Raizes.Application.Interfaces;
public interface IVendaRepository {
  Task AddAsync(Venda entity);
  Task<> GetByIdAsync(Guid id);
  Task UpdateAsync(Venda entity);
  Task DeleteAsync(Guid id);
}
