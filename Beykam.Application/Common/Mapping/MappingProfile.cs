using AutoMapper;
using Beykam.Application.Candidates.DTOs;
using Beykam.Application.Employers.DTOs;
using Beykam.Application.JobApplications.DTOs;
using Beykam.Application.JobPosts.DTOs;
using Beykam.Domain.Entities;

namespace Beykam.Application.Common.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Candidate
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

            // Employer
            CreateMap<UpdateEmployerDto, Employer>();
            CreateMap<Employer, UpdateEmployerDto>();

            // JobPost
            CreateMap<JobPost, JobPostDTO>()
                .ForMember(dest => dest.EmployerName,
                    opt => opt.MapFrom(src => src.Employer != null ? src.Employer.CompanyName : string.Empty));

            // DTO -> Entity (nested property manuel olarak ayarlanmalı)
            CreateMap<JobPostDTO, JobPost>()
                .ForMember(dest => dest.Employer, opt => opt.Ignore());

            // JobApplication
            CreateMap<JobApplication, JobApplicationDTO>()
                .ForMember(dest => dest.JobPostTitle,
                    opt => opt.MapFrom(src => src.JobPost != null ? src.JobPost.Title : string.Empty))
                .ForMember(dest => dest.CandidateName,
                    opt => opt.MapFrom(src => src.Candidate != null 
                        ? $"{src.Candidate.FirstName} {src.Candidate.LastName}" 
                        : string.Empty));

            CreateMap<JobApplicationDTO, JobApplication>()
                .ForMember(dest => dest.JobPost, opt => opt.Ignore())
                .ForMember(dest => dest.Candidate, opt => opt.Ignore());
        }
    }
}
