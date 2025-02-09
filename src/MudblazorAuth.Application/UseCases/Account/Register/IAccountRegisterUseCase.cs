﻿using MudblazorAuth.Communication.Requests.Account;
using MudblazorAuth.Communication.Responses;

namespace MudblazorAuth.Application.UseCases.Account.Register
{
    public interface IAccountRegisterUseCase
    {
        Task<ResponseAccountRegister> Execute(RequestAccountRegister request);
    }
}
