using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvSoftwareEngineeringProject.Models
{
    //Model class for department
    public class Department
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public List<Course> Courses{ get; set; }
        public List<Student> Students { get; set; }
    }
}
