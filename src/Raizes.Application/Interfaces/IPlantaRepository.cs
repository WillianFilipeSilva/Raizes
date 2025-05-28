using Raizes.Domain.Entities;
namespace Raizes.Application.Interfaces;
public interface IPlantaRepository {
  Task AddAsync(Planta entity);
  Task<> GetByIdAsync(Guid id);
  Task UpdateAsync(Planta entity);
  Task DeleteAsync(Guid id);
}
