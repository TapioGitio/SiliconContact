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

    public IEnumerable<ContactEntity> Display()
    {
        try
        {
            _contacts = _storageService.LoadContactsFromStorage();
            return _contacts;
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
