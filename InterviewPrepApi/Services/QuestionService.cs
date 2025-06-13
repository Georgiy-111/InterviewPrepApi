using InterviewPrepApi.Data;
using InterviewPrepApi.DTOs;
using InterviewPrepApi.Models;
using Microsoft.EntityFrameworkCore;

namespace InterviewPrepApi.Services;

public class QuestionService
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
            Difficulty = dto.Difficulty
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
}