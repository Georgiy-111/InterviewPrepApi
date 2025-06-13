using AutoMapper;
using InterviewPrepApi.DTOs;
using InterviewPrepApi.Models;
using InterviewPrepApi.Repositories;

namespace InterviewPrepApi.Services;

public class QuestionService : IQuestionService
{
    private readonly IMapper _mapper;
    private readonly IQuestionRepository _repository;

    public QuestionService(IQuestionRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<QuestionReadDto>> GetAllAsync()
    {
        var questions = await _repository.GetAllAsync();
        return _mapper.Map<IEnumerable<QuestionReadDto>>(questions);
    }

    public async Task<QuestionReadDto> CreateAsync(QuestionCreateDto dto)
    {
        var question = _mapper.Map<Question>(dto);
        question.CreatedAt = DateTime.UtcNow;

        await _repository.AddAsync(question);
        await _repository.SaveChangesAsync();

        return _mapper.Map<QuestionReadDto>(question);
    }
    public async Task<QuestionReadDto> UpdateAsync(int id, QuestionUpdateDto dto)
    {
        var question = await _repository.GetByIdAsync(id);
        if (question == null)
            return null;

        _mapper.Map(dto, question);

        _repository.Update(question);
        await _repository.SaveChangesAsync();

        return _mapper.Map<QuestionReadDto>(question);
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