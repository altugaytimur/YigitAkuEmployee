using Microsoft.AspNetCore.Mvc;
using YigitAkuEmployee.Business.Interfaces.Services;

namespace YigitAkuEmployee.MVC.Controllers
{
    public class EmployeeController : Controller
    {
       private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
