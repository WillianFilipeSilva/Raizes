using Raizes.Domain.Entities;
namespace Raizes.Application.Interfaces;
public interface IColheitaRepository {
  Task AddAsync(Colheita entity);
  Task<> GetByIdAsync(Guid id);
  Task UpdateAsync(Colheita entity);
  Task DeleteAsync(Guid id);
}
