using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProtoWeb.Models
{
    public class User
    {
        public string Name { get; set; }
        public string HomeClub { get; set; }
        public int MemberId { get; set; }
        public double Handicap { get; set; }
        public string Status { get; set; }
        public int CurrentCourseId { get; set; }
        public int CurrentHolesFilled { get; set; }
    }
}
