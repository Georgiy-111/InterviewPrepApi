using InterviewPrepApi.Models;

namespace InterviewPrepApi.Repositories;

public interface IQuestionRepository
{
    Task<IEnumerable<Question>> GetAllAsync(CancellationToken cancellationToken);
    Task<Question> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task AddAsync(Question question, CancellationToken cancellationToken);
    void Update(Question question);
    void Delete(Question question);
    Task<bool> SaveChangesAsync(CancellationToken cancellationToken);
    
    Task<IEnumerable<Question>> GetPaginatedAsync(int pageNumber, int pageSize, CancellationToken cancellationToken);
}