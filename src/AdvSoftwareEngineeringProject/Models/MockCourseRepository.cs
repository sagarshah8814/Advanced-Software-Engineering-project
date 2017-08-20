using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvSoftwareEngineeringProject.Models
{
    //Mock repository class for testing
    public class MockCourseRepository : ICourseRepository
    {
        public IEnumerable<Course> Courses
        {
            get
            {
                return new List<Course>()
                {
                    new Course {CourseId = 1,Name = "Software Engineering", Credit = 3, DepartmentId = 1, InstructorId = 1},
                    new Course {CourseId = 2,Name = "Advance Database", Credit = 3, DepartmentId = 1, InstructorId = 2},
                    new Course {CourseId = 3,Name = "Guitar", Credit = 2, DepartmentId = 2, InstructorId = 3},
                    new Course {CourseId = 4,Name = "Jazz", Credit = 3, DepartmentId = 2, InstructorId = 4}                    
                };
            }
        }

        public Course GetCourseById(int courseId)
        {
            throw new NotImplementedException();
        }

        public Course GetCourseByName(string courseName)
        {
            throw new NotImplementedException();
        }

        public void SetAssignment(int courseId, string assignmentData, DateTime dueDateTime)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Assignment> GetAssignments(int courseId)
        {
            throw new NotImplementedException();
        }
    }
}
