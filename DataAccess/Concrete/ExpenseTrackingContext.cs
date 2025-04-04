using Entities;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete
{
    public class ExpenseTrackingContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
                "server=nozomi.proxy.rlwy.net;port=10187;database=railway;user=root;password=zmufEKXALajnqIrCZyJbmbptQtJvYwTw;",
                new MySqlServerVersion(new Version(8, 0, 31))            );
        }
        

        public DbSet<Category> Categories { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Revenue> Revenues { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
