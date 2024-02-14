using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YigitAkuEmployee.Business.Constants;
using YigitAkuEmployee.Business.Interfaces.Services;
using YigitAkuEmployee.Core.Utilities.Results.Concrete;
using YigitAkuEmployee.Core.Utilities.Results.Interfaces;
using YigitAkuEmployee.Dal.İnt.Repostories;
using YigitAkuEmployee.Dtos.EmployeeCrudDtos;
using YigitAkuEmployee.Entities.DbSets;

namespace YigitAkuEmployee.Business.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper)
        {
           _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<IDataResult<EmployeeCreateDto>> AddAsync(EmployeeCreateDto employeeCreateDto)
        {
            var hasEmployee = await _employeeRepository.AnyAsync(e => e.Email == employeeCreateDto.Email);
            if (hasEmployee)
                return new ErrorDataResult<EmployeeCreateDto>(Messages.EmployeeAlreadyExist);
            var employee = _mapper.Map<Employee>(employeeCreateDto);
            await _employeeRepository.AddAsync(employee);
            await _employeeRepository.SaveChangesAsync();
            return new SuccessDataResult<EmployeeCreateDto>(employeeCreateDto, Messages.EmployeeSuccess);
        }

        public async Task<IResult> DeleteAsync(Guid id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);
            if (employee == null)
                return new ErrorResult(Messages.EmployeeNotFound);
            await _employeeRepository.DeleteAsync(employee);
            await _employeeRepository.SaveChangesAsync();
            return new SuccessResult(Messages.EmployeeDeleted);
        }

        public async Task<IDataResult<List<EmployeeListDto>>> GetAllAsync()
        {
            var employees = await _employeeRepository.GetAllAsync();
            var employeeDtos = _mapper.Map<List<EmployeeListDto>>(employees);
            return new SuccessDataResult<List<EmployeeListDto>>(employeeDtos, Messages.EmployeeFoundSuccess);
        }

        public async Task<IDataResult<EmployeeListDto>> GetByIdAsync(Guid id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);

            if (employee is null)
                return new ErrorDataResult<EmployeeListDto>(Messages.EmployeeNotFound);
            return new SuccessDataResult<EmployeeListDto>(_mapper.Map<EmployeeListDto>(employee), Messages.EmployeeFoundSuccess); ;
        }

        /// <summary>
        /// Parametre olarak girilen ad, soyad veya mail adresine göre Çalışan listesindeki Çalışanları filtreleyen metot.
        /// </summary>
        /// <param name="name">Çalışan adına karşılık gelen değişken</param>
        /// <param name="surname">Çalışan soyadına karşılık gelen değişken</param>
        /// <param name="mailAdress">Çalışan mail adresine karşılık gelen değişken</param>
        /// <returns></returns>
        public async Task<IDataResult<List<EmployeeListDto>>> GetEmployeesByNameOrSurnameOrMailAdressAsync(string? name, string? surname, string? mailAdress)
        {
            var employeesByName = await _employeeRepository.GetAllAsync(x => x.FirstName.Contains(name));
            var employeesBySurname = await _employeeRepository.GetAllAsync(x => x.LastName.Contains(surname));
            var employeesByMailAdress = await _employeeRepository.GetAllAsync(x => x.Email.Contains(mailAdress));

            var filteredEmployeess = IntersectNonEmpty(employeesByName, employeesBySurname, employeesByMailAdress);

            return filteredEmployeess.Any()
                ? new SuccessDataResult<List<EmployeeListDto>>(_mapper.Map<List<EmployeeListDto>>(filteredEmployeess), Messages.ListedSuccess)
                : new ErrorDataResult<List<EmployeeListDto>>(Messages.EmployeeNotFound);
        }

        public async Task<IDataResult<EmployeeUpdateDto>> UpdateAsync(EmployeeUpdateDto employeeUpdateDto)
        {
            var employee = await _employeeRepository.GetByIdAsync(employeeUpdateDto.Id);
            if (employee == null)
                return new ErrorDataResult<EmployeeUpdateDto>(Messages.EmployeeNotFound);

            _mapper.Map(employeeUpdateDto, employee);
            await _employeeRepository.UpdateAsync(employee);
            await _employeeRepository.SaveChangesAsync();
            return new SuccessDataResult<EmployeeUpdateDto>(employeeUpdateDto, Messages.EmployeeUpdated);
        }

        /// <summary>
        /// Parametre olarak girilen listelerin içindeki ortak elemanlarını, listeler boşsa boş liste döndürür.
        /// </summary>
        /// <typeparam name="T">Listenin tipine karşılık gelen parametre</typeparam>
        /// <param name="lists">Listelere karşılık gelen parametre</param>
        /// <returns></returns>
        private static IEnumerable<T> IntersectNonEmpty<T>(params IEnumerable<T>[] lists)
        {
            var nonEmptyLists = lists.Where(list => list != null && list.Any()).ToList();

            if (nonEmptyLists.Count == 0)
            {
                return new List<T>();
            }

            IEnumerable<T> result = nonEmptyLists[0];

            for (int i = 1; i < nonEmptyLists.Count; i++)
            {
                result = result.Intersect(nonEmptyLists[i]).ToList();

                if (!result.Any())
                {
                    break;
                }
            }

            return result;
        }
    }
}
