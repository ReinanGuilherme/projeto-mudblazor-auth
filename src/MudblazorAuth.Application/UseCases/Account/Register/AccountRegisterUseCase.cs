using AutoMapper;
using MudblazorAuth.Communication.Requests;
using MudblazorAuth.Communication.Responses;
using MudblazorAuth.Domain.Repositories;
using MudblazorAuth.Domain.Security.Cryptography;

namespace MudblazorAuth.Application.UseCases.Account.Register
{
    internal class AccountRegisterUseCase : IAccountRegisterUseCase
    {
        private readonly IAccountWriteOnlyRepository _acccountWriteOnlyRepository;
        private readonly IMapper _mapper;
        private readonly ICryptography _cryptography;
        private readonly IUnitOfWork _unitOfWork;

        public AccountRegisterUseCase(IAccountWriteOnlyRepository acccountWriteOnlyRepository, IMapper mapper, ICryptography cryptography, IUnitOfWork unitOfWork)
        {
            _acccountWriteOnlyRepository = acccountWriteOnlyRepository;
            _mapper = mapper;
            _cryptography = cryptography;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseAccountRegister> Execute(RequestAccountRegister request)
        {
            var account = _mapper.Map<Domain.Entities.Account>(request);
            account.Password = _cryptography.Encrypt(request.Password);

            await _acccountWriteOnlyRepository.Add(account);
            await _unitOfWork.Commit();

            var response = _mapper.Map<ResponseAccountRegister>(account);

            return response;
        }
    }
}
