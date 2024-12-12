using Business.Interfaces;
using Business.Models;
using Business.Services;
using Moq;

namespace MainApp_Tests.Services;

public class StorageService_Tests
{
    private readonly Mock<IStorageService> _storageServiceMock;
    private readonly IContactService _contactService;

    public StorageService_Tests()
    {
        _storageServiceMock = new Mock<IStorageService>();
        _contactService = new ContactService(_storageServiceMock.Object);
    }
    //
    //[Fact] 
    //public void AddContact_ShouldAddContactToStorage()
    //{
    //    var contactEntity = new ContactEntity();

    //    _storageServiceMock
    //        .Setup(ss => ss.SaveContactsToStorage(contactEntity))
    //        .Returns(true);

    //    var result = _contactService.Add(contactEntity);
    //}
}
