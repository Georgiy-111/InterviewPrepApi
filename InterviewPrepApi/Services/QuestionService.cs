using InterviewPrepApi.DTOs;
using InterviewPrepApi.Models;
using InterviewPrepApi.Repositories;
using AutoMapper;

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

    public async Task<IEnumerable<QuestionReadDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        var questions = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<QuestionReadDto>>(questions);
    }

    public async Task<QuestionReadDto> CreateAsync(QuestionCreateDto dto, CancellationToken cancellationToken)
    {
        var question = _mapper.Map<Question>(dto);
        question.CreatedAt = DateTime.UtcNow;

        await _repository.AddAsync(question, cancellationToken);
        await _repository.SaveChangesAsync(cancellationToken);

        return _mapper.Map<QuestionReadDto>(question);
    }

    public async Task<QuestionReadDto?> UpdateAsync(int id, QuestionUpdateDto dto, CancellationToken cancellationToken)
    {
        var question = await _repository.GetByIdAsync(id, cancellationToken);
        if (question == null)
            return null;

        _mapper.Map(dto, question);
        _repository.Update(question);
        await _repository.SaveChangesAsync(cancellationToken);

        return _mapper.Map<QuestionReadDto>(question);
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken)
    {
        var question = await _repository.GetByIdAsync(id, cancellationToken);
        if (question == null)
            return false;

        _repository.Delete(question);
        await _repository.SaveChangesAsync(cancellationToken);

        return true;
    }
    public async Task<QuestionReadDto> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        var question = await _repository.GetByIdAsync(id, cancellationToken);
        if (question == null)
            return null;

        return _mapper.Map<QuestionReadDto>(question);
    }
}