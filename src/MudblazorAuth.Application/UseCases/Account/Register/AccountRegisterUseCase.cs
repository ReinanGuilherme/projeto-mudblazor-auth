using AutoMapper;
using FluentValidation.Results;
using MudblazorAuth.Communication.Requests;
using MudblazorAuth.Communication.Responses;
using MudblazorAuth.Domain.Repositories;
using MudblazorAuth.Domain.Security.Cryptography;
using MudblazorAuth.Domain.Security.Tokens;
using MudblazorAuth.Exception;
using MudblazorAuth.Exception.ExceptionsBase;

namespace MudblazorAuth.Application.UseCases.Account.Register
{
    internal class AccountRegisterUseCase : IAccountRegisterUseCase
    {
        private readonly IAccountWriteOnlyRepository _acccountWriteOnlyRepository;
        private readonly IAccountReadOnlyRepository _acccountReadOnlyRepository;
        private readonly IMapper _mapper;
        private readonly ICryptography _cryptography;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IToken _token;

        public AccountRegisterUseCase(IAccountWriteOnlyRepository acccountWriteOnlyRepository, IMapper mapper, ICryptography cryptography, IUnitOfWork unitOfWork, IToken token, IAccountReadOnlyRepository acccountReadOnlyRepository)
        {
            _acccountWriteOnlyRepository = acccountWriteOnlyRepository;
            _mapper = mapper;
            _cryptography = cryptography;
            _unitOfWork = unitOfWork;
            _token = token;
            _acccountReadOnlyRepository = acccountReadOnlyRepository;
        }

        public async Task<ResponseAccountRegister> Execute(RequestAccountRegister request)
        {
            await Validate(request);

            var account = _mapper.Map<Domain.Entities.Account>(request);
            account.Password = _cryptography.Encrypt(request.Password);

            await _acccountWriteOnlyRepository.Add(account);
            await _unitOfWork.Commit();

            var response = new ResponseAccountRegister()
            {
                Token = _token.Generate(account)
            };

            return response;
        }

        private async Task Validate(RequestAccountRegister request)
        {
            var resultValidate = new AccountRegisterValidator().Validate(request);

            var resultGetByUsername = await _acccountReadOnlyRepository.GetByUsername(request.Username);
            if (resultGetByUsername is not null)
            {
                resultValidate.Errors.Add(new ValidationFailure(string.Empty, ResourceErrorMessages.ACCOUNT_USERNAME_ALREADY_REGISTERED));
            }

            if (resultValidate.IsValid is false)
            {
                var errorMessages = resultValidate.Errors.Select(f => f.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}
