using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YigitAkuEmployee.Core.Entities.Base;

namespace YigitAkuEmployee.Entities.DbSets
{
    public class Employee:AuditableEntity
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";
        public string Email { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public string Department { get; set; }
        public string? Image { get; set; }
        public string? PhoneNumber { get; set; }
       
    }
}
