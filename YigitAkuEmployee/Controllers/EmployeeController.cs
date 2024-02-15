using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using YigitAkuEmployee.Business.Interfaces.Services;
using YigitAkuEmployee.Dtos.EmployeeCrudDtos;
using YigitAkuEmployee.MVC.Extensions;
using YigitAkuEmployee.MVC.Models.EmployeeVM;

namespace YigitAkuEmployee.MVC.Controllers
{
    public class EmployeeController : Controller
    {
       private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;
       

        public EmployeeController(IEmployeeService employeeService, IMapper  mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model =  await _employeeService.GetAllAsync();
            var list = model.Data;
            return View(list);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm]EmployeeCreateVM employeeCreateVM, IFormCollection collection)
        {
            if (ModelState.IsValid)
            {
                var employeeCreateDto = _mapper.Map<EmployeeCreateDto>(employeeCreateVM);
                if (employeeCreateVM.Image != null)
                {
                    employeeCreateDto.Image = await employeeCreateVM.Image.FileToStringAsync();
                }
                var addEmployeeResult = await _employeeService.AddAsync(employeeCreateDto);
                if (addEmployeeResult.IsSuccess)
                    return RedirectToAction("Index");
                else
                    return PartialView(employeeCreateVM);
            }
            return PartialView(employeeCreateVM);

        }

        public async Task<IActionResult> Delete([FromRoute(Name = "id")] Guid id)
        {
            await _employeeService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var getEmployeeResult = await _employeeService.GetByIdAsync(id);
            if (!getEmployeeResult.IsSuccess)
                return RedirectToAction("Index");
            var employeeDto = getEmployeeResult.Data;
            var employeeUpdateVM = _mapper.Map<EmployeeUpdateVM>(employeeDto);
            return View(employeeUpdateVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Update ([FromForm]EmployeeUpdateVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var updateEmployee = _mapper.Map<EmployeeUpdateDto>(model);
            if (model.Image != null)
            {
                updateEmployee.Image = await model.Image.FileToStringAsync();
            }
            var updateEmployeeResult = await _employeeService.UpdateAsync(updateEmployee);
            if (updateEmployeeResult.IsSuccess)
                return RedirectToAction("Index");
            else
                return View(model);
        }
    }
}
