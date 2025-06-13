
using InterviewPrepApi.DTOs;
using InterviewPrepApi.Models;
using InterviewPrepApi.Repositories;

namespace InterviewPrepApi.Services;

public class QuestionService : IQuestionService
{
    private readonly IQuestionRepository _repository;

    public QuestionService(IQuestionRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<QuestionReadDto>> GetAllAsync()
    {
        var questions = await _repository.GetAllAsync();

        return questions.Select(q => new QuestionReadDto
        {
            Id = q.Id,
            Text = q.Text,
            Category = q.Category,
            Answer = q.Answer,
            Difficulty = q.Difficulty,
        });
    }

    public async Task<QuestionReadDto> CreateAsync(QuestionCreateDto dto)
    {
        var question = new Question
        {
            Text = dto.Text,
            Answer = dto.Answer,
            Category = dto.Category,
            Difficulty = dto.Difficulty,
            CreatedAt = DateTime.UtcNow
        };

        await _repository.AddAsync(question);
        await _repository.SaveChangesAsync();

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
        var question = await _repository.GetByIdAsync(id);
        if (question == null)
            return null;

        question.Text = dto.Text;
        question.Answer = dto.Answer;
        question.Category = dto.Category;
        question.Difficulty = dto.Difficulty;

        _repository.Update(question);
        await _repository.SaveChangesAsync();

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
        var question = await _repository.GetByIdAsync(id);
        if (question == null)
            return false;

        _repository.Delete(question);
        await _repository.SaveChangesAsync();

        return true;
    }
}