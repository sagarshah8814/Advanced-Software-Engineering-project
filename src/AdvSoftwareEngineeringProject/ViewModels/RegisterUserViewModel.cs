using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvSoftwareEngineeringProject.ViewModels
{
    //ViewModel calss for user registration
    public class RegisterUSerViewModel
    {
        [Required,Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required,DataType(DataType.Password)]
        public string Password { get; set; }

        [Required,DataType(DataType.Password),Compare("Password")]
        public string ConfirmPassword { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }     
    }
}
