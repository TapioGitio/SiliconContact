using Business.Models;

namespace Business.Interfaces
{
    public interface IStorageService
    {
        void DeleteContactsFromStorage();
        List<ContactEntity> LoadContactsFromStorage();
        bool SaveContactsToStorage(List<ContactEntity> contactEntity);
    }
}