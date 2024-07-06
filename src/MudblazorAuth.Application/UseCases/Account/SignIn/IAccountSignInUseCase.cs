using MudblazorAuth.Communication.Requests.Account;
using MudblazorAuth.Communication.Responses;

namespace MudblazorAuth.Application.UseCases.Account.SignIn
{
	public interface IAccountSignInUseCase
	{
		Task<ResponseAccountSignIn> Execute(RequestAccountSignIn request);
	}
}
