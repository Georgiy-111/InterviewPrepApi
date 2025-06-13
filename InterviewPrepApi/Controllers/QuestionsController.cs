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
    private readonly QuestionService _questionService;

    public QuestionsController(QuestionService questionService)
    {
        _questionService = questionService;
    }
    /// <summary>
    /// Получить все вопросы.
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<QuestionReadDto>>> GetAll()
    {
        var questions = await _questionService.GetAllAsync();
        return Ok(questions); 
    }
    /// <summary>
    /// Создать новый вопрос.
    /// </summary>
    /// <param name="dto">Данные для создания вопроса.</param>
    [HttpPost]
    public async Task<ActionResult<QuestionReadDto>> Create(QuestionCreateDto dto)
    {
        var created = await _questionService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetAll), new { id = created.Id }, created);
    }
    /// <summary>
    /// Изменить вопрос.
    /// </summary>
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, QuestionUpdateDto dto)
    {
        var updated = await _questionService.UpdateAsync(id, dto);
        if (updated == null)
            return NotFound();

        return Ok(updated);
    }
    /// <summary>
    /// Удалить вопрос.
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _questionService.DeleteAsync(id);
        if (!deleted)
            return NotFound();

        return NoContent();
    }
}