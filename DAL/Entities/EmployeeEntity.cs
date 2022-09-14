using DAL.AbstractEntities;
using System.ComponentModel.DataAnnotations;


namespace DAL.Entities
{
    public class EmployeeEntity : BaseEntity
    {
        [StringLength(150)]
        public string? Name { get; set; }

        public PositionEntity? Position { get; set; }

        public DepartmentEntity? Department { get; set; }
    }
}
