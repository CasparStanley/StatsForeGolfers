using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProtoWeb.Models;

namespace ProtoWeb.Interfaces
{
    public interface ICourses
    {
        Dictionary<string, Course> AllCourses();
        Dictionary<string, Course> FilterCourse(string crtieria);
        void DeleteCourse(Course course);
        void AddCourse(Course course);
        void UpdateCourse(Course course);
        Course GetCourse(string name);
    }
}
