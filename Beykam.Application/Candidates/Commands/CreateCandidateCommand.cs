using MediatR;

namespace Beykam.Application.Candidates.Commands;

public record CreateCandidateCommand() : IRequest<Guid>;


