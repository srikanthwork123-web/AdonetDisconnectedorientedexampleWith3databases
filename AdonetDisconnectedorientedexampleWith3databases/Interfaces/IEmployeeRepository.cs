using AdonetDisconnectedorientedexampleWith3databases.Models;

namespace AdonetDisconnectedorientedexampleWith3databases.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetEmployees();
        Task<Employee> GetEmployeeById(int empid);
        Task<int> AddEmployes(Employee empdetail);
        Task<bool> DeleteEmployesById(int empid);
        Task<bool> UpdateEmploye(Employee empdetail);
    }
}
