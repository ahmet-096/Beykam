using MediatR;

namespace Beykam.Application.Candidates.Commands;

public record UpdateCandidateCommand(Guid Id) : IRequest<Unit>;


