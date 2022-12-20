using Microsoft.EntityFrameworkCore;

namespace CashFlow.Models
{
    public class CashFlowContext : DbContext
    {
        public CashFlowContext(DbContextOptions<CashFlowContext> options) : base(options)
        {
        }

        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transaction>().ToTable("TRANSACTION_T");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-2CFL393\\ASPNETDATABASE;Initial Catalog=CashFlow;Integrated Security=True ;Encrypt=False");
        }
    }
}
