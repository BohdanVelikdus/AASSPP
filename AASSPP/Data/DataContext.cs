using AASSPP.Models;
using Microsoft.EntityFrameworkCore;
namespace AASSPP.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            this.ChangeTracker.LazyLoadingEnabled = true;
        }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Cashin> Cashins { get; set; }
        public DbSet<Cashout> Cashouts { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Transfer> Transfers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // one to many: one owner has multiple card
            modelBuilder.Entity<Owner>()
                .HasKey(o => o.Id);
            modelBuilder.Entity<Card>()
                .HasKey(c => c.Id);
            modelBuilder.Entity<Owner>()
                .HasMany(o => o.Cards)
                .WithOne(c => c.Owner)
                .HasForeignKey(c => c.OwnerId);
            // One-to-Many relationship: One Country can have multiple Owners
            modelBuilder.Entity<Owner>()
                .HasKey(o => o.Id);
            modelBuilder.Entity<Country>()
                .HasKey(c => c.Id);
            modelBuilder.Entity<Country>()
                .HasMany(c => c.Owners)
                .WithOne(o => o.Country)
                .HasForeignKey(o => o.CountryId);
            //One to many: one card has many cashins
            modelBuilder.Entity<Card>()
                .HasKey(c => c.Id);
            modelBuilder.Entity<Cashin>()
                .HasKey(csi => csi.Id);
            modelBuilder.Entity<Card>()
                .HasMany(c => c.Cashins)
                .WithOne(cs => cs.Card)
                .HasForeignKey(k => k.CardId);
            // One to many: one card has many cashouts
            modelBuilder.Entity<Card>()
               .HasKey(c => c.Id);
            modelBuilder.Entity<Cashout>()
                .HasKey(csi => csi.Id);
            modelBuilder.Entity<Card>()
                .HasMany(c => c.Cashouts)
                .WithOne(cs => cs.Card)
                .HasForeignKey(k => k.CardId);
            // Many to many for Transfers 
            //modelBuilder.Entity<Card>()
            //.HasKey(c => c.Id);
            //modelBuilder.Entity<Transfer>()
            //    .HasKey(t => t.Id);
            //modelBuilder.Entity<Card>()
            //    .HasMany(c => c.Transfers)
            //    .WithMany(t => t.Cards)
            //    .UsingEntity(j => j.ToTable("CardTransfers"));

            //rebuild transfer
            modelBuilder.Entity<Card>()
            .HasKey(c => c.Id);
            modelBuilder.Entity<Transfer>()
                .HasKey(t => t.Id);
            modelBuilder.Entity<Card>()
                .HasMany(c => c.Transfers)
                .WithOne(t => t.Card)
                .HasForeignKey(k => k.CardId);

            //end
            base.OnModelCreating(modelBuilder);
        }
    }
}
