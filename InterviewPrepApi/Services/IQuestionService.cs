using InterviewPrepApi.DTOs;

namespace InterviewPrepApi.Services;

public interface IQuestionService
{
    public interface IQuestionService
    {
        Task<IEnumerable<QuestionReadDto>> GetAllAsync();
        Task<QuestionReadDto> GetByIdAsync(int id);
        Task<QuestionReadDto> CreateAsync(QuestionCreateDto dto);
        Task<QuestionReadDto> UpdateAsync(int id, QuestionUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}