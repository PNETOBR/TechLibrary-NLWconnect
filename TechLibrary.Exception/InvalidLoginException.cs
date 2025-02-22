using System.Net;

namespace TechLibrary.Exception;
public class InvalidLoginException : TechLibraryException
{
    public InvalidLoginException() : base("Email ou senha invalidos.") { }
     
    public override List<string> GetErrorMessages() => ["Email ou senha invalidos."];


    public override HttpStatusCode GetStatusCode() => HttpStatusCode.Unauthorized;
}
