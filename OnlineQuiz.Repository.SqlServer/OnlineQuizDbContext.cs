using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineQuiz.Domain.Entities;

namespace OnlineQuiz.Repository.SqlServer
{
    public class OnlineQuizDbContext:IdentityDbContext<AppUser>
    {
        public OnlineQuizDbContext(DbContextOptions<OnlineQuizDbContext> options)
            : base(options)
        {
        }
       

    }
}
