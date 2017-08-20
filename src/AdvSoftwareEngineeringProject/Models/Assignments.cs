using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvSoftwareEngineeringProject.Models
{
    //Model class for assignment with it's properties
    public class Assignment
    {
        public int AssignmentId { get; set; }
        public string AssignmentData { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DueDate { get; set; }
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }
    }
}
