using System;
using System.Collections.Generic;
using System.Text;

namespace SFGproto
{
    class Club
    {
        public string Name { get; private set; }

        private List<Course> courses;

        public Club(string name)
        {
            courses = new List<Course>();
            Name = name;
        }

        public void AddCourse(Course course)
        {
            courses.Add(course);
        }
    }
}
