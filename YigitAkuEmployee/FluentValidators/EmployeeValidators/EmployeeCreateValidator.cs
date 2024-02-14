using FluentValidation;
using YigitAkuEmployee.MVC.FluentValidators.CustomValidators;
using YigitAkuEmployee.MVC.Models.EmployeeVM;

namespace YigitAkuEmployee.MVC.FluentValidators.EmployeeValidators
{
    public class EmployeeCreateValidator:AbstractValidator<EmployeeCreateVM>
    {
        public EmployeeCreateValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Bu alan boş bırakılamaz.")
                           .MinimumLength(2).WithMessage("Personel adı en az 2 karakterden oluşmalıdır.")
                           .Matches(@"^(?!'+$)[a-zA-Z'ğüşöçıİĞÜŞÖÇ]+(?:\s+[a-zA-Z'ğüşöçıİĞÜŞÖÇ]+)*$").WithMessage("İsim özel karakter ya da sayı içeremez")
                           .MaximumLength(256).WithMessage("Personel adı en fazla 256 karakterden oluşmalıdır.");

            RuleFor(x => x.LastName).NotEmpty().WithMessage("Bu alan boş bırakılamaz.")
                                .MinimumLength(2).WithMessage("Personel soyadı en az 2 karakterden oluşmalıdır.")
                                .Matches(@"^(?!'+$)[a-zA-Z'ğüşöçıİĞÜŞÖÇ]+(?:\s+[a-zA-Z'ğüşöçıİĞÜŞÖÇ]+)*$").WithMessage("Soyad özel karakter ya da sayı içeremez")
                                .MaximumLength(256).WithMessage("Personel soyadı en fazla 256 karakterden oluşmalıdır.");

            RuleFor(x => x.Email).NotEmpty().WithMessage("Bu alan boş bırakılamaz.")
                                .EmailAddress().WithMessage("Lütfen geçerli bir mail adresi giriniz.");

            RuleFor(x => x.DateOfBirth).NotEmpty().WithMessage("Bu alan boş bırakılamaz.")
            .LessThan(x => DateTime.Today.AddYears(-18))
            .WithMessage("Personel 18 yaşından büyük olmalıdır.");

            RuleFor(x => x.Image).SetValidator(new ProfileImageValidator()).When(model => model.Image != null);
        }
    }
}
