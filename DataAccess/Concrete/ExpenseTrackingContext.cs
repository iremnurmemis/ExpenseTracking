using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete
{
    public class ExpenseTrackingContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
                "server=nozomi.proxy.rlwy.net;port=10187;database=railway;user=root;password=zmufEKXALajnqIrCZyJbmbptQtJvYwTw;",
                new MySqlServerVersion(new Version(8, 0, 31)) // MySQL sürümüne dikkat et
            );
        }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
