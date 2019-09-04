using System;
using System.Collections.Generic;
using System.Text;
using ChessBackend.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Internal;

namespace ChessBackend.Data
{
    public class Context : IdentityDbContext<User>
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
