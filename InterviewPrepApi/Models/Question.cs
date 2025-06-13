namespace InterviewPrepApi.Models;

public class Question
{
    public int Id { get; set; }                    // Уникальный идентификатор
    public string Text { get; set; } = null!;      // Текст вопроса
    public string Answer { get; set; } = null!;    // Ответ на вопрос
    public string Category { get; set; } = null!;  // Категория (например: "C#", "SQL", "OOP")
    public string Difficulty { get; set; } = null!;// Уровень сложности (например: "Junior", "Middle", "Senior")
    public DateTime CreatedAt { get; set; }
}