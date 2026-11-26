
using System.ComponentModel.DataAnnotations; // Giver adgang til valideringsfunktioner
using WebGoatCore.ViewModels; // Giver adgang til ChangeAccountInfoViewModel-klassen

namespace WebGoat.NET.Tests;

public class ChangeAccountInfoViewModelTests
{
    [Fact]
    public void CompanyName_TooShort_FailsValidation() // Tester om firmanavnet er for kort
    {
        // Arrange
        var model = CreateValidModel();
        model.CompanyName = "A"; // Tester et firmanavn med mindre end 2 tegn

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
            r.MemberNames.Contains(nameof(ChangeAccountInfoViewModel.CompanyName)));
    }

    [Fact]
    public void CompanyName_InvalidCharacters_FailsValidation() // Tester om firmanavnet indeholder ugyldige tegn
    {
        // Arrange
        var model = CreateValidModel();
        model.CompanyName = "Test@Company"; // Tester et firmanavn med et ugyldigt tegn

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
            r.MemberNames.Contains(nameof(ChangeAccountInfoViewModel.CompanyName)));
    }

    [Fact]
    public void ContactTitle_TooShort_FailsValidation() // Tester om kontakttitlen er for kort
    {
        // Arrange
        var model = CreateValidModel();
        model.ContactTitle = "AB"; // Tester en kontakttitel med mindre end 3 tegn

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
            r.MemberNames.Contains(nameof(ChangeAccountInfoViewModel.ContactTitle)));
    }

    [Fact]
    public void ContactTitle_InvalidCharacters_FailsValidation() // Tester om kontakttitlen indeholder ugyldige tegn
    {
        // Arrange
        var model = CreateValidModel();
        model.ContactTitle = "Manager!"; // Tester en kontakttitel med et ugyldigt tegn

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
            r.MemberNames.Contains(nameof(ChangeAccountInfoViewModel.ContactTitle)));
    }

    [Fact]
    public void Address_TooShort_FailsValidation() // Tester om adressen er for kort
    {
        // Arrange
        var model = CreateValidModel();
        model.Address = "A"; // Tester en adresse med mindre end 2 tegn

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
            r.MemberNames.Contains(nameof(ChangeAccountInfoViewModel.Address)));
    }

    [Fact]
    public void Address_InvalidCharacters_FailsValidation() // Tester om adressen indeholder ugyldige tegn
    {
        // Arrange
        var model = CreateValidModel();
        model.Address = "Street@12"; // Tester en adresse med et ugyldigt tegn

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
            r.MemberNames.Contains(nameof(ChangeAccountInfoViewModel.Address)));
    }

    [Fact]
    public void City_TooShort_FailsValidation() // Tester om bynavnet er for kort
    {
        // Arrange
        var model = CreateValidModel();
        model.City = "O"; // Tester et bynavn med mindre end 2 tegn

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
            r.MemberNames.Contains(nameof(ChangeAccountInfoViewModel.City)));
    }

    [Fact]
    public void City_InvalidCharacters_FailsValidation() // Tester om bynavnet indeholder ugyldige tegn
    {
        // Arrange
        var model = CreateValidModel();
        model.City = "Odense123"; // Tester et bynavn med tal

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
            r.MemberNames.Contains(nameof(ChangeAccountInfoViewModel.City)));
    }

    [Fact]
    public void Region_TooShort_FailsValidation() // Tester om regionen er for kort
    {
        // Arrange
        var model = CreateValidModel();
        model.Region = "F"; // Tester en region med mindre end 2 tegn

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
            r.MemberNames.Contains(nameof(ChangeAccountInfoViewModel.Region)));
    }

    [Fact]
    public void Region_InvalidCharacters_FailsValidation() // Tester om regionen indeholder ugyldige tegn
    {
        // Arrange
        var model = CreateValidModel();
        model.Region = "Fyn123"; // Tester en region med tal

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
            r.MemberNames.Contains(nameof(ChangeAccountInfoViewModel.Region)));
    }

    [Fact]
    public void PostalCode_InvalidLength_FailsValidation() // Tester om postnummeret ikke har præcis 4 tegn
    {
        // Arrange
        var model = CreateValidModel();
        model.PostalCode = "500"; // Tester et postnummer med kun 3 tegn

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
            r.MemberNames.Contains(nameof(ChangeAccountInfoViewModel.PostalCode)));
    }

    [Fact]
    public void PostalCode_InvalidCharacters_FailsValidation() // Tester om postnummeret indeholder andet end tal
    {
        // Arrange
        var model = CreateValidModel();
        model.PostalCode = "50A0"; // Tester et postnummer med et bogstav

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
            r.MemberNames.Contains(nameof(ChangeAccountInfoViewModel.PostalCode)));
    }

    [Fact]
    public void Country_TooShort_FailsValidation() // Tester om landenavnet er for kort
    {
        // Arrange
        var model = CreateValidModel();
        model.Country = "D"; // Tester et landenavn med mindre end 2 tegn

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
            r.MemberNames.Contains(nameof(ChangeAccountInfoViewModel.Country)));
    }

    [Fact]
    public void Country_InvalidCharacters_FailsValidation() // Tester om landenavnet indeholder ugyldige tegn
    {
        // Arrange
        var model = CreateValidModel();
        model.Country = "Denmark123"; // Tester et landenavn med tal

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
            r.MemberNames.Contains(nameof(ChangeAccountInfoViewModel.Country)));
    }

    // Opretter en model med gyldige standardværdier
    private static ChangeAccountInfoViewModel CreateValidModel()
    {
        return new ChangeAccountInfoViewModel
        {
            CompanyName = "Test Company",
            ContactTitle = "Manager",
            Address = "Test Street 12",
            City = "Odense",
            Region = "Fyn",
            PostalCode = "5000",
            Country = "Denmark"
        };
    }
}
