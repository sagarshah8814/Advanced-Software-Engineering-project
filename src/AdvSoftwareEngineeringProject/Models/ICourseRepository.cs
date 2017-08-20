using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvSoftwareEngineeringProject.Models
{
    //Interface class for Course Repository
    public interface ICourseRepository
    {
        IEnumerable<Course> Courses { get; }
        Course GetCourseByName(string courseName);
        Course GetCourseById(int courseId);
        void SetAssignment(int courseId,string assignmentData,DateTime dueDateTime);
        IEnumerable<Assignment> GetAssignments(int courseId);
    }
}
