using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YigitAkuEmployee.Core.Utilities.Results.Interfaces;
using YigitAkuEmployee.Dtos.EmployeeCrudDtos;

namespace YigitAkuEmployee.Business.Interfaces.Services
{
    public interface IEmployeeService
    {
        Task<IDataResult<EmployeeListDto>> GetByIdAsync(Guid id);
        Task<IDataResult<List<EmployeeListDto>>> GetAllAsync();
        Task<IDataResult<EmployeeCreateDto>> AddAsync(EmployeeCreateDto employeeCreateDto);
        Task<IDataResult<EmployeeUpdateDto>> UpdateAsync(EmployeeUpdateDto employeeUpdateDto);
        Task<IResult> DeleteAsync(Guid id);
        Task<IDataResult<List<EmployeeListDto>>> GetEmployeesByNameOrSurnameOrMailAdressAsync(string? name, string? surname, string? mailAdress);
    }
}
