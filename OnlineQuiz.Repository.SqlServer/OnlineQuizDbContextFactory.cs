using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using OnlineQuiz.Domain.Entities;

namespace OnlineQuiz.Repository.SqlServer
{
    public class OnlineQuizDbContextFactory : IDesignTimeDbContextFactory<OnlineQuizDbContext>
    {
        public OnlineQuizDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<OnlineQuizDbContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("SqlConnection"));

            return new OnlineQuizDbContext(optionsBuilder.Options);
        }
    }
}