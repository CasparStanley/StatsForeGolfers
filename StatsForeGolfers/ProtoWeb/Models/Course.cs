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
        
        [Range(typeof(string), "2", "40", ErrorMessage = "Your course may contain 2  to 40 letters")]
        public string Name { get; set; }

       
      
        public Dictionary<int, Hole> Holes { get; set; }

      
    }
}