
using AutoMapper;
using MudblazorAuth.Communication.Responses;
using MudblazorAuth.Domain.Repositories;

namespace MudblazorAuth.Application.UseCases.Account.GetAllUsers
{
	internal class AccountGetAllUsersUseCase : IAccountGetAllUsersUseCase
	{
		private readonly IAccountReadOnlyRepository _acccountReadOnlyRepository;
		private readonly IMapper _mapper;

		public AccountGetAllUsersUseCase(IAccountReadOnlyRepository acccountReadOnlyRepository, IMapper mapper)
		{
			_acccountReadOnlyRepository = acccountReadOnlyRepository;
			_mapper = mapper;
		}

		public async Task<IEnumerable<ResponseAccountGetAllUsers>?> Execute()
		{
			//idProfile 2 represents the user profile
			var resultGetAll = await _acccountReadOnlyRepository.GetAllByIdProfile(2);

			var response = _mapper.Map<IEnumerable<ResponseAccountGetAllUsers>>(resultGetAll);

			return response;
		}
	}
}
