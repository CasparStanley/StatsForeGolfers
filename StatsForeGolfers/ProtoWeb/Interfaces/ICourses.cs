using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProtoWeb.Models;

namespace ProtoWeb.Interfaces
{
    public interface ICourses
    {
        Dictionary<string, Course> AllHoles();
        Dictionary<string, Courses> FilterHole(string crtieria);
        void DeleteHole(Course course);
        void AddHole(Course course);
        void UpdateHole(Course course);
        Hole GetHole(string name);
    }
}
