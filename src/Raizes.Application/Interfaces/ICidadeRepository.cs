using Raizes.Domain.Entities;
namespace Raizes.Application.Interfaces;
public interface ICidadeRepository {
  Task AddAsync(Cidade entity);
  Task<> GetByIdAsync(Guid id);
  Task UpdateAsync(Cidade entity);
  Task DeleteAsync(Guid id);
}
