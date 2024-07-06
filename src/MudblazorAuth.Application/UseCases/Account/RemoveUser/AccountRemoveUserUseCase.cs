using Azure.Core;
using MudblazorAuth.Domain.Repositories;
using MudblazorAuth.Exception.ExceptionsBase;
using MudblazorAuth.Exception;
using MudblazorAuth.Application.UseCases.Account.Register;
using FluentValidation.Results;

namespace MudblazorAuth.Application.UseCases.Account.RemoveUser
{
	internal class AccountRemoveUserUseCase : IAccountRemoveUserUseCase
	{
		private readonly IAccountReadOnlyRepository _accountReadOnlyRepository;
		private readonly IAccountWriteOnlyRepository _acccountWriteOnlyRepository;
		private readonly IUnitOfWork _unitOfWork;

		public AccountRemoveUserUseCase(IAccountReadOnlyRepository accountReadOnlyRepository, IUnitOfWork unitOfWork, IAccountWriteOnlyRepository acccountWriteOnlyRepository)
		{
			_accountReadOnlyRepository = accountReadOnlyRepository;
			_unitOfWork = unitOfWork;
			_acccountWriteOnlyRepository = acccountWriteOnlyRepository;
		}

		public async Task Execute(string username)
		{
			var resultGetByUsername = await _accountReadOnlyRepository.GetByUsername(username);

			Validate(username, resultGetByUsername);

			await _acccountWriteOnlyRepository.Remove(resultGetByUsername!);

			await _unitOfWork.Commit();


		}

		private void Validate(string username, Domain.Entities.Account? account)
		{
			var resultValidate = new AccountRemoveUserValidator().Validate(username);

			if (account is null || account.IdProfile is not 2)
			{
				resultValidate.Errors.Add(new ValidationFailure(string.Empty, ResourceErrorMessages.ACCOUNT_NOT_USER));
			}

			if (resultValidate.IsValid is false)
			{
				var errorMessages = resultValidate.Errors.Select(f => f.ErrorMessage).ToList();

				throw new ErrorOnValidationException(errorMessages);
			}
		}
	}
}
