using FluentValidation;
using MudblazorAuth.Exception;

namespace MudblazorAuth.Application.UseCases.Account.RemoveUser
{
	public class AccountRemoveUserValidator : AbstractValidator<string>
	{
		public AccountRemoveUserValidator()
		{
			RuleFor(user => user)
				.NotEmpty().WithMessage(ResourceErrorMessages.USERNAME_EMPTY);
		}
	}
}
