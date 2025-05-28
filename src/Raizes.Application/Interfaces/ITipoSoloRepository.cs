using Raizes.Domain.Entities;
namespace Raizes.Application.Interfaces;
public interface ITipoSoloRepository {
  Task AddAsync(TipoSolo entity);
  Task<> GetByIdAsync(Guid id);
  Task UpdateAsync(TipoSolo entity);
  Task DeleteAsync(Guid id);
}
