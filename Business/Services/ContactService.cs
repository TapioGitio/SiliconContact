using Business.Factories;
using Business.Interfaces;
using Business.Models;
using System.Diagnostics;

namespace Business.Services;

public class ContactService(IStorageService storageService) : IContactService
{
    private List<ContactEntity> _contacts = [];
    private readonly IStorageService _storageService = storageService;

    public bool AddContact(ContactRegistrationForm contactForm)
    {
        try
        {
            var contactEntity = ConvertToContactEntity(contactForm);

            SaveContact(contactEntity);
            return true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }
    }

    public ContactEntity ConvertToContactEntity(ContactRegistrationForm contactForm)
    {
        return ContactFactory.Create(contactForm);
    }

    public bool SaveContact(ContactEntity contactEntity)
    {
        try
        {
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
        List<Contact> displayFriendly = [];

        try
        {
            _contacts = _storageService.LoadContactsFromStorage();

            foreach (ContactEntity contactEntity in _contacts)
            {
                Contact contact = ContactFactory.Create(contactEntity);
                displayFriendly.Add(contact);
            }
            return displayFriendly;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error loading the list: {ex.Message}");
            return [];
        }
    }

    public bool Update(string contactName, string updatedEmail)
    {
        try
        {
            /*This was made with AI: It creates a variable to check if the input matches a contacts firstname in my contacts-list
            * with the FirstOrDefault method. It then checks if its not null to be able to set the email with an updated email
            * provided from the user-input. Aswell as saving the updated info to the storage/file. Otherwise it returns as false.
            */
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

    public bool ContactExists(string contactName)
    {
        try
        {
            _contacts = _storageService.LoadContactsFromStorage();
            return _contacts.Any(x => x.FirstName.Equals(contactName, StringComparison.OrdinalIgnoreCase));
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }
    }

    public bool RemoveAll()
    {
        try
        {
            if (_contacts.Count != 0)
            {
                _storageService.DeleteContactsFromStorage();
                _contacts.Clear();
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

    public bool RemoveOne(Contact contact)
    {
        try
        {
            var contactEntity = _contacts.FirstOrDefault(x => x.Id == contact.Id);
            if (contactEntity != null)
            {
                _contacts.Remove(contactEntity);
                _storageService.SaveContactsToStorage(_contacts);
                return true;
            }
            else
            {
                Debug.WriteLine("Contact not found");
            }
        }

        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
        return false;
    }
}
