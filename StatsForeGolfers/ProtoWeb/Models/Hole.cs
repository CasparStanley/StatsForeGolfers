using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Nito.Comparers.Fixes;

namespace ProtoWeb.Models
{
    public class Hole
    {
        public int HoleNo { get; set; }

        public int Par { get; set; }
        public int Length { get; set; }
        public double Handicap { get; set; }
    }
}