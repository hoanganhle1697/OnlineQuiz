using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineQuiz.Domain.Entities;

namespace OnlineQuiz.Infrastructure.Data
{
    public class OnlineQuizDbContext:IdentityDbContext<AppUser>
    {
        public OnlineQuizDbContext(DbContextOptions<OnlineQuizDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Configure the database connection here if not already configured
               base.OnConfiguring(optionsBuilder);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach(var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var tableName = entityType.GetTableName();
                if(tableName.StartsWith("AspNet"))
                {
                    // Remove AspNet prefix from Identity tables
                    entityType.SetTableName(tableName.Substring(6));
                }
            }

        }
    }
}
