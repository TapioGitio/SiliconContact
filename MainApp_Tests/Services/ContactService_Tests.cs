using Business.Interfaces;
using Business.Models;
using Business.Services;
using Moq;

namespace MainApp_Tests.Services;

public class ContactService_Tests
{
    private readonly Mock<IStorageService> _storageServiceMock;
    private readonly ContactService _contactService;

    public ContactService_Tests()
    {
        _storageServiceMock = new Mock<IStorageService>();
        _contactService = new ContactService(_storageServiceMock.Object);
    }

    [Fact]
    public void CreateContactEntity_ShouldConvertContactFormToEnity()
    {
        var crf = new ContactRegistrationForm()
        {
            FirstName = "Test",
            Email = "Test@thismethod.com"
        };

        var ce = _contactService.ConvertToContactEntity(crf);


        Assert.NotNull(ce);
        Assert.Equal(ce.FirstName, crf.FirstName);
        Assert.Equal(ce.Email, crf.Email);
        Assert.IsType<ContactEntity>(ce);

    }

    [Fact]
    public void AddContact_ShouldConvertToContactEntity_AndSaveToStorage()
    {
        var crf = new ContactRegistrationForm
        {
            FirstName = "Kalle",
            Email = "Kalle@domain.com"
        };

        var result = _contactService.AddContact(crf);

        Assert.True(result);
        _storageServiceMock.Verify(s => s.SaveContactsToStorage(It.IsAny<List<ContactEntity>>()), Times.Once);

    }

    [Fact]

    public void SaveContact_ShouldSaveToListAndStorage()
    {
        var ce = new ContactEntity()
        {
            FirstName = "Test",
            Email = "janne@domain.com"
        };

        var result = _contactService.SaveContact(ce);

        Assert.True(result);
        Assert.True(_contactService.ContactExists(ce.FirstName));
        _storageServiceMock.Verify(s => s.SaveContactsToStorage(It.IsAny<List<ContactEntity>>()), Times.Once);
    }
}
