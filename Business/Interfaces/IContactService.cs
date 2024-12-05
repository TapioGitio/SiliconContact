using Business.Models;

namespace Business.Interfaces
{
    public interface IContactService
    {
        bool Add(ContactRegistrationForm contactForm);
        IEnumerable<Contact> Display();
        bool ContactExists(string contactName);
        bool Remove();
        bool Update(string contactName, string updatedEmail);
    }
}