using BL.Abstract.AbstractRepository;

namespace DAL.Repository
{
    public class OrgStructureRepository : IOrgStructureRepository
    {
        private readonly ApplicationContext _db;

        public OrgStructureRepository(ApplicationContext db)
        {
            _db = db;
        }
        public async Task<IReadOnlyCollection<string>> GetChildDepartmentsByParrentAsync(string parrentDepartment)
        {
            var departments = (from department in _db.Departments
                         where department.ParrentDepartment.Name == parrentDepartment
                         where department.IsDeleted != true
                         select department.Name).ToList();
            return departments;
        }

        public async Task<IReadOnlyCollection<int>> GetEmployeesAndPositionsCount(string departmentName)
        {
            List<int> countCollection = new List<int>();

            int employeesCount = (from employee in _db.Employees
                                  where employee.Department.Name == departmentName
                                  where employee.IsDeleted != true
                                  select employee.Id).Count();

            int positionsCount = (from employee in _db.Employees
                                  where employee.Department.Name == departmentName
                                  where employee.IsDeleted != true
                                  select employee.Position).Distinct().Count();
            countCollection.Add(positionsCount);
            countCollection.Add(employeesCount);

            return countCollection;
        }
    }
}
