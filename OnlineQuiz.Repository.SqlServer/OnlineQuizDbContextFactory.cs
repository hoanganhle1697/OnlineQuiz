using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using OnlineQuiz.Domain.Entities;
using System.IO;

namespace OnlineQuiz.Repository.SqlServer
{
    public class OnlineQuizDbContextFactory : IDesignTimeDbContextFactory<OnlineQuizDbContext>
    {
        public OnlineQuizDbContext CreateDbContext(string[] args)
        {
            var basePath = Path.GetDirectoryName(typeof(OnlineQuizDbContextFactory).Assembly.Location);
            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath!)
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<OnlineQuizDbContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

            return new OnlineQuizDbContext(optionsBuilder.Options);
        }
    }
}