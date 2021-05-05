using Microsoft.EntityFrameworkCore;

namespace Kursach
{
    public class ColiseumDbContext : DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserAccountInfo> UsersAccountInfo { get; set; }
        public DbSet<UserPublicInfo> UsersPublicInfo { get; set; }
        public DbSet<ColorTheme> ColorThemes { get; set; }
        public DbSet<Friendship> Friendships { get; set; }
        public DbSet<UsersGames> UsersGames { get; set; }
        public DbSet<EventsTeams> EventsTeams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Friendship>()
                .HasKey(f => new { f.UserId, f.FriendId });

            modelBuilder.Entity<Friendship>()
                .HasOne(f => f.User)
                .WithMany(u => u.UserFriendWith)
                .HasForeignKey(f => f.UserId);

            modelBuilder.Entity<Friendship>()
                .HasOne(f => f.Friend)
                .WithMany(fr => fr.UserFriendTo)
                .HasForeignKey(f => f.FriendId)
                .OnDelete(DeleteBehavior.NoAction);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=MYLAPTOP;Initial Catalog=Coliseumdb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }
    }
}
