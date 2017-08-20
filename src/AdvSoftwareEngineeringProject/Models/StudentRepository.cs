using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AdvSoftwareEngineeringProject.Models
{
    //Class for student repository
    public class StudentRepository:IStudentRepository
    {
        private readonly AppDbContext _appDbContext;
        
        //Controller for student repository with DbContext object parameter
        public StudentRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        /* Returns all the students in IEnumerable list with related department
        and coursestudent
             */
        public IEnumerable<Student> Students
        {
            get
            {
                return _appDbContext.Students.Include(c => c.CourseStudents)
                    .Include(d => d.Department); 
                
            }
        }
        //Returns student by username 
        public Student GetStudentByName(string username)
        {
            return _appDbContext.Students.FirstOrDefault(s => s.UserName == username);
        }

        //Adds course with studentId and courseId as parameter
        public void AddCourse(string studentId, int courseId)
        {
            var courseStudent = new CourseStudent()
            {
                CourseId = courseId,
                StudentId = studentId
            };
            _appDbContext.CourseStudent.Add(courseStudent);
            _appDbContext.SaveChanges();
        }

        //Returs Ienumerable list of coursestudent for given studentId
        public IEnumerable<CourseStudent> GetCourseByStudent(string studentId)
        {
            return _appDbContext.CourseStudent.Where(cs => cs.StudentId == studentId);
        }

        //Removes course from coursestudent table, removing course registered by student
        public void RemoveCourse(string studentId, int courseId)
        {
            var studentCourse = _appDbContext.CourseStudent
                .SingleOrDefault(s => s.StudentId == studentId && s.CourseId == courseId);
            _appDbContext.CourseStudent.Remove(studentCourse);
            _appDbContext.SaveChanges();
        }
    }
}
