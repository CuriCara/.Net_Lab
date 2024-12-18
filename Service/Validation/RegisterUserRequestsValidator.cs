using FluentValidation;
using Service.Controllers.Entity;

namespace Service.Validation;

public class RegisterUserRequestsValidator : AbstractValidator<RegisterUserRequest>
{
    public RegisterUserRequestsValidator()
    {
        RuleFor(x => x.PasswordHash)
            .NotEmpty()
            .WithMessage("Требуется ввести пароль");
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress()
            .WithMessage("Требуется ввести почту");
        RuleFor(x => x.Name)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(200)
            .WithMessage("Требуется ввести имя");
        RuleFor(x => x.Surname)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(200)
            .WithMessage("Требуется ввести фамилию");
        RuleFor(x => x.RoleId)
            .NotEmpty()
            .WithMessage("Требуется разрешение");
    }
}