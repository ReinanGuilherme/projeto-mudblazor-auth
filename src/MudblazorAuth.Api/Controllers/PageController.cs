using Microsoft.AspNetCore.Mvc;
using MudblazorAuth.Application.UseCases.Page.GetAllByIdProfileUser;

namespace MudblazorAuth.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PageController : ControllerBase
	{
		[HttpGet("user")]
		public async Task<ActionResult> GetAllByIdProfileUser([FromServices] IGetAllByIdProfileUserUseCase useCase)
		{
			var response = await useCase.Execute();
			return Ok(response);
		}
	}
}
