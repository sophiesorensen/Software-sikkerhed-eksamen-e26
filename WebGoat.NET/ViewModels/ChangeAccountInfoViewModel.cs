using System.ComponentModel.DataAnnotations;

namespace WebGoatCore.ViewModels
{
    public class ChangeAccountInfoViewModel
    {
        [StringLength(50, MinimumLength = 2)]
        [RegularExpression(@"^[a-zA-ZæøåÆØÅ0-9 /'%&.]+$")]
        [Display(Name = "Company Name")]
        public string? CompanyName { get; set; }

        [StringLength(50, MinimumLength = 3)]
        [RegularExpression(@"^[a-zA-ZæøåÆØÅ0-9_]+$")]
        [Display(Name = "Contact Title")]
        public string? ContactTitle { get; set; }

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


        public bool UpdatedSucessfully { get; set; }
    }
}
