using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProtoWeb.Models
{
    public class User
    {
        public string Status { get; set; }
        public string Name { get; set; }
        public string HomeClub { get; set; }
        public int MemberId { get; set; }
        public double Handicap { get; set; }

        public User() { }
        public User (string status, string name, string club, int id, double hcp)
        {
            Status = status;
            Name = name;
            HomeClub = club;
            MemberId = id;
            Handicap = hcp;
        }
    }
}
