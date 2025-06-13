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