using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdvSoftwareEngineeringProject.Models;
using AdvSoftwareEngineeringProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace AdvSoftwareEngineeringProject.Controllers
{
    //Controller class for login, registration and password management
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<Student> _userManager;
        private readonly SignInManager<Student> _signInManager;
        private AppDbContext _context;

        /*Constructor for the controller class with parameters for usermanager,signin manager and
         DbContext class accessed with the help of dependency*/
            public AccountController(UserManager<Student> userManager,
            SignInManager<Student> signInManager,AppDbContext context )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }
        // Action for Login with a return URl which is the url which reuired authentication
        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            return View(new LoginViewModel()
            {
                ReturnUrl=returnUrl
            });
        }
        //Action to check user for appropriate username and password
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel logInViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(logInViewModel);
            }
            //finds user by the user name provided
            var user = await _userManager.FindByNameAsync(logInViewModel.Username);
            if (user != null)
            {
                //checks for password match
             var   result = await _signInManager.PasswordSignInAsync(user, logInViewModel.Password, false, false);
                if (result.Succeeded)
                {
                    if (string.IsNullOrEmpty(logInViewModel.ReturnUrl))
                        return RedirectToAction("Index", "Home");

                    return Redirect(logInViewModel.ReturnUrl);
                }
            }
            //If error occurs send back to login page with error message
            ModelState.AddModelError("","Username/Password Not FOund");
            return View(logInViewModel);
        }
        //Action for validating registration inputs and creating a new user
        [HttpPost]
        [AllowAnonymous]
       public async Task<IActionResult> RegisterUser(RegisterUSerViewModel registerUserViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = new Student()
                {
                    UserName = registerUserViewModel.UserName,
                    StudentName = registerUserViewModel.Name,
                    Email = registerUserViewModel.Email
                };
                var result = await _userManager.CreateAsync(user, registerUserViewModel.Password);
                if (result.Succeeded)
                {
                    //this section is for creating a new user role and assigning them to that role
                    /*var roleStore=new RoleStore<IdentityRole>(_context);
                         await roleStore.CreateAsync(new IdentityRole {Name = "Instructor", NormalizedName = "Instructor"});*/
                       // await _userManager.AddToRoleAsync(user, "Instructor");
                         
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("",error.Description);
                    }
                }
            }
            return View(registerUserViewModel);
        }
        //Action method for the registration page 
        [AllowAnonymous]
        public IActionResult RegisterUser()
        {
            return View();
        }
        // Action method for logout page
        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        //Action for resetting old password and assigning a new one
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> ForgotPassword(RegisterUSerViewModel registerUSerViewModel)
        {
            var user = await _userManager.FindByNameAsync(registerUSerViewModel.UserName);
            if (user != null)
            {
                await _userManager.RemovePasswordAsync(user);
                var result = await _userManager.AddPasswordAsync(user, registerUSerViewModel.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Login", "Account");
                }

                return RedirectToAction("ForgotPassword", "Account");
            }
            return RedirectToAction("ForgotPassword", "Account");
        }
        //Action for getting username to reset password
        [AllowAnonymous]
        [HttpPost]
        public IActionResult PasswordReset(string userName)
        {
            RegisterUSerViewModel registerUSerViewModel = new RegisterUSerViewModel()
            {
                UserName = userName
            };
            return View(registerUSerViewModel);
        }
        //Action for forgot password page
        [AllowAnonymous]
        public IActionResult ForgotPassword()
        {
            return View();
        }

    }
}
