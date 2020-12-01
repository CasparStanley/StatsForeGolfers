using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProtoWeb.Models
{
    public class Course
    {
        public int Id { get; set; }
        [Required]
        [Range(typeof(string), "2", "40", ErrorMessage = "Your course may contain 2  to 40 letters")]
        public string name { get; set; }

        [Required]
        [Range(typeof(Dictionary<int, Hole>), "18", "18", ErrorMessage = "Your Course has to Contain 18 Holes")]
        private Dictionary<int, Hole> holes;

    }
}