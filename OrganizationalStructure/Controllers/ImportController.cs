using Microsoft.AspNetCore.Mvc;
using OrganizationalStructure.Models;
using System.Diagnostics;
using BL.Abstract;


namespace OrganizationalStructure.Controllers
{
    public class ImportController : Controller
    {
        private readonly IImportService _importService;

        public ImportController(IImportService importService)
        {
            _importService = importService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Import(IFormFile fileExcel)
        {
            if (ModelState.IsValid)
            {
                await _importService.ImportExcelFileAsync(fileExcel);
            }
            return RedirectToAction("Index");
        }
    }
}