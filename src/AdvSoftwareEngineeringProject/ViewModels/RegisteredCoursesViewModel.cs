using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdvSoftwareEngineeringProject.Models;

namespace AdvSoftwareEngineeringProject.ViewModels
{
    //ViewModel class to store and pass data between controller and view for registered courses
    public class RegisteredCoursesViewModel
    {
        public List<Course> Courses { get; set; }
        public int CourseId { get; set; }
        public string CourseName { get; set; }
    }
}
