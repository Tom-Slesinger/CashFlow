using Microsoft.EntityFrameworkCore;

namespace CashFlow.Models
{
    public class CashFlowContext : DbContext
    {
        private readonly string? _connectionString;
        public CashFlowContext(DbContextOptions<CashFlowContext> options, IConfiguration config) : base(options)
        {
            _connectionString = config["LocalSQLConnectionString"];
        }

        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transaction>().ToTable("TRANSACTION_T");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
