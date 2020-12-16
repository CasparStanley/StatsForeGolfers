using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace ProtoWeb.Models
{
    public class Hole
    {
        [Range(typeof(decimal),"1","18")]
        public int HoleNo { get; set; }
        [Range(typeof(decimal),"3","5")]
        public int Par { get; set; }
        public int Length { get; set; }
        public double Handicap { get; set; }
    }
}