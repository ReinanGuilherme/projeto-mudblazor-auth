using Microsoft.AspNetCore.Mvc;
using MudblazorAuth.Application.UseCases.Account.Register;
using MudblazorAuth.Communication.Requests;
using MudblazorAuth.Communication.Responses;


namespace MudblazorAuth.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Register(IAccountRegisterUseCase useCase,RequestAccountRegister request)
        {
            ResponseAccountRegister idAccount = await useCase.Execute(request);

            return Created(string.Empty, idAccount);
        }
    }
}
