using BL.Abstract;
using BL.Abstract.AbstractRepository;

namespace BL.Services
{
    public class OrgStructureService : IOrgStructureService
    {
        private readonly IOrgStructureRepository _repository;
        public OrgStructureService(IOrgStructureRepository repository)
        { 
            _repository = repository;
        }
        public async Task<IReadOnlyCollection<string>> GetChildDepartmentsByParrentAsync(string parrentDepartmentName)
        {
            var departments = await _repository.GetChildDepartmentsByParrentAsync(parrentDepartmentName);
            return departments;
        }

        public async Task<IReadOnlyCollection<int>> GetEmployeesAndPositionsCount(string departmentName)
        {
            var countCollection = await _repository.GetEmployeesAndPositionsCount(departmentName);
            return countCollection;
        }
    }
}
