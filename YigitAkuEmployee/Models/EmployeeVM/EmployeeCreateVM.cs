using System.ComponentModel.DataAnnotations;

namespace YigitAkuEmployee.MVC.Models.EmployeeVM
{
    public class EmployeeCreateVM
    {
      

        [Display(Name = "İsim")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz.")]
        public string FirstName { get; set; } = null!;

        [Display(Name = "Soyisim")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz.")]
        public string LastName { get; set; } = null!;

        [Display(Name = "Email")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz.")]
        public string Email { get; set; } = null!;

        [Display(Name = "Doğum Tarihi")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz.")]
        [DataType(DataType.Date, ErrorMessage = "Lütfen geçerli bir tarih giriniz.")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Departman")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz.")]
        public string Department { get; set; }

        [Display(Name = "Fotoğraf")]
        [DataType(DataType.Upload, ErrorMessage = "Lütfen geçerli bir dosya yükleyiniz.")]
        public IFormFile? Image { get; set; }
        [Display(Name = "Tel No")]
        public string? PhoneNumber { get; set; }
    }
}
