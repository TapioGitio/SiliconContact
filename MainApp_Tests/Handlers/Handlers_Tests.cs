using Business.Handlers;

namespace MainApp_Tests.Handlers;

public class Handlers_Tests
{
    [Fact]
    public void IdGenerator_ShouldReturnATypeOfGuid()
    {
        var result = IdGenerator.GenerateID();

        Assert.True(Guid.TryParse(result, out _));
        Assert.False(string.IsNullOrEmpty(result));
    }
}
