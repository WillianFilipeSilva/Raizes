using MediatR;
using Raizes.Application.Interfaces;
using Raizes.Domain.Entities;

namespace Raizes.Application.Commands.Propriedades;
public class CriarPropriedadeCommandHandler : IRequestHandler<CriarPropriedadeCommand,Guid>
{
  private readonly IPropriedadeRepository _repo;
  public CriarPropriedadeCommandHandler(IPropriedadeRepository repo)=>_repo=repo;
  public async Task<Guid> Handle(CriarPropriedadeCommand cmd, CancellationToken ct){
    var prop = new Propriedade(); // preencher depois
    await _repo.AddAsync(prop);
    return prop.Id;
  }
}
