using APICrudOperations.Model;

namespace APICrudOperations.EmployeeService
{
    public interface IEmployeeService
    {
        void AddEmployee(Employee emp);
        int DeleteEmployee(int eno);
        int UpdateEmployee(Employee emp);
        Employee GetEmployee(int eno);
    }
}
