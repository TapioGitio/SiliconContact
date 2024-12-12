using Business.Interfaces;
using Business.Models;
using Business.Services;
using Moq;

namespace MainApp_Tests.Services;

public class StorageService_Tests
{
    private readonly Mock<IStorageService> _storageServiceMock;

    public StorageService_Tests()
    {
        _storageServiceMock = new Mock<IStorageService>();
    }
    
    [Fact]
    public void SaveContactsToStorage_ShouldAddContactToStorage()
    {
        var contactList = new List<ContactEntity>()
        {
            new ContactEntity{ FirstName = "Test", Email = "scadooble@gmail.com"}
        };

        _storageServiceMock
            .Setup(ss => ss.SaveContactsToStorage(It.IsAny<List<ContactEntity>>()))
            .Returns(true);

        var result = _storageServiceMock.Object.SaveContactsToStorage(contactList);

        Assert.True(result);
        Assert.Single(contactList);
        _storageServiceMock.Verify(ss => ss.SaveContactsToStorage(It.IsAny<List<ContactEntity>>()), Times.Once);

    }
}
