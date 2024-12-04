﻿using Business.Factories;
using Business.Models;
using System.Diagnostics;

namespace Business.Services;

public class ContactService(StorageService storageService)
{
    private List<ContactEntity> _contacts = [];
    private readonly StorageService _storageService = storageService;

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

    public bool IfContactExists(string contactName)
    {
        return _contacts.Any(x => x.FirstName.Equals(contactName, StringComparison.OrdinalIgnoreCase));
    }   

    public void Remove()
    {
        _contacts.Clear();
        _storageService.DeleteContactsFromStorage();
    }
}
