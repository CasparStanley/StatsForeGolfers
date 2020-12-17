using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using ProtoWeb.Helpers;
using ProtoWeb.Interfaces;
using ProtoWeb.Models;

namespace ProtoWeb.Services
{
    public class JsonFileCourses : ICourses
    {
        public IWebHostEnvironment WebHostEnvironment { get; }

        public JsonFileCourses(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        private string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "Data", "Courses.json"); }
        }

        public Dictionary<int, Hole> AllHoles(int coursesId)
        {
            Dictionary<int, Course> courses = AllCourses();
            if (courses.ContainsKey(coursesId))
            {
                return courses[coursesId].Holes;
            }
            return null;
        }
        public Hole GetHole(int holeNo,int courseId)
        {
            Dictionary<int, Hole> holes = AllHoles(courseId);
            Hole foundHole = holes[holeNo];
            return foundHole;
        }

        public void AddHole(Hole hole, int courseId)
        {
            Dictionary<int, Course> courses = AllCourses();
            Dictionary<int, Hole> holes = AllHoles(courseId);
            holes.Add(hole.HoleNo,hole);
            courses[courseId].Holes = holes;
            JsonHelper.WriteCourse(courses,JsonFileName);
        }

        public void DeleteHole(Hole hole, int courseId)
        {
            Dictionary<int, Course> courses = AllCourses();
            Dictionary<int, Hole> holes = AllHoles(courseId);
            holes.Remove(hole.HoleNo, out hole);
            courses[courseId].Holes = holes;
            JsonHelper.WriteCourse(courses, JsonFileName);
        }
        public void UpdateHole(Hole hole,int courseId)
        {
            Dictionary<int, Course> courses = AllCourses();
            Dictionary<int, Hole> holes = AllHoles(courseId);
            Hole foundHole = holes[hole.HoleNo];
            foundHole.HoleNo = hole.HoleNo;
            foundHole.Par = hole.Par;
            foundHole.Length = hole.Length;
            foundHole.Handicap = hole.Handicap;
            courses[courseId].Holes = holes;
            JsonHelper.WriteCourse(courses, JsonFileName);
        }
        public Dictionary<int, Course> AllCourses()
        {
            try { return JsonHelper.ReadCourse(JsonFileName); }
            catch (ArgumentException aExc) { Console.WriteLine(aExc); return null; }
        }

        public Dictionary<int, Course> FilterCourse(string crtieria)
        {
            Dictionary<int, Course> courses = AllCourses();
            Dictionary<int,Course> filteredCourses = new Dictionary<int, Course>();
            foreach (var h in courses.Values)
            {
                if (h.Name.ToLower().Contains(crtieria.ToLower()))
                {
                    filteredCourses.Add(h.Id,h);
                }
            }

            return filteredCourses;
        }

        public Course GetCourse(int id)
        {
            Dictionary<int, Course> courses = AllCourses();
            Course foundCourse = courses[id];
            return foundCourse;
        }

        public void UpdateCourse(Course course)
        {
            Dictionary<int, Course> courses = AllCourses();
            Course foundCourse = courses[course.Id];
            foundCourse.Name = course.Name;
            JsonHelper.WriteCourse(courses,JsonFileName);
        }
        public void DeleteCourse(Course course)
        {
            Dictionary<int, Course> courses = AllCourses();
            courses.Remove(course.Id);
            JsonHelper.WriteCourse(courses, JsonFileName);
        }

        public void AddCourse(Course course)
        {
            Dictionary<int, Course> courses = AllCourses();
            courses.Add(course.Id,course);
            JsonHelper.WriteCourse(courses,JsonFileName);
        }
    }
}
