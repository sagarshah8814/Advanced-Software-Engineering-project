using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvSoftwareEngineeringProject.Models
{
    //Interface class for department repository
    public interface IDepartmentRepository
    {
        IEnumerable<Department> Departments { get; }
        Department GetDepartmentById(int departmentId);
    }
}
