using Business.Models;

namespace Business.Interfaces
{
    public interface IStorageService
    {
        void DeleteContactsFromStorage();
        List<ContactEntity> LoadContactsFromStorage();
        void SaveContactsToStorage(List<ContactEntity> contactEntity);
    }
}