using Business.Models;

namespace Business.Factories;

public static class ContactFactory
{
    public static ContactRegistrationForm Create()
    {
        return new ContactRegistrationForm();
    }

    public static ContactEntity Create(ContactRegistrationForm contactForm)
    {
        return new ContactEntity
        {
            Id = Guid.NewGuid().ToString(),
            FirstName = contactForm.FirstName,
            LastName = contactForm.LastName,
            Email = contactForm.Email,
            PhoneNumber = contactForm.PhoneNumber,
            Address = contactForm.Address,
            PostalCode = contactForm.PostalCode,
            City = contactForm.City,
        };
    }

    public static Contact Create(ContactEntity contactEntity)
    {
        return new Contact
        {
            Id = Guid.NewGuid().ToString(),
            FirstName = contactEntity.FirstName,
            LastName = contactEntity.LastName,
            Email = contactEntity.Email
        };
    }
}
