using MudblazorAuth.Communication.Responses;

namespace MudblazorAuth.Application.UseCases.Account.GetAllUsers
{
	public interface IAccountGetAllUsersUseCase
	{
		Task<IEnumerable<ResponseAccountGetAllUsers>?> Execute();
	}
}
