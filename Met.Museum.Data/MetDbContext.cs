using Microsoft.EntityFrameworkCore;

namespace Met.Museum.Data
{
    public class MetDbContext : DbContext
    {
        public DbSet<ErrorLog> ErrorLogs { get; set; }
        public DbSet<SearchHistory> SearchHistories { get; set; }
        public string? DbPath { get; }

        public MetDbContext(DbContextOptions<DbContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        public MetDbContext()
        {
            var folder = Environment.CurrentDirectory;
            string? dbFolder = Directory.GetParent(folder)?.FullName;
            DbPath = Path.Join(dbFolder, "Met.Museum.Data", "Met.Repository.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
               => options.UseSqlite($"Data Source={DbPath}");
    }

}
