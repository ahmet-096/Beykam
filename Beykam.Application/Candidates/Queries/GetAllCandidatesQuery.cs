using Beykam.Domain.Entities;
using MediatR;

namespace Beykam.Application.Candidates.Queries;

public record GetAllCandidatesQuery() : IRequest<IEnumerable<Candidate>>;


