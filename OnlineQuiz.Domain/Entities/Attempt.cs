public class Attempt
{
    public int Id { get; set; }
    public string UserId { get; set; } = "";
    public int ExamId { get; set; }
    public DateTime SubmittedAt { get; set; }
    public int Score { get; set; }
}