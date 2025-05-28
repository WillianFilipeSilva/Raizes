using Raizes.Domain.Entities;
namespace Raizes.Application.Interfaces;
public interface IPlantioRepository {
  Task AddAsync(Plantio entity);
  Task<> GetByIdAsync(Guid id);
  Task UpdateAsync(Plantio entity);
  Task DeleteAsync(Guid id);
}
