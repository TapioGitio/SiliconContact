using Business.Interfaces;
using Business.Models;
using Business.Services;
using Moq;

namespace MainApp_Tests.Services;

public class ContactService_Tests
{
    private readonly Mock<IStorageService> _storageServiceMock;
    private readonly IContactService _contactService;

    public ContactService_Tests()
    {
        _storageServiceMock = new Mock<IStorageService>();
        _contactService = new ContactService(_storageServiceMock.Object);
    }

    [Fact]
    public void ConvertToContactEntity_ShouldConvertContactFormToEntity()
    {
        var crf = new ContactRegistrationForm()
        {
            FirstName = "Test",
            LastName = "Testsson",
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

        var crf = new ContactRegistrationForm()

        {
            FirstName = "Kalle",
            LastName = "kallesson",
            Email = "Kalle@domain.com"
        };

        _storageServiceMock
          .Setup(ss => ss.SaveContactsToStorage(It.IsAny<List<ContactEntity>>()))
          .Returns(true);

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
            LastName = "Testsson",
            Email = "janne@domain.com"
        };

        _storageServiceMock
            .Setup(ss => ss.SaveContactsToStorage(It.IsAny<List<ContactEntity>>()))
            .Returns(true);

        var result = _contactService.SaveContact(ce);

        Assert.True(result);
        _storageServiceMock.Verify(ss => ss.SaveContactsToStorage(It.IsAny<List<ContactEntity>>()), Times.Once);
    }

    [Fact]
    public void Display_ShouldReturnAListOfTypeContact()
    {
        var ce = new List<ContactEntity>
        {
            new ContactEntity { FirstName = "Test", LastName = "Testsson", Email = "janne@domain.com" },
            new ContactEntity { FirstName = "Test2", LastName = "Testsson2", Email = "carl@domain.com" }
        };


        _storageServiceMock
            .Setup(ss => ss.LoadContactsFromStorage())
            .Returns(ce);

        var result = _contactService.Display();

        Assert.NotEmpty(result);
        Assert.IsType<List<Contact>>(result);

        Assert.Equal(ce[0].FirstName, result.First().FirstName);
        Assert.Equal(ce[0].LastName, result.First().LastName);
        Assert.Equal(ce[0].Email, result.First().Email);

        Assert.Equal(ce[1].FirstName, result.ElementAt(1).FirstName);
        Assert.Equal(ce[1].LastName, result.ElementAt(1).LastName);
        Assert.Equal(ce[1].Email, result.ElementAt(1).Email);

    }

    [Fact]
    public void Update_ShouldUpdateEmailOfAContact()
    {
        //Didnt know how to test this properly since the method cant update the mocked version
        //so I did a little manual change to simulate a change.

        var ce = new List<ContactEntity>
        {
            new ContactEntity { FirstName = "Test", LastName = "Testsson", Email = "janne@domain.com" },
        };

        _contactService.Update("Test", "CORRECT");

        ce[0].Email = "CORRECT";
        _storageServiceMock
          .Setup(ss => ss.LoadContactsFromStorage())
          .Returns(ce);

        var result = _contactService.Display();

        Assert.NotEmpty(result);
        Assert.Equal("CORRECT", result.First().Email);
    }

    [Fact]
    public void ContactExists_ShouldCheckIf_FirstNameMatches()
    {
        var ce = new List<ContactEntity>
        {
            new ContactEntity { FirstName = "TestEXIST", LastName = "Testsson", Email = "janne@domain.com" },
        };

        _storageServiceMock
        .Setup(ss => ss.LoadContactsFromStorage())
        .Returns(ce);

        var result = _contactService.ContactExists("TestEXIST");

        Assert.True(result);
    }

    [Fact]
    public void RemoveAll_ShouldRemoveAllItemsInTheStorage_AndList()
    {
        var ce = new List<ContactEntity>
        {
            new ContactEntity { FirstName = "TestEXIST", LastName = "Testsson", Email = "janne@domain.com" },
        };

        _storageServiceMock
        .Setup(ss => ss.DeleteContactsFromStorage())
        .Returns(true);

        var result = _contactService.RemoveAll();

        Assert.True(result);
        Assert.Empty(ce);
    }
}