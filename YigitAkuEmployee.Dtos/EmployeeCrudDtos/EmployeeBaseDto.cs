using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YigitAkuEmployee.Dtos.EmployeeCrudDtos
{
    public class EmployeeBaseDto
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string FullName => $"{FirstName} {LastName}";
        public string Email { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public string Department { get; set; }
        public string? Image { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
