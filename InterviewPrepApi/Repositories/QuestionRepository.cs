using InterviewPrepApi.Data;
using InterviewPrepApi.Models;
using Microsoft.EntityFrameworkCore;

namespace InterviewPrepApi.Repositories;

public class QuestionRepository : IQuestionRepository
{
    private readonly AppDbContext _context;

    public QuestionRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Question>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _context.Questions.ToListAsync(cancellationToken);
    }

    public async Task<Question?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await _context.Questions.FirstOrDefaultAsync(q => q.Id == id, cancellationToken);
    }

    public async Task AddAsync(Question question, CancellationToken cancellationToken)
    {
        await _context.Questions.AddAsync(question, cancellationToken);
    }

    public void Update(Question question)
    {
        _context.Questions.Update(question);
    }

    public void Delete(Question question)
    {
        _context.Questions.Remove(question);
    }

    public async Task<bool> SaveChangesAsync(CancellationToken cancellationToken)
    {
        return (await _context.SaveChangesAsync(cancellationToken)) > 0;
    }
    public async Task<IEnumerable<Question>> GetPaginatedAsync(int pageNumber, int pageSize, CancellationToken cancellationToken)
    {
        return await _context.Questions
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);
    }
}
