namespace InterviewPrepApi.DTOs;

/// <summary>
/// DTO для отображения информации о вопросе.
/// </summary>
public class QuestionReadDto
{
    /// <summary>
    /// Уникальный идентификатор вопроса.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Текст вопроса.
    /// </summary>
    public string Text { get; set; }

    /// <summary>
    /// Ответ на вопрос.
    /// </summary>
    public string Answer { get; set; }

    /// <summary>
    /// Категория, к которой относится вопрос.
    /// </summary>
    public string Category { get; set; }

    /// <summary>
    /// Уровень сложности вопроса.
    /// </summary>
    public string Difficulty { get; set; }
}