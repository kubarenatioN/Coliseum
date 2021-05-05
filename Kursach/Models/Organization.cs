using System;
using System.Collections.Generic;

namespace Kursach
{
    public class Organization
    {
        public int Id { get; set; }
        public string ShortName { get; set; }
        public string FullName { get; set; }
        public string OrganizationLogo { get; set; }
        public string Location { get; set; }
        public DateTime FoundationDate { get; set; }
        
        public virtual ICollection<Team> Teams { get; set; }

        public override string ToString()
        {
            return $"{Id}: {ShortName} - {FullName}; {Location}, {FoundationDate}; {Teams}";
        }
    }
}
