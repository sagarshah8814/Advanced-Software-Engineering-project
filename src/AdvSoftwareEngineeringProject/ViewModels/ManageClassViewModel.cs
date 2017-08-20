using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AdvSoftwareEngineeringProject.Models;

namespace AdvSoftwareEngineeringProject.ViewModels
{
    //ViewModel Class for Manage class controller
    public class ManageClassViewModel
    {
        public List<Student> Students { get; set; }
        public IEnumerable<Assignment> Assignments { get; set; }
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string InstructorName { get; set; }
        [Required]
        public string Assignment { get; set; }
        [Required]
        public DateTime DueDateTime { get; set; }
    }
}
