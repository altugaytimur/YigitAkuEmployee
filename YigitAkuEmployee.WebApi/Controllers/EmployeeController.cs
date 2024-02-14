using Microsoft.AspNetCore.Mvc;
using YigitAkuEmployee.Business.Interfaces.Services;
using YigitAkuEmployee.Dtos.EmployeeCrudDtos;

namespace YigitAkuEmployee.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _employeeService.GetAllAsync();
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var result = await _employeeService.GetByIdAsync(id);
            if (!result.IsSuccess)
            {
                return NotFound(result.Message);
            }

            return Ok(result.Data);
        }
        [HttpPost("createemployee")]
        public async Task<IActionResult> CreateEmployee([FromForm] EmployeeCreateDto employeeCreateDto, [FromForm] IFormFile document)
        {
            if (document != null)
            {
                var uploadsFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "documents");
                if (!Directory.Exists(uploadsFolderPath))
                {
                    Directory.CreateDirectory(uploadsFolderPath);
                }

                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(document.FileName);
                var filePath = Path.Combine(uploadsFolderPath, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await document.CopyToAsync(stream);
                }

                employeeCreateDto.Image = $"/documents/{fileName}";
            }


            var result = await _employeeService.AddAsync(employeeCreateDto);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return CreatedAtAction(nameof(GetByIdAsync), new { id = result.Data.Id }, result.Data);

        }
        [HttpPut("{id}")]

        public async Task<IActionResult> Update(Guid id, [FromForm] EmployeeUpdateDto employeeUpdateDto, IFormFile document)
        {
            if (id != employeeUpdateDto.Id)
            {
                return BadRequest("ID mismatch");
            }

            if (document != null)
            {

            }

            var result = await _employeeService.UpdateAsync(employeeUpdateDto);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _employeeService.DeleteAsync(id);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }


    }
}
