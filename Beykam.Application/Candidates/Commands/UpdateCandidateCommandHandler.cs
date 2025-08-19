using Beykam.Domain.Entities;
using Beykam.Persistence.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Beykam.Application.Candidates.Commands
{
    public class UpdateCandidateCommandHandler : IRequestHandler<UpdateCandidateCommand, Unit>
    {
        private readonly BeykamDbContext _dbContext;

        public UpdateCandidateCommandHandler(BeykamDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(UpdateCandidateCommand request, CancellationToken cancellationToken)
        {
            var candidate = await _dbContext.Candidates
                .Include(c => c.Skills)
                .Include(c => c.Languages)
                .Include(c => c.Experiences)
                .Include(c => c.Educations)
                .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            if (candidate is null)
            {
                return Unit.Value;
            }

            var dto = request.Candidate;

            if (dto.FirstName is not null) candidate.FirstName = dto.FirstName;
            if (dto.LastName is not null) candidate.LastName = dto.LastName;
            if (dto.Email is not null) candidate.Email = dto.Email;
            if (dto.PhoneNumber is not null) candidate.PhoneNumber = dto.PhoneNumber;
            if (dto.CvUrl is not null) candidate.CvUrl = dto.CvUrl;

            if (dto.Skills is not null)
            {
                candidate.Skills.Clear();
                foreach (var s in dto.Skills)
                {
                    candidate.Skills.Add(new CandidateSkill
                    {
                        SkillName = s.SkillName,
                        Level = s.Level ?? 0
                    });
                }
            }

            if (dto.Languages is not null)
            {
                candidate.Languages.Clear();
                foreach (var l in dto.Languages)
                {
                    candidate.Languages.Add(new CandidateLanguage
                    {
                        LanguageName = l.LanguageName,
                        Proficiency = l.Proficiency
                    });
                }
            }

            if (dto.Experiences is not null)
            {
                candidate.Experiences.Clear();
                foreach (var e in dto.Experiences)
                {
                    candidate.Experiences.Add(new CandidateExperience
                    {
                        CompanyName = e.CompanyName,
                        Position = e.Position,
                        Description = e.Description,
                        StartDate = e.StartDate,
                        EndDate = e.EndDate
                    });
                }
            }

            if (dto.Educations is not null)
            {
                candidate.Educations.Clear();
                foreach (var ed in dto.Educations)
                {
                    candidate.Educations.Add(new CandidateEducation
                    {
                        SchoolName = ed.SchoolName,
                        Degree = ed.Degree,
                        Department = ed.Department ?? string.Empty,
                        StartDate = ed.StartDate,
                        EndDate = ed.EndDate
                    });
                }
            }

            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}


