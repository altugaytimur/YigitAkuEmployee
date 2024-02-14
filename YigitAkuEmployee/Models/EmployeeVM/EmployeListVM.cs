using System.ComponentModel.DataAnnotations;

namespace YigitAkuEmployee.MVC.Models.EmployeeVM
{
    public class EmployeListVM
    {
        public Guid Id { get; set; }

        [Display(Name = "İsim")]
        public string FirstName { get; set; } = null!;

        [Display(Name = "Soyisim")]
        public string LastName { get; set; } = null!;
        [Display(Name = "İsim Soyisim")]
        public string FullName => $"{FirstName} {LastName}";
        public string Email { get; set; } = null!;

        [Display(Name = "Doğum Tarihi")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Departman")]
        public string Department { get; set; }
        [Display(Name = "Fotoğraf")]
        public string? Image { get; set; }
        [Display(Name = "Tel No")]
        public string? PhoneNumber { get; set; }
    }
}
