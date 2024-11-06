using Final2_TibaAljaqobi.Entities;
using Final2_TibaAljaqobi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Final2_TibaAljaqobi.Operations.Controllers
{
    public class EmployeeController : Controller
    {
        private IEmployeeServices _employeeServices;
        private IDepartmentServices _departmentServices;
        public EmployeeController(IEmployeeServices employeeServices, IDepartmentServices departmentServices)
        {
            _employeeServices = employeeServices;
            _departmentServices = departmentServices;
        }

        public IActionResult ShowEmployee()
        {
            return View(_employeeServices.GetEmployees());
        }

        [HttpGet]
        public IActionResult CreateEmployee()
        {
            List<Department> departments = _departmentServices.ListDepartment().ToList();

            List<SelectListItem> listOfDepartment = new List<SelectListItem>();
            foreach (var department in departments)
            {
                listOfDepartment.Add(new SelectListItem
                {
                    Text = department.DepartmentName,
                    Value = department.DepartmentId.ToString()
                });
            }
            ViewBag.AllDepartments = listOfDepartment;
            return View();
        }

        [HttpPost]
        public IActionResult CreateEmployee(Employee employee)
        {
            _employeeServices.AddEmployee(employee);
            return RedirectToAction("ShowEmployee", "Employee");
        }

        // Edit Employee
        [HttpGet]
        public IActionResult EditEmployee(int id)
        {
            var employee = _employeeServices.GetEmployee(id);
            if (employee == null)
            {
                return NotFound();
            }

            ViewBag.AllDepartments = _departmentServices.ListDepartment()
                .Select(d => new SelectListItem { Text = d.DepartmentName, Value = d.DepartmentId.ToString() })
                .ToList();

            return View(employee);
        }

        [HttpPost]
        public IActionResult EditEmployee(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _employeeServices.UpdateEmployee(employee);
                return RedirectToAction("ShowEmployee");
            }

            ViewBag.AllDepartments = _departmentServices.ListDepartment()
                .Select(d => new SelectListItem { Text = d.DepartmentName, Value = d.DepartmentId.ToString() })
                .ToList();

            return View(employee);
        }

        // Delete Employee
        [HttpGet]
        public IActionResult DeleteEmployee(int id)
        {
            var employee = _employeeServices.GetEmployee(id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        [HttpPost, ActionName("DeleteEmployee")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _employeeServices.DeleteEmployee(id);
            return RedirectToAction("ShowEmployee");
        }

        [HttpGet]
        public IActionResult HighlyPaidEmployees()
        {
            return View();
        }

        [HttpPost]
        public IActionResult HighlyPaidEmployees(double minSalary)
        {
            var employees = _employeeServices.GetEmployees()
                .Where(e => e.Salary > minSalary).ToList();
            return View("ShowHighlyPaidEmployees", employees);
        }

        [HttpGet]
        public IActionResult NewEmployees()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NewEmployees(DateTime joinDate)
        {
            var employees = _employeeServices.GetEmployees()
                .Where(e => e.JoiningDate > joinDate).ToList();
            return View("ShowNewEmployees", employees);
        }
        // EmployeeController.cs

        [HttpGet]
        public IActionResult EmployeeListByDepartment()
        {
            // Populate the dropdown list with departments
            ViewBag.AllDepartments = _departmentServices.ListDepartment()
                .Select(d => new SelectListItem { Text = d.DepartmentName, Value = d.DepartmentId.ToString() })
                .ToList();

            // Return the view with an empty model (no employees to display initially)
            return View();
        }

        [HttpPost]
        public IActionResult EmployeeListByDepartment(int departmentId)
        {
            // Retrieve employees in the selected department
            var employees = _employeeServices.GetEmployees()
                .Where(e => e.DepartmentId == departmentId)
                .Select(e => new { e.Name, e.Salary })
                .ToList();

            // Populate the dropdown list with departments
            ViewBag.AllDepartments = _departmentServices.ListDepartment()
                .Select(d => new SelectListItem { Text = d.DepartmentName, Value = d.DepartmentId.ToString() })
                .ToList();

            // Pass the list of employees to the view
            return View(employees);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
