using Business.Models;
using Business.Services;

namespace MainApp_Tests.Services;

public class StorageService_Tests
{


    [Fact]
    public void SaveContactsToStorage_ShouldAddContactToStorage()
    {
        var tempDirectory = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());

        var storage = new StorageService(tempDirectory);

        var ce = new List<ContactEntity>()
        {
            new ContactEntity{ FirstName = "Test", Email = "scadooble@gmail.com"}
        };

        var result = storage.SaveContactsToStorage(ce);

        Assert.True(result);
        Assert.Single(ce);

        Directory.Delete(tempDirectory, true);


        //Got help from ai aswell as the video from Hans to be able to use an temp directory and then discard it
        //when the test is complete.
        //The tempdirectory variable creates a temporary folder with the .Net method getTempPath()
        //and for the filename like Hans did a guid.tostring.
        //We then use it as the filepath and at the end Delete the folder for cleaning to prevent unwanted files.
    }

    [Fact]
    public void LoadContactsFromStorage_ShouldFetchContactsFromStorage()
    {
        var tempDirectory = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());

        var storage = new StorageService(tempDirectory);

        var ce = new List<ContactEntity>()
        {
            new ContactEntity{ FirstName = "Test", Email = "scadooble@gmail.com"}
        };

        storage.SaveContactsToStorage(ce);

        var result = storage.LoadContactsFromStorage();

        Assert.NotEmpty(result);
        Assert.Single(result);
        Assert.Equal(ce[0].FirstName, result[0].FirstName);
        Assert.Equal(ce[0].Email, result[0].Email);


        Directory.Delete(tempDirectory, true);
    }
}
