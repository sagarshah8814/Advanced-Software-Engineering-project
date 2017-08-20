using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AdvSoftwareEngineeringProject.Models
{
    //Model class for connecting courses and students
    public class CourseStudent
    {
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public string StudentId { get; set; }
        public Student Student { get; set; }
    }
}
