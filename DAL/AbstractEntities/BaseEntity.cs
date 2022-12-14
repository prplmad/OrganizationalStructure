using System.ComponentModel.DataAnnotations;

namespace DAL.AbstractEntities
{
    public class BaseEntity : IBaseEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}
