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
            Dictionary<int, Hole> NewHoles =  new Dictionary<int, Hole>();
            Dictionary<int, Course> courses = AllCourses();
            if (courses.ContainsKey(coursesId))
            {
                //NewHoles = courses[coursesId].course;
            }
            return NewHoles;
        }
        public Dictionary<int, Course> AllCourses()
        {
            return JsonFileReaderCourses.ReadJson(JsonFileName);
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
        }
        public void DeleteCourse(Course course)
        {
            Dictionary<int, Course> courses = AllCourses();
        }

        public void AddCourse(Course course)
        {
            Dictionary<int, Course> courses = AllCourses();
            courses.Add(course.Id,course);
            JsonFileWritterCourses.WriteToJson(courses,JsonFileName);
        }
            
            
        
    }
}
