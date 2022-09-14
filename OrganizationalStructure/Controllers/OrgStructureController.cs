using Microsoft.AspNetCore.Mvc;
using BL.Abstract;

namespace OrganizationalStructure.Controllers
{
    public class OrgStructureController : Controller
    {
        private readonly IOrgStructureService _orgStructureService;

        public OrgStructureController(IOrgStructureService orgStructureService)
        {
            _orgStructureService = orgStructureService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string parrentDepartmentName)
        {
            var departments = await _orgStructureService.GetChildDepartmentsByParrentAsync(parrentDepartmentName);
            ViewBag.Parrent = parrentDepartmentName;
            return View(departments);
        }

        [HttpPost]
        public async Task<IActionResult> GetPositionsAndEmployeeCount(string departmentName)
        {
            var countCollection = await _orgStructureService.GetEmployeesAndPositionsCount(departmentName);
            return View(countCollection);
        }
    }
}
