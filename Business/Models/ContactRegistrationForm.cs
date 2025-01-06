using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Business.Models;

public class ContactRegistrationForm : ObservableValidator
{

    //Read .NET documentation on the validator class but got a little help implementing it to this form
    //It takes the inputs and uses the ÓbservableValidator class to set the property and with the Validate method
    //checks if the inputs are valid and true to the regex format. 

    private string _firstName = string.Empty;
    private string _lastName = string.Empty;
    private string _email = string.Empty;

    [Required(ErrorMessage = "You have to enter first name")]
    [RegularExpression(@"^[a-zA-Z]{2,}$", ErrorMessage = "Atleast two letters  please")]
    public string FirstName
    {
        get => _firstName;
        set => SetProperty(ref _firstName, value, true);
    }

    [Required(ErrorMessage = "You have to enter last name")]
    [RegularExpression(@"^[a-zA-Z]{2,}$", ErrorMessage = "Atleast two letters  please")]
    public string LastName
    {
        get => _lastName;
        set => SetProperty(ref _lastName, value, true);
    }

    [Required(ErrorMessage = "You have to enter your email")]
    [RegularExpression(@"^[a-zA-Z0-9._%+-]{2,}@[a-zA-Z0-9.-]{2,}\.[a-zA-Z]{2,}$", ErrorMessage = "Must follow this format: [ab@cd.ef]")]
    public string Email
    {
        get => _email;
        set => SetProperty(ref _email, value, true);
    }
    public string? PhoneNumber { get; set; } = null!;
    public string? Address { get; set; } = null!; 
    public string? PostalCode { get; set; } = null!;
    public string? City { get; set; } = null!;

    public void Validate()
    {
        ValidateAllProperties();
    }
}
