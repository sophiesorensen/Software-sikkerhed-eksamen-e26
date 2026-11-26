using System.ComponentModel.DataAnnotations;//Giver adgang til valideringsfunktioner
using WebGoatCore.ViewModels;//Giver adgang til RegisterViewModel-klassen

namespace WebGoat.NET.Tests;

public class RegisterViewModelTests
{
    [Fact]//Fortæller testframeworket, at dette er en testmetode
    public void Username_TooShort_FailsValidation()//Tester om brugernavnet er for kort
    {
        // Arrange
        var model = CreateValidModel();
        model.Username = "ab";//Tester et brugernavn, der er for kort (mindre end 3 tegn)

        // Act
        var context = new ValidationContext(model);
        var results = new List<ValidationResult>();

        var isValid = Validator.TryValidateObject(
            model,
            context,
            results,
            validateAllProperties: true);

        // Assert
        Assert.False(isValid);
        Assert.Contains(results, r =>
            r.MemberNames.Contains(nameof(RegisterViewModel.Username)));
    }

    [Fact]
    public void Username_InvalidCharacters_FailsValidation()//Tester om brugernavnet indeholder ugyldige tegn
    {
        // Arrange
        var model = CreateValidModel();
        model.Username = "test user!";//Tester et brugernavn, der indeholder ugyldige tegn (mellemrum og udråbstegn)

        // Act
        var context = new ValidationContext(model);
        var results = new List<ValidationResult>();

        var isValid = Validator.TryValidateObject(
            model,
            context,
            results,
            validateAllProperties: true);

        // Assert
        Assert.False(isValid);
        Assert.Contains(results, r =>
            r.MemberNames.Contains(nameof(RegisterViewModel.Username)));
    }

    [Fact]
    public void Email_InvalidFormat_FailsValidation()//Tester om e-mailen har et ugyldigt format
    {
        // Arrange
        var model = CreateValidModel();
        model.Email = "invalid-email";//Tester en e-mail, der ikke har et gyldigt format

        // Act
        var context = new ValidationContext(model);
        var results = new List<ValidationResult>();

        var isValid = Validator.TryValidateObject(
            model,
            context,
            results,
            validateAllProperties: true);

        // Assert
        Assert.False(isValid);
        Assert.Contains(results, r =>
            r.MemberNames.Contains(nameof(RegisterViewModel.Email)));
    }

    [Fact]
    public void Password_TooShort_FailsValidation()//Tester om adgangskoden er for kort
    {
        // Arrange
        var model = CreateValidModel();
        model.Password = "short";//Tester en adgangskode, der er for kort (mindre end 8 tegn)
        model.ConfirmedPassword = "short";

        // Act
        var context = new ValidationContext(model);
        var results = new List<ValidationResult>();

        var isValid = Validator.TryValidateObject(
            model,
            context,
            results,
            validateAllProperties: true);

        // Assert
        Assert.False(isValid);
        Assert.Contains(results, r =>
            r.MemberNames.Contains(nameof(RegisterViewModel.Password)));
    }

    [Fact]
    public void ConfirmedPassword_DoesNotMatchPassword_FailsValidation()//Tester om bekræftelsesadgangskoden ikke matcher adgangskoden
    {
        // Arrange
        var model = CreateValidModel();
        model.Password = "Password123!";
        model.ConfirmedPassword = "DifferentPassword123!";

        // Act
        var context = new ValidationContext(model);
        var results = new List<ValidationResult>();

        var isValid = Validator.TryValidateObject(
            model,
            context,
            results,
            validateAllProperties: true);

        // Assert
        Assert.False(isValid);
        Assert.Contains(results, r =>
            r.MemberNames.Contains(nameof(RegisterViewModel.ConfirmedPassword)));
    }

    // Opretter en model med gyldige standardværdier
    private static RegisterViewModel CreateValidModel()
    {
        return new RegisterViewModel
        {
            Username = "testuser",
            Email = "test@company.com",
            CompanyName = "Test Company",
            Password = "Password123!",
            ConfirmedPassword = "Password123!"
        };
    }
}


