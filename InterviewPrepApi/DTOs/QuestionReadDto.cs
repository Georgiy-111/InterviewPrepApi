namespace InterviewPrepApi.DTOs;

public class QuestionReadDto
{
    public int Id { get; set; }
    public string Text { get; set; }
    public string Answer { get; set; }
    public string Category { get; set; }
    public string Difficulty { get; set; }
}