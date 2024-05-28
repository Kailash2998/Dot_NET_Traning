using JWT_Authentication_Authorization.Models;

namespace JWT_Authentication_Authorization.Interfaces
{
    public interface IEmployeeService
    {
        public List<Employee> GetEmployeeList();
        public Employee AddEmployee(Employee employee);
    }
}
