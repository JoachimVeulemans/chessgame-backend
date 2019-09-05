using ChessBackend.Data.DataEntities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ChessBackend.Data
{
    public class ChessContext : IdentityDbContext<User>
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<FamousGame> FamousGames { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ChessDB;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>()
                .HasOne(g => g.WhitePlayer)
                .WithMany(u => u.GamesAsWhite)
                .HasForeignKey(g => g.WhitePlayerId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Game>()
                .HasOne(g => g.BlackPlayer)
                .WithMany(u => u.GamesAsBlack)
                .HasForeignKey(g => g.BlackPlayerId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            base.OnModelCreating(modelBuilder);
        }
    }
}
