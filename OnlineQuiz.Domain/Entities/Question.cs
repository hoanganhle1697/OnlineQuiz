public class Question
{
    public int Id { get; set; }
    public string Content { get; set; } = "";
    public List<string> Choices { get; set; } = new();
    public int CorrectAnswerIndex { get; set; }
    public QuestionLevel Level { get; set; }
}