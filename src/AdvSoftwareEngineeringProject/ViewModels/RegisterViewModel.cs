using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvSoftwareEngineeringProject.Models;


namespace AdvSoftwareEngineeringProject.ViewModels
{
    //ViewModel Class for course registration
    public class RegisterViewModel
    {
        public IEnumerable<Course> Courses { get; set; }
        public IEnumerable<Department>Departments { get; set; }
        [Required]
        public string CourseName { get; set; }
    }
}
