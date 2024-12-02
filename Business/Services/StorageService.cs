using Business.Models;

namespace Business.Services;

public class StorageService
{
    private readonly string _directoryPath;
    private readonly string _fileName;

    public StorageService(string directoryPath = "DataStorage", string fileName = "contacts.json")
    {
        _directoryPath = directoryPath;
        _fileName = Path.Combine(_directoryPath, fileName);
    }

    public void SaveContactsToStorage(List<ContactEntity> contactEntity)
    {

    }

    public List<Contact> LoadContactsFromStorage()
    {

    }
}
