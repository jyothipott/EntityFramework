using APICrudOperations.Model;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace APICrudOperations.EmployeeRepo
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly IConfiguration _configuration;

        public EmployeeRepo(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void AddEmployee(Employee emp)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Employee values(@Eno,@Ename,@Salary,@Dept)", con);
            cmd.Parameters.AddWithValue("@Eno", emp.Eno);       
            cmd.Parameters.AddWithValue("@Ename", emp.Ename);
            cmd.Parameters.AddWithValue("@Salary", emp.Salary);
            cmd.Parameters.AddWithValue("@Dept", emp.Dept);
            int result = cmd.ExecuteNonQuery();
            con.Close();
        }

        public int DeleteEmployee(int eno)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from Employee where Eno=@Eno", con);
            cmd.Parameters.AddWithValue("@Eno", eno);
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }

        public int UpdateEmployee(Employee emp)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            con.Open();
            SqlCommand cmd = new SqlCommand("update Employee set Ename=@Ename, Salary=@Salary, Dept=@Dept where Eno=@Eno", con);
            cmd.Parameters.AddWithValue("@Eno", emp.Eno);
            cmd.Parameters.AddWithValue("@Ename", emp.Ename);
            cmd.Parameters.AddWithValue("@Salary", emp.Salary);
            cmd.Parameters.AddWithValue("@Dept", emp.Dept);
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }

        public Employee GetEmployee(int eno)
        {
            Employee emp = new Employee();
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Employee where Eno=@Eno", con);
            cmd.Parameters.AddWithValue("@Eno", eno);
            SqlDataReader reader = cmd.ExecuteReader();
            int result = 0;
            while (reader.HasRows)
            {
                emp.Eno = Convert.ToInt32(reader["Eno"]);
                emp.Ename = reader["Ename"].ToString();
                emp.Salary = Convert.ToDouble(reader["Salary"]);
                emp.Dept = reader["Dept"].ToString();
            }
            con.Close();
            return emp;
        }
    }
}
