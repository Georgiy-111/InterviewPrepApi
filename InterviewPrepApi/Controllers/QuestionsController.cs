using InterviewPrepApi.DTOs;
using InterviewPrepApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace InterviewPrepApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class QuestionsController : ControllerBase
{
    private readonly QuestionService _questionService;

    public QuestionsController(QuestionService questionService)
    {
        _questionService = questionService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<QuestionReadDto>>> GetAll()
    {
        var questions = await _questionService.GetAllAsync();
        return Ok(questions); 
    }

    [HttpPost]
    public async Task<ActionResult<QuestionReadDto>> Create(QuestionCreateDto dto)
    {
        var created = await _questionService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetAll), new { id = created.Id }, created);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, QuestionUpdateDto dto)
    {
        var updated = await _questionService.UpdateAsync(id, dto);
        if (updated == null)
            return NotFound();

        return Ok(updated);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _questionService.DeleteAsync(id);
        if (!deleted)
            return NotFound();

        return NoContent();
    }
}