using Raizes.Domain.Entities;
namespace Raizes.Application.Interfaces;
public interface IFornecedorRepository {
  Task AddAsync(Fornecedor entity);
  Task<> GetByIdAsync(Guid id);
  Task UpdateAsync(Fornecedor entity);
  Task DeleteAsync(Guid id);
}
