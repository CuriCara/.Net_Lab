namespace BusinessLogic.Authorization.Exceptions;

public class AuthExceptions : Exception
{
    public Excep? _Excep { get; set; }

    public AuthExceptions(string message) : base(message) { }

    public AuthExceptions(Excep excep) : base(excep.ToString()) { _Excep = excep; }
}