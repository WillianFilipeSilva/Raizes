using MediatR;
namespace Raizes.Application.Commands.Propriedades;
public record CriarPropriedadeCommand(string Nome) : IRequest<Guid>;
