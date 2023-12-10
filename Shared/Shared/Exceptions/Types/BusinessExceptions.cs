namespace Shared.Exceptions.Types;

public class BusinessExceptions: Exception
{
    public BusinessExceptions()
    {
    }
    
    public BusinessExceptions(string? message) : base(message)
    {
    }
}