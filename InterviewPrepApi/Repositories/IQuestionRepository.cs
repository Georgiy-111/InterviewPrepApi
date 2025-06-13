using InterviewPrepApi.Models;

namespace InterviewPrepApi.Repositories;

public interface IQuestionRepository
{
    Task<IEnumerable<Question>> GetAllAsync();
    Task<Question> GetByIdAsync(int id);
    Task AddAsync(Question question);
    void Update(Question question);
    void Delete(Question question);
    Task<bool> SaveChangesAsync();
}