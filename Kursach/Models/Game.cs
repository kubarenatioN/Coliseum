using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kursach
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //public List<GameGenre> Genres { get; set; }

        public string Developer { get; set; }
        public DateTime? AnnounceDate { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public bool IsCompetitive { get; set; }
        public string GameLogo { get; set; }

        #region Foreign Fields

        public virtual GameImages GameImage { get; set; }
       
        /// <summary>
        /// Teams playing this game
        /// </summary>
        public virtual ICollection<Team> Teams { get; set; }
        public virtual ICollection<Player> Players { get; set; }
        public virtual ICollection<UsersGames> UsersGames { get; set; }

        #endregion

        public Game()
        {
            UsersGames = new List<UsersGames>();
        }

        public override string ToString()
        {
            return $"{Id}: {Name}; Teams: {Teams}";
        }

    }
}
