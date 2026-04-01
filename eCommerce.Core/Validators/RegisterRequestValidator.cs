using eCommerce.Core.DTOs;
using FluentValidation;
namespace eCommerce.Core.Validators;
public sealed class RegisterRequestValidator : AbstractValidator<RegisterRequest>
{
    public RegisterRequestValidator()
    {
        RuleFor(registerRequest => registerRequest.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid email format.");
        RuleFor(registerRequest => registerRequest.PersonName)
            .NotEmpty().WithMessage("PersonName is required.");
        RuleFor(registerRequest => registerRequest.Password)
            .NotEmpty().WithMessage("Password is required.")
            .MinimumLength(3).WithMessage("Password must be at least 3 characters long.");
    }
}
