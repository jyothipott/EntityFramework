using APICrudOperations.Model;

namespace APICrudOperations.EmployeeRepo
{
    public interface IEmployeeRepo
    {
        void AddEmployee(Employee emp);
        int DeleteEmployee(int eno);
        int UpdateEmployee(Employee emp);
        Employee GetEmployee(int eno);

    }
}
