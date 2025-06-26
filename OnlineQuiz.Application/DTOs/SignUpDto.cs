namespace OnlineQuiz.Application.DTOs;

public class SignUpDto
{
    public int Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public bool Gender { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string AvatarUrl { get; set; } = string.Empty;
    public bool Status { get; set; }
    public string Password { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
}
