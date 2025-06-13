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
    
    public async Task<IEnumerable<Question>> GetAllAsync()
    {
        return await _context.Questions.ToListAsync();
    }

    public async Task<Question> GetByIdAsync(int id)
    {
        return await _context.Questions.FindAsync(id);
    }

    public async Task AddAsync(Question question)
    {
        await _context.Questions.AddAsync(question);
    }

    public void Update(Question question)
    {
        _context.Questions.Update(question);
    }

    public void Delete(Question question)
    {
        _context.Questions.Remove(question);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return (await _context.SaveChangesAsync()) > 0;
    }
}