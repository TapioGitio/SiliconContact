using Business.Models;

namespace Business.Interfaces
{
    public interface IContactService
    {
        bool AddContact(ContactRegistrationForm contactForm);
        ContactEntity ConvertToContactEntity(ContactRegistrationForm contactForm);
        bool SaveContact(ContactEntity contactEntity);

        IEnumerable<Contact> Display();
        bool ContactExists(string contactName);
        bool Update(string contactName, string updatedEmail);
        bool RemoveAll();
    }
}