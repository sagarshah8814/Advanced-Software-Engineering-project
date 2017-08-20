using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvSoftwareEngineeringProject.Models;
using AdvSoftwareEngineeringProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace AdvSoftwareEngineeringProject.Controllers
{
    public class RegisterCourseController:Controller

    {
        private readonly ICourseRepository _courseRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly UserManager<Student> _userManager;
        /*Constructor for this controller with object parameters of course,department,
        student repository and user*/
        public RegisterCourseController(ICourseRepository courseRepository,
            IDepartmentRepository departmentRepository, 
            IStudentRepository studentRepository,UserManager<Student> userManager)
        {
            _courseRepository = courseRepository;
            _departmentRepository = departmentRepository;
            _studentRepository = studentRepository;
            _userManager = userManager;
        }
        //Action for register page with authorization
        [Authorize]
        public IActionResult Index()
        {
            RegisterViewModel registerViewModel=new RegisterViewModel();
            registerViewModel.Courses = _courseRepository.Courses;
            registerViewModel.Departments = _departmentRepository.Departments;
            //set viewbag content with TempData 
            if (TempData["status"]!=null)
            {
                ViewBag.Message = TempData["status"].ToString();
                TempData.Remove("status");
            }
            return View(registerViewModel);
        }
        //Post Action for registering selected course
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Index(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid && registerViewModel.CourseName!=null)
            {
                var user = User.Identity.Name;
                
                var student = _studentRepository.GetStudentByName(user);
                var course = _courseRepository.GetCourseByName(registerViewModel.CourseName);
                //checks if student has enrolled in more than 9 credit hours
                if (student.CreditsEnrolled < 9)
                {
                    _studentRepository.AddCourse(student.Id, course.CourseId);
                    student.CreditsEnrolled += course.Credit;
                    await _userManager.UpdateAsync(student);
                    return RedirectToAction("List", "RegisteredSummary");
                }
                else
                {
                    //If student has more than 9 credit hours, set Tempdata with message and redirect to same page
                    TempData["status"] = "Cannot enroll For More Than 9 Credit Hpurs.";
                    return RedirectToAction("Index","RegisterCourse");
                }
            }
            else
            {
                //If student has not selected valid course to register then set TempData message
                TempData["status"] = "Please select a course.";
                return RedirectToAction("Index","RegisterCourse");
            }
        } 
        
    }
}
