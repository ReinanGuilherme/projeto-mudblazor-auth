using FluentValidation;
using MudblazorAuth.Communication.Requests;
using MudblazorAuth.Exception;

namespace MudblazorAuth.Application.UseCases.Account.Register
{
    public class AccountRegisterValidator : AbstractValidator<RequestAccountRegister>
    {
        public AccountRegisterValidator()
        {
            RuleFor(user => user.Username)
                .NotEmpty().WithMessage(ResourceErrorMessages.USERNAME_EMPTY);
            RuleFor(user => user.Password)
                .NotEmpty().WithMessage(ResourceErrorMessages.PASSWORD_EMPTY)
                .MinimumLength(8).WithMessage(ResourceErrorMessages.PASSWORD_MIN_LENGHT);
            RuleFor(user => user.IdProfile)
                .GreaterThan(0).WithMessage(ResourceErrorMessages.ID_PROFILE_INVALID);
        }
    }

}
