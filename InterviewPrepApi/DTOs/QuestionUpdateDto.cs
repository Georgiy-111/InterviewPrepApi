namespace InterviewPrepApi.DTOs;

/// <summary>
/// DTO для обновления вопроса.
/// </summary>
public class QuestionUpdateDto
{
    /// <summary>
    /// Новый текст вопроса.
    /// </summary>
    public string Text { get; set; }

    /// <summary>
    /// Новый ответ на вопрос.
    /// </summary>
    public string Answer { get; set; }

    /// <summary>
    /// Новая категория.
    /// </summary>
    public string Category { get; set; }

    /// <summary>
    /// Новый уровень сложности (от 1 до 5).
    /// </summary>
    public int Difficulty { get; set; }
}