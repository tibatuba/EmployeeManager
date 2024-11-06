using Final2_TibaAljaqobi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final2_TibaAljaqobi.Services
{
     public interface IEmployeeServices
    {
        List<Employee> GetEmployees(); // Get all employees service
        Employee GetEmployee(int id); // get a single employee
        string DeleteEmployee(int id); // delete an employee service
        Employee AddEmployee(Employee employee); // add an employee
        Employee UpdateEmployee(Employee employee); // update an employee record
    }
}
