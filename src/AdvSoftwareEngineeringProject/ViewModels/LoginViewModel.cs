using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdvSoftwareEngineeringProject.ViewModels
{
    //View model class for Login to pass and store data between controller and view
    public class LoginViewModel
    {
        [Required,Display(Name = "User Name")]
        public string Username { get; set; }

        [Required,DataType(DataType.Password)]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }

    }
}
