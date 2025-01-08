using Business.Models;

namespace Business.Interfaces
{
    public interface IStorageService
    {
        bool DeleteContactsFromStorage();
        List<ContactEntity> LoadContactsFromStorage();
        bool SaveContactsToStorage(List<ContactEntity> contactEntity);
    }
}