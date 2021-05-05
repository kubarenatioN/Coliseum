using System;

namespace Kursach
{
    public class Player
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public DateTime? BirthDay { get; set; }
        public string Country { get; set; }
        public string Biography { get; set; }
        public string NickName { get; set; }
        public string Position { get; set; }

        public virtual Game Game { get; set; }
        public virtual Team Team { get; set; }

        public override string ToString()
        {
            return $"{Id}: {FirstName} - {Game.Name} - {Team.Organization.FullName}";
        }
    }
}
