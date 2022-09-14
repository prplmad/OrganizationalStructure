using Microsoft.AspNetCore.Http;
using BL.Abstract;
using ClosedXML.Excel;
using BL.Abstract.AbstractRepository;
using BL.Models;


namespace BL.Services
{
    public class ImportService : IImportService
    {
        private readonly IImportRepository _importRepository;

        public ImportService(IImportRepository importRepository)
        {
            _importRepository = importRepository;
        }

        public async Task<List<Position>> ImportPositionsAsync(IFormFile fileExcel)
        {
            HashSet<string> positionHashSet = new HashSet<string>();
            List<Position> positionList = new List<Position>();

            using (XLWorkbook workBook = new XLWorkbook(fileExcel.OpenReadStream(), XLEventTracking.Disabled))
            {
                foreach (IXLCell cell in workBook.Worksheet(1).Column(3).CellsUsed().Skip(1))
                {
                    bool added = positionHashSet.Add(cell.Value.ToString());
                    if (added)
                    {
                        Position position = new Position { CreatedAt = DateTime.UtcNow, IsDeleted = false, PositionName = cell.Value.ToString() };
                        positionList.Add(position);
                    }
                }
            }
            await Task.Delay(0);
            return positionList;
        }

        public async Task<List<Department>> ImportDepartmentsAsync(IFormFile fileExcel)
        {
            HashSet<string> departmentsHashSet = new HashSet<string>();
            List<Department> departmentsList = new List<Department>();

            using (XLWorkbook workBook = new XLWorkbook(fileExcel.OpenReadStream(), XLEventTracking.Disabled))
            {
                foreach (IXLCell cell in workBook.Worksheet(1).Column(1).CellsUsed().Skip(1))
                {
                    bool added = departmentsHashSet.Add(cell.Value.ToString());
                    if (added)
                    {
                        Department department = new Department { CreatedAt = DateTime.UtcNow, IsDeleted = false, Name = cell.Value.ToString() };
                        departmentsList.Add(department);

                        if (cell.CellRight(1).IsEmpty())
                        {
                            continue;
                        }
                        else
                        {
                            var parrentDepartmentName = cell.CellRight(1).Value.ToString();
                            foreach (var item in departmentsList)
                            {
                                if (parrentDepartmentName == item.Name)
                                {
                                    departmentsList.Last().ParrentDepartment = item;
                                }
                            }
                        }
                    }
                }
            }
            await Task.Delay(0);
            return departmentsList;
        }

        public async Task ImportExcelFileAsync(IFormFile fileExcel)
        {
            List<Position> positionsList = await ImportPositionsAsync(fileExcel);
            List<Department> departmentsList = await ImportDepartmentsAsync(fileExcel);

            await _importRepository.ImportExcelFileAsync(departmentsList, positionsList, fileExcel);

        }
    }
}