using eCommerce.Core.DTOs;
using FluentValidation;

namespace eCommerce.Core.Validators;
public sealed class LoginRequestValidator : AbstractValidator<LoginRequest>
{
    public LoginRequestValidator()
    {
        RuleFor(loginRequest => loginRequest.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid email format.");
        RuleFor(loginRequest => loginRequest.Password)
            .NotEmpty().WithMessage("Password is required.")
            .MinimumLength(3).WithMessage("Wrong Password");
    }
}
