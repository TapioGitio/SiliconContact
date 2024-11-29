using Business.Models;

namespace Business.Services;

public class ContactService
{
    public void Add(ContactRegistrationForm contactForm)
    {
        var contactEntity = new ContactEntity()
        {

            FirstName = contactForm.FirstName,
            LastName = contactForm.LastName,
            Email = contactForm.Email,
            PhoneNumber = contactForm.PhoneNumber,
            Address = contactForm.Address,
            PostalCode = contactForm.PostalCode,
            City = contactForm.City,
        };
    }

    public void Show()
    {

    }
}
