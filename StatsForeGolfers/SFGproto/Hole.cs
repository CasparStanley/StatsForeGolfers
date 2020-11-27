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
        public int Par { get; set; }
        public int Length { get; set; }
        public int Handicap { get; set; }

        public Hole()
        {
            
        }
        public Hole(int par, int length, int handicap)
        {
            Par = par;
            Length = length;
            Handicap = handicap;
        }
       
    }
}
