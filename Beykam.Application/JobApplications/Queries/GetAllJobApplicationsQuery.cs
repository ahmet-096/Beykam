using Beykam.Domain.Entities;
using MediatR;

namespace Beykam.Application.JobApplications.Queries;

public record GetAllJobApplicationsQuery() : IRequest<IEnumerable<JobApplication>>;


