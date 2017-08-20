using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace AdvSoftwareEngineeringProject.Models
{
    //Student model class which implements IdentityUser class, which supports .Net Identity
    public class Student:IdentityUser
    {
        public string StudentName { get; set; }
        public int CreditsEnrolled { get; set; }
        public bool IsMaxCreditEnrolled { get; set; }
        public int DapartmentId { get; set; }
        public virtual Department Department { get; set; }
        public virtual List<CourseStudent> CourseStudents { get; set; }
    }
    
}
