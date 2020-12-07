using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProtoWeb.Models;

namespace ProtoWeb.Interfaces
{
    public interface ICourses
    {
        public void DeleteHole(Hole hole, int courseId);
        public Dictionary<int, Hole> AllHoles(int coursesId);
        public Hole GetHole(int holeNo, int courseId);
        public void AddHole(Hole hole, int courseId);
        public void UpdateHole(Hole hole, int courseId);
        Dictionary<int, Course> AllCourses();
        Dictionary<int, Course> FilterCourse(string crtieria);
        void DeleteCourse(Course course);
        void AddCourse(Course course);
        void UpdateCourse(Course course);
        Course GetCourse(int id);
    }
}
