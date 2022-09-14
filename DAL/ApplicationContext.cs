using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace DAL
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }
        public DbSet<DepartmentEntity> Departments { get; set; }
        public DbSet<EmployeeEntity> Employees { get; set; }
        public DbSet<PositionEntity> Positions { get; set; }

    }
}