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
        try
        {
            var list = new List<Contact>();
            foreach (var contactEntity in _contacts)
            {
                list.Add(ContactFactory.Create(contactEntity));
            }
            return list;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return [];
        }
    }

    public void Remove()
    {
        _contacts.Clear();
    }
}
