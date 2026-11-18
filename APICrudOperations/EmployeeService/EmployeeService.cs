using APICrudOperations.EmployeeRepo;
using APICrudOperations.Model;

namespace APICrudOperations.EmployeeService
{
    public class EmployeeService:IEmployeeService
    {
        private readonly IEmployeeRepo _employeeRepo;

        public EmployeeService(IEmployeeRepo employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }

        public void AddEmployee(Employee emp)
        {
             _employeeRepo.AddEmployee(emp);
        }
        public int DeleteEmployee(int eno)
        {
            return _employeeRepo.DeleteEmployee(eno);
        }
        public int UpdateEmployee(Employee emp)
        {
            return _employeeRepo.UpdateEmployee(emp);
        }
        public Employee GetEmployee(int eno)
        {
            return _employeeRepo.GetEmployee(eno);
        }   
    }
}
