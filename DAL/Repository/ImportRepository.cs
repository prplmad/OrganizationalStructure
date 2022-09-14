using BL.Abstract.AbstractRepository;
using Microsoft.AspNetCore.Http;
using BL.Models;
using DAL.Mappers;
using DAL.Entities;
using ClosedXML.Excel;

namespace DAL.Repository
{
    public class ImportRepository : IImportRepository
    {
        private readonly ApplicationContext _db;
        public ImportRepository(ApplicationContext db)
        {
            _db = db;
        }

        public async Task ImportExcelFileAsync(List<Department> departmentsList, List<Position> positionsList, IFormFile fileExcel)
        {
            List<EmployeeEntity> employeesList = new List<EmployeeEntity>();
            List<DepartmentEntity> departmentEntities = new List<DepartmentEntity>();
            List<PositionEntity> positionEntities = new List<PositionEntity>();

            foreach (var departmentBL in departmentsList)
            {
                departmentEntities.Add(departmentBL.FromBusinessToEntities());

                if (departmentBL.ParrentDepartment is null)
                {
                    continue;
                }
                else
                {
                    var parrentDepartmentName = departmentBL.ParrentDepartment.Name;
                    foreach (var departmentDAL in departmentEntities)
                    {
                        if (parrentDepartmentName == departmentDAL.Name)
                        {
                            departmentEntities.Last().ParrentDepartment = departmentDAL;
                        }
                    }
                }
            }

            foreach (var position in positionsList)
            {
                positionEntities.Add(position.FromBusinessToEntities());
            }


            using (XLWorkbook workBook = new XLWorkbook(fileExcel.OpenReadStream(), XLEventTracking.Disabled))
            {
                foreach (IXLCell cell in workBook.Worksheet(1).Column(4).CellsUsed().Skip(1))
                {
                    EmployeeEntity employee = new EmployeeEntity();
                    employee.Name = cell.Value.ToString();
                    employee.IsDeleted = false;
                    employee.CreatedAt = DateTime.UtcNow;

                    foreach (var department in departmentEntities)
                    {
                        if (department.Name == cell.CellLeft(3).Value.ToString())
                        {
                            employee.Department = department;
                        }
                    }

                    foreach (var position in positionEntities)
                    {
                        if (position.PositionName == cell.CellLeft(1).Value.ToString())
                        {
                            employee.Position = position;
                        }
                    }
                    employeesList.Add(employee);
                }
            }
            foreach (var employeeEntity in employeesList)
            {
                await _db.AddAsync(employeeEntity);
            }
            await _db.SaveChangesAsync();
        }
    }
}
