using AutoMapper;
using Beykam.Application.Candidates.DTOs;
using Beykam.Domain.Entities;

namespace Beykam.Application.Common.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Candidate mappings
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

            // Employer mappings handled explicitly in command handler for partial updates
        }
    }
}
