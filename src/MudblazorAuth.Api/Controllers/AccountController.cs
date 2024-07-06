using Microsoft.AspNetCore.Mvc;
using MudblazorAuth.Application.UseCases.Account.Register;
using MudblazorAuth.Application.UseCases.Account.SignIn;
using MudblazorAuth.Communication.Requests.Account;
using MudblazorAuth.Communication.Responses;


namespace MudblazorAuth.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AccountController : ControllerBase
	{
		[HttpPost("sign-in")]
		public async Task<IActionResult> SignIn(
			[FromServices] IAccountSignInUseCase useCase,
			[FromBody] RequestAccountSignIn request)
		{
			var response = await useCase.Execute(request);
			return Created(string.Empty, response);
		}

		[HttpPost("register")]
		public async Task<IActionResult> Register(
			[FromServices] IAccountRegisterUseCase useCase,
			[FromBody] RequestAccountRegister request)
		{
			ResponseAccountRegister idAccount = await useCase.Execute(request);

			return Created(string.Empty, idAccount);
		}
	}
}
