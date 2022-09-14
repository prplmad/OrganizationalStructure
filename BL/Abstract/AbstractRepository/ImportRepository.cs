using BL.Models;
using Microsoft.AspNetCore.Http;

namespace BL.Abstract.AbstractRepository
{
    public interface IImportRepository
    {
        Task ImportExcelFileAsync(List<Department> departmentsList, List<Position> positionsList, IFormFile fileExcel);
    }
}
