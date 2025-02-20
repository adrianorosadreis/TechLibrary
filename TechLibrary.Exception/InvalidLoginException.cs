using System.Net;

namespace TechLibrary.Exception
{
    public class InvalidLoginException : TechLibraryException
    {
        public override List<string> GetErrorMessages() => ["Invalid login"];
        public override HttpStatusCode GetStatusCode() => HttpStatusCode.BadRequest;
    }
}
