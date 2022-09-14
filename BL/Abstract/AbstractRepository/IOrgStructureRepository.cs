using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Abstract.AbstractRepository
{
    public interface IOrgStructureRepository
    {
        Task<IReadOnlyCollection<string>> GetChildDepartmentsByParrentAsync(string parrentDepartment);

        Task<IReadOnlyCollection<int>> GetEmployeesAndPositionsCount(string departmentName);
    }
}
