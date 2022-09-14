using BL.Models;

namespace BL.Abstract
{
    public interface IOrgStructureService
    {
        Task<IReadOnlyCollection<string>> GetChildDepartmentsByParrentAsync(string parrentDepartmentName);
        Task<IReadOnlyCollection<int>> GetEmployeesAndPositionsCount(string departmentName);
    }
}
