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
        public DbSet<PlayerKill> PlayerKills { get; set; }

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

            //Two many to one might be bad, just do many to many.
            //But then it would be with a victim bool?
            //modelBuilder.Entity<Player>().HasMany<Kill>(p => p.Kills).WithOne(k => k.Killer).OnDelete(DeleteBehavior.Cascade);
            //modelBuilder.Entity<Player>().HasMany<Kill>(p => p.Deaths).WithOne(k => k.Victim).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<PlayerKill>()
                .HasKey(pk => new { pk.PlayerId, pk.KillId, pk.IsVictim });

            modelBuilder.Entity<PlayerKill>()
                .HasOne(pk => pk.Player)
                .WithMany(p => p.PlayerKills)
                .HasForeignKey(pk => pk.PlayerId);

            modelBuilder.Entity<PlayerKill>()
                .HasOne(pk => pk.Kill)
                .WithMany(k => k.PlayerKills)
                .HasForeignKey(pk => pk.KillId);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.KeyCloakId)
                .IsUnique();


            // Game
            modelBuilder.Entity<Game>().HasMany<Chat>(g => g.Chats).WithOne(c => c.Game);

  
            modelBuilder.Entity<Game>().HasMany<Player>(g => g.Players).WithOne(p => p.Game).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Player>().HasOne<Game>(p => p.Game).WithMany(g => g.Players).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Game>().HasMany<Kill>(g => g.Kills).WithOne(k => k.Game);

            // Constraint
            modelBuilder.Entity<Player>().HasIndex(player => player.BiteCode).IsUnique();

            // Set the Data
            modelBuilder.Entity<User>().HasData(SeedDataHelper.GetUsers());
            modelBuilder.Entity<Player>().HasData(SeedDataHelper.GetPlayers());
            modelBuilder.Entity<Game>().HasData(SeedDataHelper.GetGames());
            modelBuilder.Entity<Kill>().HasData(SeedDataHelper.GetKills());
            modelBuilder.Entity<Chat>().HasData(SeedDataHelper.GetChats());
            modelBuilder.Entity<PlayerKill>().HasData(SeedDataHelper.GetPlayerKills());


            //Add restrictions
            modelBuilder.Entity<User>().Property(u => u.FirstName).HasMaxLength(50);
            modelBuilder.Entity<User>().Property(u => u.LastName).HasMaxLength(50);
            
            modelBuilder.Entity<Player>().Property(p => p.BiteCode).HasMaxLength(50);

            modelBuilder.Entity<Game>().Property(g => g.Name).HasMaxLength(50);
            modelBuilder.Entity<Game>().Property(g => g.Description).HasMaxLength(800);

            modelBuilder.Entity<Chat>().Property(c => c.Message).HasMaxLength(200);

        }
    }
}
