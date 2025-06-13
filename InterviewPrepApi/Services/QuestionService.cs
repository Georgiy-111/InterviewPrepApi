using InterviewPrepApi.Data;
using InterviewPrepApi.DTOs;
using InterviewPrepApi.Models;
using Microsoft.EntityFrameworkCore;

namespace InterviewPrepApi.Services;

public class QuestionService : IQuestionService
{
    private readonly AppDbContext _context;

    public QuestionService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<QuestionReadDto>> GetAllAsync()
    {
        return await _context.Questions
            .Select(q => new QuestionReadDto
            {
                Id = q.Id,
                Text = q.Text,
                Category = q.Category,
                Answer = q.Answer,
                Difficulty = q.Difficulty,
            })
            .ToListAsync();
    }

    public async Task<QuestionReadDto> CreateAsync(QuestionCreateDto dto)
    {
        var question = new Question
        {
            Text = dto.Text,
            Answer = dto.Answer,
            Category = dto.Category,
            Difficulty = dto.Difficulty,
            CreatedAt = DateTime.UtcNow // ← вот эта строка
        };

        _context.Questions.Add(question);
        await _context.SaveChangesAsync();

        return new QuestionReadDto
        {
            Id = question.Id,
            Text = question.Text,
            Answer = question.Answer,
            Category = question.Category,
            Difficulty = question.Difficulty
        };
    }
    public async Task<QuestionReadDto> UpdateAsync(int id, QuestionUpdateDto dto)
    {
        var question = await _context.Questions.FindAsync(id);
        if (question == null)
            return null;

        question.Text = dto.Text;
        question.Answer = dto.Answer;
        question.Category = dto.Category;
        question.Difficulty = dto.Difficulty;

        await _context.SaveChangesAsync();

        return new QuestionReadDto
        {
            Id = question.Id,
            Text = question.Text,
            Answer = question.Answer,
            Category = question.Category,
            Difficulty = question.Difficulty
        };
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var question = await _context.Questions.FindAsync(id);
        if (question == null)
            return false;

        _context.Questions.Remove(question);
        await _context.SaveChangesAsync();

        return true;
    }
}