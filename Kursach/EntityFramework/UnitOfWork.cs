using System;
using System.Threading.Tasks;

namespace Kursach
{
    public static class UnitOfWork
    {
        private static readonly ColiseumDbContext context;
        public static Repository<Event> Events { get; set; }
        public static Repository<Game> Games { get; set; }
        public static Repository<Article> News { get; set; }
        public static Repository<Organization> Organizations { get; set; }
        public static Repository<Team> Teams { get; set; }
        public static Repository<Player> Players { get; set; }
        public static Repository<User> Users { get; set; }
        public static Repository<UserPublicInfo> UserPublicInfos { get; set; }
        public static Repository<Friendship> Friendships { get; set; }
        public static Repository<UsersGames> UsersGames { get; set; }
        public static Repository<EventsTeams> EventsTeams { get; set; }

        static UnitOfWork()
        {
            context = new ColiseumDbContext();

            Events = new Repository<Event>(context);
            Games = new Repository<Game>(context);
            News = new Repository<Article>(context);
            Organizations = new Repository<Organization>(context);
            Teams = new Repository<Team>(context);
            Players = new Repository<Player>(context);
            Users = new Repository<User>(context);
            Friendships = new Repository<Friendship>(context);
            UsersGames = new Repository<UsersGames>(context);
            UserPublicInfos = new Repository<UserPublicInfo>(context);
            EventsTeams = new Repository<EventsTeams>(context);
        }

        public static void Save()
        {
            context.SaveChanges();
        }
        public static void Dispose()
        {
            context.Dispose();
        }
    }
}
