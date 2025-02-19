using FluentValidation;
using TechLibrary.Communication.Requests;

namespace TechLibrary.Api.UseCases.Users.Register
{
    public class RegisterUserValidator : AbstractValidator<RequestUserJson>
    {
        public RegisterUserValidator()
        {
            RuleFor(request => request.Name).NotEmpty().WithMessage("The name is mandatory.");
            RuleFor(request => request.Email).EmailAddress().WithMessage("The email is not valid.");
            RuleFor(request => request.Password).NotEmpty().WithMessage("Password is mandatory.");
            When(reqquest => !string.IsNullOrEmpty(reqquest.Password), () =>
            {
                RuleFor(request => request.Password).MinimumLength(6).WithMessage("The password must be at least 6 characters long.");
            });
        }
    }
}
