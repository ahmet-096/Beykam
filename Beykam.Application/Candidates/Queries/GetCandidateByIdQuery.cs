using Beykam.Domain.Entities;
using MediatR;

namespace Beykam.Application.Candidates.Queries;

public record GetCandidateByIdQuery(Guid Id) : IRequest<Candidate?>;


