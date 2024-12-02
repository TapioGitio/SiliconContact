using System.Diagnostics;

namespace Business.Handlers;

public static class IdGenerator
{
    public static string GenerateID()
    {
        try
        {
            return Guid.NewGuid().ToString();
        }
        catch (Exception ex) 
        {
            Debug.WriteLine(ex.Message);
            return null!;
        }
    }
}
