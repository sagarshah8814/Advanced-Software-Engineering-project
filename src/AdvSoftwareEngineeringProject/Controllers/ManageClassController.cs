using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using AdvSoftwareEngineeringProject.Models;
using AdvSoftwareEngineeringProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.ExpressionTranslators.Internal;
using Microsoft.Extensions.Configuration;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace AdvSoftwareEngineeringProject.Controllers
{
    //Contoller for managing class
    public class ManageClassController : Controller
    {
        private ICourseRepository _courseRepository;
        private IStudentRepository _studentRepository;
        private UserManager<Student> _userManager;
        //Contoller constructor with parameters which are object of course and student repository
        public ManageClassController(ICourseRepository courseRepository,
            IStudentRepository studentRepository,UserManager<Student> userManager)
        {
            _studentRepository = studentRepository;
            _userManager = userManager;
            _courseRepository = courseRepository;
        }
        //Action method to go to the page with list of courses to manage with only Authorization for Instructors
        [Authorize(Roles = "Instructor")]
        public IActionResult List()
        {
            List<Course> courseRegistered = new List<Course>();
            var courseByStudent = _studentRepository.GetCourseByStudent(_userManager.GetUserId(User));
            foreach (var coursestudent in courseByStudent)
            {
                courseRegistered.Add(_courseRepository.GetCourseById(coursestudent.CourseId));
            }
            RegisteredCoursesViewModel registeredCoursesViewModel = new RegisteredCoursesViewModel()
            {
                Courses = courseRegistered

            };

            return View(registeredCoursesViewModel);
        }
        [Authorize(Roles = "Instructor")]
        public IActionResult Manage(ManageClassViewModel manageClass)
        {
            
            return View();
        }
        //Action method for page to post assignment for a particular class
        [Authorize(Roles = "Instructor")]
        [HttpPost]
        public IActionResult Manage(RegisteredCoursesViewModel registeredCoursesViewModel)
        {
            var manageClass = new ManageClassViewModel()
            {
                CourseId = registeredCoursesViewModel.CourseId,
                CourseName = registeredCoursesViewModel.CourseName
            };
           
            return View(manageClass);
        }
        //Action method to post assignment
        [Authorize(Roles = "Instructor")]
        [HttpPost]
        public IActionResult Assign(ManageClassViewModel manageClass)
        {
            if (ModelState.IsValid)
            {
                _courseRepository.SetAssignment(manageClass.CourseId, manageClass.Assignment,
                    manageClass.DueDateTime);
            }
            return RedirectToAction("List","ManageClass");
        }
        //Action method to see assignments posted
        [Authorize]
        public IActionResult CourseContent(int courseId)
        {
            var assignment = _courseRepository.GetAssignments(courseId);
            ManageClassViewModel manageClass=new ManageClassViewModel()
            {
                Assignments = assignment,
            };
            return View(manageClass);
        }
    }
}
