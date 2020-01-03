using CollegeManagmentSystem.Infrastructure.Data;
using System.Data.Entity.Infrastructure;

namespace CollegeManagmentSystem.Infrastructure.Migrations
{
    public class MigrationsContextFactory : IDbContextFactory<CollegeContext>
    {
        public CollegeContext Create()
        {
            return new CollegeContext("CollegeContext");
        }
    }
}
