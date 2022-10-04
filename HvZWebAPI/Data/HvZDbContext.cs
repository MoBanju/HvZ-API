using Microsoft.EntityFrameworkCore;
using HvZWebAPI.Models;

namespace HvZWebAPI.Data
{

    public class HvZDbContext : DbContext
    {
        // DbSets
        public DbSet<User> Users { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Kill> Kills { get; set; }
        public DbSet<Chat> Chats { get; set; }

        // 
        public HvZDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // User
            modelBuilder.Entity<User>().HasMany<Player>(u => u.Players).WithOne(p => p.User);

            //Player
            modelBuilder.Entity<Player>().HasMany<Chat>(p => p.Chats).WithOne(c => c.Player);
            modelBuilder.Entity<Player>().HasMany<Kill>(p => p.Kills).WithOne(k => k.Killer).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Player>().HasMany<Kill>(p => p.Deaths).WithOne(k => k.Victim).OnDelete(DeleteBehavior.NoAction);

            // Game
            modelBuilder.Entity<Game>().HasMany<Chat>(g => g.Chats).WithOne(c => c.Game);
            modelBuilder.Entity<Game>().HasMany<Player>(g => g.Players).WithOne(p => p.Game).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Player>().HasOne<Game>(p => p.Game).WithMany(g => g.Players).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Game>().HasMany<Kill>(g => g.Kills).WithOne(k => k.Game);

            // Set the Data
            modelBuilder.Entity<User>().HasData(SeedDataHelper.GetUsers());
            modelBuilder.Entity<Player>().HasData(SeedDataHelper.GetPlayers());
            modelBuilder.Entity<Game>().HasData(SeedDataHelper.GetGames());
            modelBuilder.Entity<Kill>().HasData(SeedDataHelper.GetKills());
            modelBuilder.Entity<Chat>().HasData(SeedDataHelper.GetChats());


        }
    }
}
