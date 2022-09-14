namespace BL.Models
{
    public class Employee
    {
        public string Name { get; set; }
        public Department Department { get; set; }
        public Position Position { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}
