using AutoMapper;
using Beykam.Application.Candidates.DTOs;
using Beykam.Application.Employers.DTOs;
using Beykam.Application.JobPosts.DTOs;
using Beykam.Domain.Entities;

namespace Beykam.Application.Common.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UpdateCandidateDto, Candidate>();
            CreateMap<CandidateSkillDto, CandidateSkill>();
            CreateMap<CandidateLanguageDto, CandidateLanguage>();
            CreateMap<CandidateExperienceDto, CandidateExperience>();
            CreateMap<CandidateEducationDto, CandidateEducation>();

            CreateMap<Candidate, CandidateResponseDto>();
            CreateMap<CandidateSkill, CandidateSkillDto>();
            CreateMap<CandidateLanguage, CandidateLanguageDto>();
            CreateMap<CandidateExperience, CandidateExperienceDto>();
            CreateMap<CandidateEducation, CandidateEducationDto>();

            CreateMap<UpdateEmployerDto, Employer>();
            CreateMap<Employer, UpdateEmployerDto>();

            CreateMap<JobPost, JobPostDTO>()
                .ForMember(dest => dest.EmployerName, opt => opt.MapFrom(src => src.Employer.CompanyName));
            CreateMap<JobPostDTO, JobPost>()
                .ForMember(dest => dest.Employer.CompanyName, opt => opt.MapFrom(src => src.EmployerName));
        }
    }
}
