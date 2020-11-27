using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;

namespace SFGproto
{
    class Hole 
    {
        /// <summary>
        /// A Course contains 18 Holes which can contain different kind of Par(The amount of shots you have) 
        /// The Hole Class is going to be a super class which Different kind of "Par Hole" Classes are going to inherit from.
        /// </summary>
        public int HoleNo { get; set; }
        public int Par { get; set; }
        public int Length { get; set; }
        public double Handicap { get; set; } //det er muligt at have et decimal tal som Handicap ;-)

        public Hole()
        {
            
        }
        public Hole(int holeNo, int par, int length, double handicap)
        {
            HoleNo = holeNo;
            Par = par;
            Length = length;
            Handicap = handicap;
        }
       
    }
}
