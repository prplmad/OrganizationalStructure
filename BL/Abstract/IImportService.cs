using Microsoft.AspNetCore.Http;
using BL.Models;


namespace BL.Abstract
{
    public interface IImportService
    {
        Task<List<Position>> ImportPositionsAsync(IFormFile fileExcel);

        Task<List<Department>> ImportDepartmentsAsync(IFormFile fileExcel);

        Task ImportExcelFileAsync(IFormFile fileExcel);
    }
}
