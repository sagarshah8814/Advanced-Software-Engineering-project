using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvSoftwareEngineeringProject.Models
{
    //Model class for Course with it's properties
    public class Course
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
        public int Credit { get; set; }
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        public virtual List<CourseStudent> CourseStudents{ get; set; }
        public virtual Instructor Instructor { get; set; }
        public int InstructorId { get; set; }
        public virtual List<Assignment> Assignments { get; set; }
    }
}
