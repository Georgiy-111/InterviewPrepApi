namespace InterviewPrepApi.DTOs;

/// <summary>
/// DTO для создания вопроса.
/// </summary>
public class QuestionCreateDto
{
    /// <summary>
    /// Текст вопроса.
    /// </summary>
    public string Text { get; set; }

    /// <summary>
    /// Ответ.
    /// </summary>
    public string Answer { get; set; }

    /// <summary>
    /// Категория.
    /// </summary>
    public string Category { get; set; }

    /// <summary>
    /// Уровень сложности (от 1 до 5).
    /// </summary>
    public int Difficulty { get; set; }
}