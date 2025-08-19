using Beykam.Domain.Entities;
using MediatR;

namespace Beykam.Application.JobApplications.Queries;

public record GetJobApplicationByIdQuery(Guid Id) : IRequest<JobApplication?>;


