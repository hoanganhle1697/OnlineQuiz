namespace OnlineQuiz.Domain.Interfaces
{
    public interface IAuthService
    {
        public async Task<LoginResult> LoginAsync(SignInDto signInDto);
        public async Task<IdentityResult> RegisterAsync(SignUpDto signUpDto);
    }
}
