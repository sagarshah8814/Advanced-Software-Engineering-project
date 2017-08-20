using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvSoftwareEngineeringProject.Models
{
    //Mock repository class for testing
    public class MockDepartmentRepository : IDepartmentRepository
    {
        public IEnumerable<Department> Departments
        {
            get
            {
                return new List<Department>
                {
                    new Department { DepartmentId=1, Name = "Computer Science"},
                    new Department {DepartmentId = 2,Name = "Music"}
                };
            }
        }

        Department IDepartmentRepository.GetDepartmentById(int departmentId)
        {
            throw new NotImplementedException();
        }
    }
}
