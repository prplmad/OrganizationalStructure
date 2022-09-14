using DAL.AbstractEntities;
using System.ComponentModel.DataAnnotations;


namespace DAL.Entities
{
    public class DepartmentEntity : BaseEntity
    {
        [StringLength(150)]
        public string? Name { get; set; }
        public DepartmentEntity? ParrentDepartment { get; set; }
    }
}
