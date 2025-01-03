using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using App.Domain.Core.Bank.Cards.Entities;
using App.Domain.Core.Bank.TransAction.Entities;
using App.Domain.Core.Bank.User.Entities;
using Connection.Configuration;
using Quiz.Connections;

namespace Connection
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(ConnectionsString.Connection1);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new CardConfiguration());
            modelBuilder.ApplyConfiguration(new TransacrionConfiguration());
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<TransAction> Transactions { get; set; }
    }
}
