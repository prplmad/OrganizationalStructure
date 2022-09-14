

namespace DAL.Mappers
{
    public static class EmployeeMapper
    {
        public static DAL.Entities.EmployeeEntity FromBusinessToEntities(this BL.Models.Employee employee)
        {
            return new DAL.Entities.EmployeeEntity
            {
                CreatedAt = employee.CreatedAt,
                IsDeleted = employee.IsDeleted,
                Name = employee.Name,
                Department = employee.Department.FromBusinessToEntities(),
                Position = employee.Position.FromBusinessToEntities()
            };
        }
    }
}
