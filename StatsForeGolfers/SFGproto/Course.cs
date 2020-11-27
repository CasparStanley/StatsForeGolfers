using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace SFGproto
{
    class Course
    {
        public string Name { get; private set; }

        private Dictionary<int, Hole> holes;

        public Course(string name)
        {
            Name = name;
        }

        public void AddHole(int nr, Hole hole)
        {
            if (holes.ContainsKey(nr))
            {
                holes.Remove(nr);
            }

            holes.Add(nr, hole);
        }
    }
}
