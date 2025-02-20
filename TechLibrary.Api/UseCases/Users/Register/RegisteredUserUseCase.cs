using FluentValidation.Results;
using TechLibrary.Api.Domain.Entities;
using TechLibrary.Api.Infrastructure.DataAccess;
using TechLibrary.Api.Infrastructure.Security.Cryptography;
using TechLibrary.Api.Infrastructure.Security.Tokens.Access;
using TechLibrary.Communication.Requests;
using TechLibrary.Communication.Responses;
using TechLibrary.Exception;

namespace TechLibrary.Api.UseCases.Users.Register
{
    public class RegisteredUserUseCase
    {
        public ResponseRegisteredUserJson Execute(RequestUserJson request)
        {
            var dbContext = new TechLibraryDbContext();

            Validate(request, dbContext);

            var crypto = new BCryptAlgorithm();

            var user = new User
            {
                Email = request.Email,
                Name = request.Name,                
                Password = crypto.HashPassword(request.Password),
            };

            dbContext.Users.Add(user);
            dbContext.SaveChanges();
            
            return new ResponseRegisteredUserJson
            {
                Name = user.Name,
                AccessToken = new JwtTokenGenerator().GenerateToken(user)
            };
        }

        private void Validate(RequestUserJson request, TechLibraryDbContext dbContext)
        {
            var result = new RegisterUserValidator().Validate(request);

            var existUserWithEmail = dbContext.Users.Any(user => user.Email.Equals(request.Email));
            if (existUserWithEmail)
                result.Errors.Add(new ValidationFailure("Email", "Email already registered!"));

            if (!result.IsValid)
            {
                var errorMessages = result.Errors.Select(error => error.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}
