using APICrudOperations.EmployeeService;
using APICrudOperations.Model;
using Microsoft.AspNetCore.Mvc;

namespace APICrudOperations.Controllers
{
    public class EmployeeController : Controller
    {
        IEmployeeService _empService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _empService = employeeService;
        }
        public IActionResult Employee()
        {
            return View("Employee");
        }
        public IActionResult AddEmployee(Employee emp)
        {
            _empService.AddEmployee(emp);
            return View();
        }
        public IActionResult UpdateEmployee(Employee emp)
        {
            _empService.UpdateEmployee(emp);
            return View();
        }
        public IActionResult DeleteEmployee(int eno)
        {
            _empService.DeleteEmployee(eno);
            return View();
        }
        public IActionResult GetEmployee(int eno)
        {
            _empService.GetEmployee(eno);
            return View();
        }
    }
}
