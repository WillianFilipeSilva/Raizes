using Raizes.Domain.Entities;
namespace Raizes.Application.Interfaces;
public interface IPropriedadeRepository {
  Task AddAsync(Propriedade entity);
  Task<> GetByIdAsync(Guid id);
  Task UpdateAsync(Propriedade entity);
  Task DeleteAsync(Guid id);
}
