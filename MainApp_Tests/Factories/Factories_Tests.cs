using Business.Factories;
using Business.Models;

namespace MainApp_Tests.Factories;

public class Factories_Tests
{
    [Fact]
    public void ContactRegistrationForm_ShouldCreateAnInstanceOf_ContactRegistrationForm()
    {
        var result = ContactFactory.Create();
        Assert.IsType<ContactRegistrationForm>(result);
    }

    [Fact]
    public void ContactEntity_ShouldCreateAnInstanceOf_ContactEntity()
    {
        ContactRegistrationForm contactRegistrationForm = new();
        var result = ContactFactory.Create(contactRegistrationForm);

        Assert.IsType<ContactEntity>(result);
    }

    [Fact]
    public void Contact_ShouldCreateAnInstanceOf_Contact()
    {
        ContactEntity contactEntity = new();
        var result = ContactFactory.Create(contactEntity);

        Assert.IsType<Contact>(result);
    }
}
