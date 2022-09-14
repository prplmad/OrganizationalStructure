

namespace DAL.Mappers
{
    public static class DepartmentMapper
    {
        public static DAL.Entities.DepartmentEntity FromBusinessToEntities(this BL.Models.Department department)
        {
            return new DAL.Entities.DepartmentEntity
            {
                CreatedAt = department.CreatedAt,
                IsDeleted = department.IsDeleted,
                Name = department.Name
            };
            return new DAL.Entities.DepartmentEntity
            {
                CreatedAt = department.CreatedAt,
                IsDeleted = department.IsDeleted,
                Name = department.Name
            };
        }
    }
}
