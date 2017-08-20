using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdvSoftwareEngineeringProject.Models;
using AdvSoftwareEngineeringProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace AdvSoftwareEngineeringProject.Controllers
{
    //Controller for students to see list of enrolled classes with required authorization 
    [Authorize]
    public class RegisteredSummaryController : Controller
    {
        private readonly IStudentRepository _studentRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly UserManager<Student> _userManager;
        //Constructor for the controller with object parameters of student and course repository and usermanager
        public RegisteredSummaryController(IStudentRepository studentRepository,
            ICourseRepository courseRepository,UserManager<Student> userManager)
        {
            _studentRepository = studentRepository;
            _courseRepository = courseRepository;
            _userManager = userManager;
        }
        //Action to page listing registered course
        public IActionResult List()
        {

            List<Course> courseRegistered = new List<Course>();
            //gets all courses user has registered from student repository 
            var courseByStudent = _studentRepository.GetCourseByStudent(_userManager.GetUserId(User));
            foreach (var coursestudent in courseByStudent)
            {
                courseRegistered.Add(_courseRepository.GetCourseById(coursestudent.CourseId));
            }
            //set value of registeredcourseview model properties
            RegisteredCoursesViewModel registeredCoursesViewModel = new RegisteredCoursesViewModel()
            {
                Courses = courseRegistered
                
            };
            
            
        return View(registeredCoursesViewModel);
        }

        //Action for dropping a course
        [HttpPost]
        public async Task<IActionResult> Drop(RegisteredCoursesViewModel registeredCoursesViewModel)
        {
            var student = _studentRepository.GetStudentByName(User.Identity.Name);
            var course = _courseRepository.GetCourseById(registeredCoursesViewModel.CourseId);
            _studentRepository.RemoveCourse(student.Id,registeredCoursesViewModel.CourseId);
            //removes the credit hour from student database for dropped course
            student.CreditsEnrolled -= course.Credit;
           await _userManager.UpdateAsync(student);
            return RedirectToAction("List");
        }

    }
}
