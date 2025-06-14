using InterviewPrepApi.DTOs;

namespace InterviewPrepApi.Services;

public interface IQuestionService
{
        Task<IEnumerable<QuestionReadDto>> GetAllAsync(CancellationToken cancellationToken);
        Task<QuestionReadDto> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task<QuestionReadDto> CreateAsync(QuestionCreateDto dto, CancellationToken cancellationToken);
        Task<QuestionReadDto> UpdateAsync(int id, QuestionUpdateDto dto, CancellationToken cancellationToken);
        Task<bool> DeleteAsync(int id, CancellationToken cancellationToken);
        Task<IEnumerable<QuestionReadDto>> GetPaginatedAsync(PaginationParameters pagination, CancellationToken cancellationToken);
        Task<IEnumerable<QuestionReadDto>> GetFilteredAsync(QuestionFilterDto filter, CancellationToken cancellationToken);
}