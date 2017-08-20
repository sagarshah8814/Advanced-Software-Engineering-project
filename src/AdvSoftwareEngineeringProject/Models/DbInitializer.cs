using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Formatters.Internal;
using Microsoft.Extensions.DependencyInjection;

namespace AdvSoftwareEngineeringProject.Models
{
    //Class for injecting initial data
    public class DbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            AppDbContext context = applicationBuilder.ApplicationServices.GetRequiredService<AppDbContext>();
            //sets department table with data
            if (!context.Departments.Any())
            {
                context.Departments.AddRange(Departments.Select(d=>d.Value));
            }
            //stes instructor table with data
            if (!context.Instructors.Any())
            {
                context.Instructors.AddRange(Instructors.Select(i=>i.Value));
            }
            //sets course table with data
            if (!context.Courses.Any())
            {
                context.Courses.AddRange
                    (
                    new Course {Name="Software Engineering",Credit=3,Department = Departments["Computer Science"],Instructor = Instructors["Sunae Shin"]},
                    new Course {Name="Algorithm and Data Structures",Credit=3, Department = Departments["Computer Science"], Instructor = Instructors["Mohammad Rawashdeh"] },
                    new Course {Name="Database Systems",Credit=3, Department = Departments["Computer Science"], Instructor = Instructors["Sunae Shin"] },
                    new Course {Name="Operating Systems",Credit=3, Department = Departments["Computer Science"], Instructor = Instructors["Mohammad Rawashdeh"] },
                    new Course {Name="Data Mining",Credit=3, Department = Departments["Computer Science"], Instructor = Instructors["Fei Cao"] },
                    new Course {Name="Advance System Projects",Credit=3, Department = Departments["Computer And Information Science"], Instructor = Instructors["Sam S Ramanujan"] },
                    new Course {Name="Rdgs in Computer Info Systems",Credit=3, Department = Departments["Computer And Information Science"], Instructor = Instructors["Someswar Kesh"] },
                    new Course {Name="Business Info Management",Credit=3, Department=Departments["Computer And Information Science"], Instructor = Instructors["Linda K Lynum"] },
                    new Course {Name="Management Information Systems",Credit=3, Department = Departments["Computer And Information Science"], Instructor = Instructors["Sam S Ramanujan"] },
                    new Course {Name="Special Projects",Credit=3, Department = Departments["Computer And Information Science"], Instructor = Instructors["Linda K Lynum"] },
                    new Course {Name="Current Issues in Industry",Credit=3, Department = Departments["Industrial Management"], Instructor = Instructors["Ronald C Woosely"] },
                    new Course {Name="Industrial Management",Credit=3, Department = Departments["Industrial Management"], Instructor = Instructors["William R Ford"] },
                    new Course {Name="Project Management",Credit=3, Department = Departments["Industrial Management"], Instructor = Instructors["Ronald C Woosely"] },
                    new Course {Name="Organizational Dynamics",Credit=3, Department = Departments["Industrial Management"], Instructor = Instructors["Ronald C Woosely"] },
                    new Course {Name="Seminar in Industrial Management",Credit=3, Department = Departments["Industrial Management"], Instructor = Instructors["Suhansa Rodchua"] },
                    new Course {Name="Applied Research In Technology",Credit=3, Department = Departments["School Of Technology"], Instructor = Instructors["Marietta J Byerline"] },
                    new Course {Name="Special Projects in Technology",Credit=3, Department = Departments["School Of Technology"], Instructor = Instructors["Marietta J Byerline"] },
                    new Course {Name="Special Problems In Technology",Credit=3, Department = Departments["School Of Technology"], Instructor = Instructors["Ronnie R Rollins"] },
                    new Course {Name="Internship In Applied Science",Credit=3, Department = Departments["School Of Technology"], Instructor = Instructors["Kyle W Palmer"] },
                    new Course {Name="Internship In Technology",Credit=3, Department = Departments["School Of Technology"], Instructor = Instructors["Ronnie R Rollins"] },
                    new Course {Name="Interior Design Drafting",Credit=3, Department = Departments["Art"], Instructor = Instructors["Susan Stevenson"] },
                    new Course {Name="2-D Design",Credit=3, Department = Departments["Art"], Instructor = Instructors["Justin D Shaw"] },
                    new Course {Name="3-D Design",Credit=3, Department = Departments["Art"], Instructor = Instructors["David C Babcock"] },
                    new Course {Name="Web Design",Credit=3, Department = Departments["Art"], Instructor = Instructors["Justin D Shaw"] },
                    new Course {Name="Motion Design",Credit=3, Department = Departments["Art"], Instructor = Instructors["Susan Stevenson"] }
                    );
            }
            context.SaveChanges();
        }
        private static Dictionary<string, Department> departments;
        private static Dictionary<string, Instructor> instructors;
        //putting department data in key-value pair
        public static Dictionary<string, Department> Departments
        {
            get
            {
                if (departments == null)
                {
                    var departmentList = new Department[]
                    {
                        new Department { Name = "Computer Science" },
                        new Department { Name = "Computer And Information Science" },
                        new Department { Name = "Industrial Management" },
                        new Department { Name = "School Of Technology" },
                        new Department { Name = "Art" }
                    };

                    departments = new Dictionary<string, Department>();

                    foreach (Department d in departmentList)
                    {
                        departments.Add(d.Name, d);
                    }
                }

                return departments;
            }
        }
        //putting instructor data in key value pair
        public static Dictionary<string,Instructor> Instructors
        {
            get
            {
                if (instructors == null)
                {
                    var instructorList=new Instructor[]
                    {
                        new Instructor {Name = "Sunae Shin",InstructorEmail = "sunaeshin@aseproject.com"}, 
                        new Instructor {Name = "Fei Cao",InstructorEmail = "feicao@aseproject.com"}, 
                        new Instructor {Name = "Mohammad Rawashdeh",InstructorEmail = "mrawasdeh@aseproject.com"}, 
                        new Instructor {Name = "Sam S Ramanujan",InstructorEmail = "samramanujan@aseproject.com"}, 
                        new Instructor {Name = "Linda K Lynum",InstructorEmail = "lindalynum@aseproject.com"}, 
                        new Instructor {Name = "Someswar Kesh",InstructorEmail = "someswarkesh@aseproject.com"}, 
                        new Instructor {Name = "Ronald C Woosely",InstructorEmail = "ronaldwoosely@aseproject.com"}, 
                        new Instructor {Name = "William R Ford",InstructorEmail = "williamford@aseproject.com"}, 
                        new Instructor {Name = "Suhansa Rodchua",InstructorEmail = "suhansa@aseproject.com"}, 
                        new Instructor {Name = "Marietta J Byerline",InstructorEmail ="marietta@aseproject.com" }, 
                        new Instructor {Name = "Ronnie R Rollins",InstructorEmail = "ronnierollins@aseproject.com"}, 
                        new Instructor {Name = "Kyle W Palmer",InstructorEmail = "kylepalmer@aseproject.com"}, 
                        new Instructor {Name = "Susan Stevenson",InstructorEmail = "susan@aseproject.com"}, 
                        new Instructor {Name = "Justin D Shaw",InstructorEmail = "justinshaw@aseproject.com"}, 
                        new Instructor {Name = "David C Babcock",InstructorEmail = "davidbabcock@aseproject.com"}, 
                    };
                    instructors=new Dictionary<string, Instructor>();
                    foreach (var i in instructorList)
                    {
                        instructors.Add(i.Name,i);
                    }
                }
                return instructors;
            }
        }

    }
}
