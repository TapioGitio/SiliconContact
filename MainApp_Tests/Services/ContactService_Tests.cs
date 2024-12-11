using Business.Interfaces;
using Business.Models;
using Business.Services;
using Moq;

namespace MainApp_Tests.Services;

public class ContactService_Tests
{
    private readonly Mock<IContactService> _contactServiceMock;
    private readonly IContactService _contactService;

    public ContactService_Tests()
    {
        _contactServiceMock = new Mock<IContactService>();
        _contactService = new ContactService(_contactServiceMock.Object);
    }

    [Fact]
    public void AddContact_ShouldAddContactToList()
    {
        var contactRegFrom = new ContactRegistrationForm();

        _storageServiceMock
            .Setup(ss => ss.SaveContactsToStorage(It.IsAny<string>()))
            .Returns(true);

        var result = _contactService.Add(contactRegFrom);
    }
}
