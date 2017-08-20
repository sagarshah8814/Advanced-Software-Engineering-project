using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvSoftwareEngineeringProject.Models
{
    //Inetrface class for student repository
    public interface IStudentRepository
    {
       IEnumerable<Student> Students { get; }
        Student GetStudentByName(string username);
        void AddCourse(string studentId, int courseId);
        IEnumerable<CourseStudent> GetCourseByStudent(string studentId);
        void RemoveCourse(string studentId, int courseId);
    }
}
