using Raizes.Domain.Entities;
namespace Raizes.Application.Interfaces;
public interface IUsuarioRepository {
  Task AddAsync(Usuario entity);
  Task<> GetByIdAsync(Guid id);
  Task UpdateAsync(Usuario entity);
  Task DeleteAsync(Guid id);
}
