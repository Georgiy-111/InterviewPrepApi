namespace InterviewPrepApi.DTOs;

/// <summary>
/// DTO для фильтрации вопросов.
/// </summary>
public class QuestionFilterDto
{
    /// <summary>
    /// Категория вопроса (например: C#, SQL, OOP).
    /// </summary>
    public string? Category { get; set; }

    /// <summary>
    /// Уровень сложности (например: Junior, Middle, Senior).
    /// </summary>
    public string? Difficulty { get; set; }
}