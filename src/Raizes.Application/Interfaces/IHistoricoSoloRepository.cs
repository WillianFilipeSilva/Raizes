using Raizes.Domain.Entities;
namespace Raizes.Application.Interfaces;
public interface IHistoricoSoloRepository {
  Task AddAsync(HistoricoSolo entity);
  Task<> GetByIdAsync(Guid id);
  Task UpdateAsync(HistoricoSolo entity);
  Task DeleteAsync(Guid id);
}
