using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdvSoftwareEngineeringProject.Services;
using AdvSoftwareEngineeringProject.ViewModels;

namespace AdvSoftwareEngineeringProject.Controllers
{
    //Controller class for home page
    public class HomeController : Controller
    {
        private readonly IMailService _mailService;

        public HomeController(IMailService mailService)
        {
            _mailService = mailService;
        }
        //Action method to get to home page
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(ContactViewModel contactView)
        {
            if (ModelState.IsValid)
            {

                _mailService.SendMail("sshah@ucmo.edu", contactView.Email, "ASE Project App", contactView.Message);
                ModelState.Clear();
                ViewBag.UserMessage = "Mail Sent";
            }
            return View();
        }
    }
}
