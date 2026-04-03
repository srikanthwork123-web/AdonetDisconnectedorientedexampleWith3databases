using AdonetDisconnectedorientedexampleWith3databases.Dto;

namespace AdonetDisconnectedorientedexampleWith3databases.Interfaces
{
    public interface IDepartmentService
    {
        Task<List<DepartmentDto>> GetAllDepartments();
        Task<DepartmentDto> GetDepartmentById(int DepartmentId);
        //Task<DepartmentDto> GetDepartmentByName(string DepartmentName);
        Task<bool> AddDepartment(DepartmentDto Dept);
        Task<bool> UpdateDepartment(DepartmentDto Dept);
        Task<bool> DeleteDepartment(int DepartmentId);
    }
}
