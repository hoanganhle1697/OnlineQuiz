using Microsoft.AspNetCore.Identity;
using OnlineQuiz.Application.DTOs;

namespace OnlineQuiz.Application.Services.Interfaces
{
    public interface IAuthServices
    {
        Task<LoginResult> LoginAsync(SignInDto signInDto);
        Task<IdentityResult> RegisterAsync(SignUpDto signUpDto);
    }
}
