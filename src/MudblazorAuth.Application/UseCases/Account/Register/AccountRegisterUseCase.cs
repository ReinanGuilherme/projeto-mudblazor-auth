using AutoMapper;
using MudblazorAuth.Communication.Requests;
using MudblazorAuth.Communication.Responses;
using MudblazorAuth.Domain.Repositories;

namespace MudblazorAuth.Application.UseCases.Account.Register
{
    internal class AccountRegisterUseCase : IAccountRegisterUseCase
    {
        private readonly IAccountWriteOnlyRepository _acccountWriteOnlyRepository;
        private readonly IMapper _mapper;

        public AccountRegisterUseCase(IAccountWriteOnlyRepository acccountWriteOnlyRepository, IMapper mapper)
        {
            _acccountWriteOnlyRepository = acccountWriteOnlyRepository;
            _mapper = mapper;
        }

        public async Task<ResponseAccountRegister> Execute(RequestAccountRegister request)
        {
            var account = _mapper.Map<Domain.Entities.Account>(request);

            await _acccountWriteOnlyRepository.Add(account);

            var response = _mapper.Map<ResponseAccountRegister>(account);

            return response;
        }
    }
}
