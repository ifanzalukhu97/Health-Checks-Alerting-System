using Microsoft.EntityFrameworkCore;

namespace health_checks_and_alerting.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    }
}