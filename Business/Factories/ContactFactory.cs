using Business.Handlers;
using Business.Models;
using System.Diagnostics;

namespace Business.Factories;

public static class ContactFactory
{
    public static ContactRegistrationForm Create()
    {
        try
        {
            return new ContactRegistrationForm();
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null!;
        }
    }

    public static ContactEntity Create(ContactRegistrationForm contactForm)
    {
        try
        {
            return new ContactEntity
            {
                Id = IdGenerator.GenerateID(),
                FirstName = contactForm.FirstName,
                LastName = contactForm.LastName,
                Email = contactForm.Email,
                PhoneNumber = contactForm.PhoneNumber,
                Address = contactForm.Address,
                PostalCode = contactForm.PostalCode,
                City = contactForm.City,
            };
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null!;
        }
    }

    public static Contact Create(ContactEntity contactEntity)
    {
        try
        {
            return new Contact
            {
                Id = contactEntity.Id,
                FirstName = contactEntity.FirstName,
                LastName = contactEntity.LastName,
                Email = contactEntity.Email
            };
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null!;
        }
    }
}
