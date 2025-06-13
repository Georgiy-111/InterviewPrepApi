using AutoMapper;
using InterviewPrepApi.DTOs;
using InterviewPrepApi.Models;

namespace InterviewPrepApi.Mapping;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Question, QuestionReadDto>();

        CreateMap<QuestionCreateDto, Question>();
        
        CreateMap<QuestionUpdateDto, Question>();
    }
}