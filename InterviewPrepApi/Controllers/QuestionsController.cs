using InterviewPrepApi.DTOs;
using InterviewPrepApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace InterviewPrepApi.Controllers;

/// <summary>
/// Контроллер для управления вопросами к собеседованию.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class QuestionsController : ControllerBase
{
    private readonly IQuestionService _questionService;

    public QuestionsController(IQuestionService questionService)
    {
        _questionService = questionService;
    }

    /// <summary>
    /// Получить все вопросы.
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<QuestionReadDto>>> GetAll(CancellationToken cancellationToken)
    {
        var questions = await _questionService.GetAllAsync(cancellationToken);
        return Ok(questions); 
    }
    /// <summary>
    /// Получить вопрос по ID.
    /// </summary>
    [HttpGet("{id}")]
    public async Task<ActionResult<QuestionReadDto>> GetById(int id, CancellationToken cancellationToken)
    {
        var question = await _questionService.GetByIdAsync(id, cancellationToken);
        if (question == null)
            return NotFound();

        return Ok(question);
    }
    /// <summary>
    /// Получить список вопросов с поддержкой пагинации.
    /// Используется для постраничного вывода данных — например, при большом количестве вопросов.
    /// </summary>
    [HttpGet("paginated")]
    public async Task<ActionResult<IEnumerable<QuestionReadDto>>> GetPaginated(
        [FromQuery] PaginationParameters pagination,
        CancellationToken cancellationToken)
    {
        var result = await _questionService.GetPaginatedAsync(pagination, cancellationToken);
        return Ok(result);
    }
    /// <summary>
    /// Получить вопросы по фильтрам: категория и сложность.
    /// </summary>
    /// <param name="category">Категория (например: "C#", "SQL", "OOP")</param>
    /// <param name="difficulty">Уровень сложности (например: "Junior", "Middle", "Senior")</param>
    /// <param name="cancellationToken">Токен отмены</param>
    [HttpGet("filter")]
    public async Task<ActionResult<IEnumerable<QuestionReadDto>>> GetFiltered(
        [FromQuery] string? category,
        [FromQuery] string? difficulty,
        CancellationToken cancellationToken)
    {
        var filterDto = new QuestionFilterDto
        {
            Category = category,
            Difficulty = difficulty
        };

        var result = await _questionService.GetFilteredAsync(filterDto, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Создать новый вопрос.
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<QuestionReadDto>> Create(
        QuestionCreateDto dto,
        CancellationToken cancellationToken)
    {
        var created = await _questionService.CreateAsync(dto, cancellationToken);
        return CreatedAtAction(nameof(GetAll), new { id = created.Id }, created);
    }

    /// <summary>
    /// Изменить вопрос.
    /// </summary>
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(
        int id,
        QuestionUpdateDto dto,
        CancellationToken cancellationToken)
    {
        var updated = await _questionService.UpdateAsync(id, dto, cancellationToken);
        if (updated == null)
            return NotFound();

        return Ok(updated);
    }

    /// <summary>
    /// Удалить вопрос.
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        var deleted = await _questionService.DeleteAsync(id, cancellationToken);
        if (!deleted)
            return NotFound();

        return NoContent();
    }
}