namespace BL.Models
{
    public class Department
    {
        public string Name { get; set; }
        public Department? ParrentDepartment { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}
