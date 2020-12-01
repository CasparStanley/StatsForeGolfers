using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProtoWeb.Models
{
    public class Hole
    {
        [Required]
        [Range(typeof(int), "1", "18", ErrorMessage = "Value of holeNo Should be between 1 and 18")]
        public int HoleNo { get; set; }

        [Required]
        [Range(typeof(int), "3", "5", ErrorMessage = "Value for Par should be between 3 and 5")]
        public int Par { get; set; }
        public int Length { get; set; }
        public double Handicap { get; set; }
    }
}