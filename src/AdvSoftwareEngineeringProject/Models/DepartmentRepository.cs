using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvSoftwareEngineeringProject.Models
{
    //Repository class for department
    public class DepartmentRepository:IDepartmentRepository
    {
        private readonly AppDbContext _appDbContext;

        public DepartmentRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Department> Departments => _appDbContext.Departments;
        //Gets all department by their Id from database
        public Department GetDepartmentById(int departmentId)
        {
            return _appDbContext.Departments.FirstOrDefault(d => d.DepartmentId == departmentId);
        }
    }
}
