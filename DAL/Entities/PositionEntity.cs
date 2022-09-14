using DAL.AbstractEntities;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class PositionEntity : BaseEntity
    {
        [StringLength(150)]
        public string? PositionName { get; set; }
    }
}
