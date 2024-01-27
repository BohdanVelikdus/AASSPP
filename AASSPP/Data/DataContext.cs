using AASSPP.Models;
using Microsoft.EntityFrameworkCore;
namespace AASSPP.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountType> AccountTypes { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Cashin> Cashins { get; set; }
        public DbSet<Cashout> Cashouts { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Transfer> Transfers { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Transfer>()
        //        .HasKey(  )
        //}
    }
}
