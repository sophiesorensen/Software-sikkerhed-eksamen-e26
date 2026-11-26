using System.ComponentModel.DataAnnotations;

#pragma warning disable CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
namespace WebGoatCore.ViewModels
{
    public class RegisterViewModel
    {
        [StringLength(50, MinimumLength = 3)]
        [RegularExpression(@"^[a-zA-ZæøåÆØÅ0-9_]+$")]
        [Display(Name = "User Name")]
        [Required(ErrorMessage = "Please enter your user name")]
        public string Username { get; set; }

        [StringLength(254, MinimumLength = 5)]
        [EmailAddress]
        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "Please enter your company email")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }

        [StringLength(50, MinimumLength = 2)]
        [RegularExpression(@"^[a-zA-ZæøåÆØÅ0-9 /'%&.]+$")]
        [Display(Name = "Company Name")]
        [Required(ErrorMessage = "Please enter your company name")]
        public string CompanyName { get; set; }

        [StringLength(128, MinimumLength = 8)]
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please enter your password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = "Please confirm your password")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "The password and confirmation password do not match")]
        public string ConfirmedPassword { get; set; }

        [StringLength(50, MinimumLength = 2)]
        [RegularExpression(@"^[a-zA-ZæøåÆØÅ0-9 .,/-]+$")]
        [Display(Name = "Address")]
        public string? Address { get; set; }

        [StringLength(50, MinimumLength = 2)]
        [RegularExpression(@"^[a-zA-ZæøåÆØÅ '-]+$")]
        [Display(Name = "City")]
        public string? City { get; set; }

        [StringLength(50, MinimumLength = 2)]
        [RegularExpression(@"^[a-zA-ZæøåÆØÅ '-]+$")]
        [Display(Name = "Region/State")]
        public string? Region { get; set; }

        [StringLength(4, MinimumLength = 4)]
        [RegularExpression(@"^[0-9]+$")]
        [Display(Name = "Postal Code")]
        [DataType(DataType.PostalCode)]
        public string? PostalCode { get; set; }

        [StringLength(50, MinimumLength = 2)]
        [RegularExpression(@"^[a-zA-ZæøåÆØÅ '-]+$")]
        [Display(Name = "Country")]
        public string? Country { get; set; }
    }
}
