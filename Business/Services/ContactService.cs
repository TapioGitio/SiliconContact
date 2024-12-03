using Business.Factories;
using Business.Models;
using System.Diagnostics;

namespace Business.Services;

public class ContactService
{
    private List<ContactEntity> _contacts = [];
    private readonly StorageService _storageService = new();

    public bool Add(ContactRegistrationForm contactForm)
    {
       try
       {
            ContactEntity contactEntity = ContactFactory.Create(contactForm);

            _contacts.Add(contactEntity);
            _storageService.SaveContactsToStorage(_contacts);
            return true;
       }
       catch (Exception ex)
       {
            Debug.WriteLine(ex.Message);
            return false;
       }
    }

    public IEnumerable<Contact> Display()
    {
        List<Contact> userFriendly = new List<Contact>();

        try
        {
            _contacts = _storageService.LoadContactsFromStorage();

            foreach (ContactEntity contactEntity in _contacts)
            {
                Contact contact = ContactFactory.Create(contactEntity);
                userFriendly.Add(contact);
            }
            return userFriendly;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return [];
        }
    }

    public bool Update(string contactName, string updatedEmail)
    {
        try
        {
            var contactEntity = _contacts.FirstOrDefault(x => x.FirstName.Equals(contactName, StringComparison.OrdinalIgnoreCase));
            if (contactEntity != null)
            {
                contactEntity.Email = updatedEmail;

                _storageService.SaveContactsToStorage(_contacts);
                return true;
            }
            return false;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }
    }

    public void Remove()
    {
        _contacts.Clear();
        _storageService.DeleteContactsFromStorage();
    }
}
