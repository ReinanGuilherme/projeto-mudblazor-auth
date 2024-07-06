using AutoMapper;
using MudblazorAuth.Communication.Requests.Account;
using MudblazorAuth.Communication.Responses;
using MudblazorAuth.Domain.Repositories;
using MudblazorAuth.Domain.Security.Cryptography;
using MudblazorAuth.Domain.Security.Tokens;
using MudblazorAuth.Exception;
using MudblazorAuth.Exception.ExceptionsBase;

namespace MudblazorAuth.Application.UseCases.Account.SignIn
{
	internal class AccountSignInUseCase : IAccountSignInUseCase
	{
		private readonly IAccountReadOnlyRepository _accountReadOnlyRepository;
		private readonly IToken _token;
		private readonly ICryptography _cryptography;

		public AccountSignInUseCase(IAccountReadOnlyRepository accountReadOnlyRepository, IToken token, ICryptography cryptography)
		{
			_accountReadOnlyRepository = accountReadOnlyRepository;
			_token = token;
			_cryptography = cryptography;
		}

		public async Task<ResponseAccountSignIn> Execute(RequestAccountSignIn request)
		{
			var resultGetByUsername = await _accountReadOnlyRepository.GetByUsername(request.Username);

			if (resultGetByUsername is null) 
				throw new ErrorInvalidLoginException();

			var passwordMatch = _cryptography.Verify(request.Password, resultGetByUsername.Password);

			if (!passwordMatch)
			{
				throw new ErrorInvalidLoginException();
			}


			var response = new ResponseAccountSignIn
			{
				Token = _token.Generate(resultGetByUsername)
			};

			return response;
		}
	}
}
