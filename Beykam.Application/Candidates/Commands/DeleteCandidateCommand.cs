using MediatR;

namespace Beykam.Application.Candidates.Commands;

public record DeleteCandidateCommand(Guid Id) : IRequest<Unit>;


