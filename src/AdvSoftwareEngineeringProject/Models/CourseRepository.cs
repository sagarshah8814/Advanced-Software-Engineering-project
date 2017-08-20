using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AdvSoftwareEngineeringProject.Models
{
    //A repository class for course model
    public class CourseRepository:ICourseRepository
    {
        private readonly AppDbContext _appDbContext;

        //Constructor for the class with dbcontext object as a parameter
        public CourseRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        //Gets IEnumerable list of courses including related department,coursestudent and instructors
        public IEnumerable<Course> Courses
        {
            get
            {
                return _appDbContext.Courses.Include(c => c.Department)
                    .Include(c => c.CourseStudents).Include(c => c.Instructor);
            }
            
        }
        //gets course by name taking course name as a parameter
        public Course GetCourseByName(string courseName)
        {
            return _appDbContext.Courses.FirstOrDefault(c => c.Name == courseName);
        }
        //gets instructor by Id taking instructor Id as a parameter
        public Instructor GetInstructorById(int instructorId)
        {
            return _appDbContext.Instructors.FirstOrDefault(i => i.InstructorId==instructorId);
        }
        //Gets course by Id
        public Course GetCourseById(int courseId)
        {
            return _appDbContext.Courses.FirstOrDefault(c => c.CourseId == courseId);
        }
        //Sets assignment for a cousre with due date and posted date
        public void SetAssignment(int courseId, string assignmentData, DateTime dueDateTime)
        {
            var assignment=new Assignment()
            {
                CourseId = courseId,
                AssignmentData = assignmentData,
                DateAdded = DateTime.Now,
                DueDate = dueDateTime
            };
            _appDbContext.Assignment.Add(assignment);
            _appDbContext.SaveChanges();
        }
        //Gets assignments for a course posted taking course id as a parameter
        public IEnumerable<Assignment> GetAssignments(int courseId)
        {
            return _appDbContext.Assignment.Where(a => a.CourseId == courseId).OrderBy(n=>n.DateAdded);
        }
    }
}
