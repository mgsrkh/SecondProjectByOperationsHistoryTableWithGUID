using Microsoft.EntityFrameworkCore;
using SecondProjectByOperationsHistoryTableWithGUID.Models;

namespace SecondProjectByOperationsHistoryTableWithGUID.Contexts
{
    public class ProjectContext : DbContext
    {
        public ProjectContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Vendor> Vendor { get; set; }
        public DbSet<Tag> Tag { get; set; }
        public DbSet<History> History { get; set; }
    }
}
