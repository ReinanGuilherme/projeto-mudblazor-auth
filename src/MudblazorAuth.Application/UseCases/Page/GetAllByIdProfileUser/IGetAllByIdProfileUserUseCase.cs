using MudblazorAuth.Communication.Responses;

namespace MudblazorAuth.Application.UseCases.Page.GetAllByIdProfileUser
{
	public interface IGetAllByIdProfileUserUseCase
	{
		Task<IEnumerable<ResponseGetAllByIdProfile>> Execute();
	}
}
