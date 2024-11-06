using Final2_TibaAljaqobi.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Final2_TibaAljaqobi.Services
{
    public class DepartmentRepository : IDepartmentServices
    {
        private readonly EmployeeDbContext _employeeDbContext;

        public DepartmentRepository(EmployeeDbContext employeeDbContext)
        {
            _employeeDbContext = employeeDbContext;
        }

        public IEnumerable<Department> ListDepartment()
        {
            return _employeeDbContext.Department.ToList(); // Execute query immediately
        }
    }
}
