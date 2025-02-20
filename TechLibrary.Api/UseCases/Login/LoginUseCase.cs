using Microsoft.EntityFrameworkCore;
using TechLibrary.Api.Infrastructure.DataAccess;
using TechLibrary.Api.Infrastructure.Security.Cryptography;
using TechLibrary.Api.Infrastructure.Security.Tokens.Access;
using TechLibrary.Communication.Requests;
using TechLibrary.Communication.Responses;
using TechLibrary.Exception;

namespace TechLibrary.Api.UseCases.Login
{
    public class LoginUseCase
    {
        public ResponseRegisteredUserJson Execute(RequestLoginJson request)
        {
            var dbContext = new TechLibraryDbContext();

            var user = dbContext.Users.FirstOrDefault(u => u.Email.Equals(request.Email));

            if (user == null)
                throw new InvalidLoginException();

            var cryptography = new BCryptAlgorithm();
            var passwordIsValid = cryptography.VerifyPassword(request.Password, user);

            if (!passwordIsValid)           
                throw new InvalidLoginException();
            
            return new ResponseRegisteredUserJson
            {
                Name = user.Name,
                AccessToken = new JwtTokenGenerator().GenerateToken(user)
            };
        }
    }
}
