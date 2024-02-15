using AutoMapper;
using YigitAkuEmployee.Dtos.EmployeeCrudDtos;
using YigitAkuEmployee.Entities.DbSets;
using YigitAkuEmployee.MVC.Models.EmployeeVM;

namespace YigitAkuEmployee.MVC.Profiles
{
    public class EmployeeVmProfile:Profile
    {
        public EmployeeVmProfile()
        {
            CreateMap<EmployeeListDto, EmployeListVM>();
            CreateMap<EmployeeCreateVM, EmployeeCreateDto>();
            CreateMap<EmployeeUpdateVM, EmployeeUpdateDto>();
            CreateMap<EmployeeListDto, EmployeeUpdateVM>();
        }
    }
}
