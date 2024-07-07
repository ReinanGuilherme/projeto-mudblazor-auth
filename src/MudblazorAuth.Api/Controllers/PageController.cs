using Microsoft.AspNetCore.Mvc;
using MudblazorAuth.Application.UseCases.Page.GetAllByIdProfile;

namespace MudblazorAuth.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PageController : ControllerBase
	{
		[HttpGet("user")]
		public async Task<ActionResult> GetAllByIdProfile([FromServices] IGetAllByIdProfileUseCase useCase)
		{
			var response = await useCase.Execute();
			return Ok(response);
		}
	}
}
