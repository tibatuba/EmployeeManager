using Final2_TibaAljaqobi.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final2_TibaAljaqobi.Services
{
    public class EmployeeRespository : IEmployeeServices
    {
        private readonly EmployeeDbContext _employeeDbContext;
        public EmployeeRespository(EmployeeDbContext employeeDbContext)
        {
            _employeeDbContext = employeeDbContext;
        }
        public Employee AddEmployee(Employee employee)
        {
            _employeeDbContext.Employee.Add(employee);
            _employeeDbContext.SaveChanges();
            return employee;

        }
        public string DeleteEmployee(int id)
        {
            _employeeDbContext.Employee.Remove(GetEmployee(id));
            _employeeDbContext.SaveChanges() ;
            return "Employee Removed.";
        }
        public Employee GetEmployee(int id)
        {
            return _employeeDbContext.Employee.FirstOrDefault(s => s.Id == id); 
        }
        public List<Employee> GetEmployees()
        {
            return _employeeDbContext.Employee.Include("Department").ToList();
        }
        public Employee UpdateEmployee(Employee updatedEmployee)
        {
            _employeeDbContext.Employee.Update(updatedEmployee);
            _employeeDbContext.SaveChanges ();
            return updatedEmployee;
        }
    }
}
