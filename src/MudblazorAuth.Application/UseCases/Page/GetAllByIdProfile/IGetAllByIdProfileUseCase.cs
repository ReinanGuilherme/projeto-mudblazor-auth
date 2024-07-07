using MudblazorAuth.Communication.Responses;

namespace MudblazorAuth.Application.UseCases.Page.GetAllByIdProfile
{
	public interface IGetAllByIdProfileUseCase
	{
		Task<IEnumerable<ResponseGetAllByIdProfile>> Execute();
	}
}
