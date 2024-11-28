namespace Business.Models;

public class ContactEntity
{
    public string Id = Guid.NewGuid().ToString();
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public int PhoneNumber { get; set; } = 0;
    public string Address { get; set; } = null!;
    public int PostalCode { get; set; } = 0;
    public string City { get; set; } = null!;
}
