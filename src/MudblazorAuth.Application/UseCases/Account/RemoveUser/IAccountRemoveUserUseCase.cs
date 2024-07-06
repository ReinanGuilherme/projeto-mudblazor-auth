namespace MudblazorAuth.Application.UseCases.Account.RemoveUser
{
	public interface IAccountRemoveUserUseCase
	{
		Task Execute(string username);
	}
}
