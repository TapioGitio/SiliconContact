using System.ComponentModel.DataAnnotations;

namespace Business.Models;

public class ContactRegistrationForm
{
    [Required(ErrorMessage = "You have to enter first name")]
    [MinLength(2, ErrorMessage = "Atleast two letters  please")]
    public string FirstName { get; set; } = null!;

    [Required(ErrorMessage = "You have to enter last name")]
    [MinLength(2, ErrorMessage = "Atleast two letters  please")]
    public string LastName { get; set; } = null!;

    [Required(ErrorMessage = "You have to enter your email")]
    [RegularExpression(@"^[a-zA-Z0-9._%+-]{2,}@[a-zA-Z0-9.-]{2,}\.[a-zA-Z]{2,}$", ErrorMessage = "Must follow this format: [ab@cd.ef]")]
    public string Email { get; set; } = null!;
    public string? PhoneNumber { get; set; } = null!;
    public string? Address { get; set; } = null!; 
    public string? PostalCode { get; set; } = null!;
    public string? City { get; set; } = null!;
}
