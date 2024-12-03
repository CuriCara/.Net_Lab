namespace BusinessLogic.Users.Exception;

public class UserNotFoundException : ApplicationException
{
    public UserNotFoundException() { }
    
    public UserNotFoundException(string message) : base(message) { }
}