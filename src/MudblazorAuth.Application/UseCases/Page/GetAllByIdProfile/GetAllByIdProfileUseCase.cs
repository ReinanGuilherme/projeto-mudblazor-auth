
using AutoMapper;
using MudblazorAuth.Communication.Responses;
using MudblazorAuth.Domain.Repositories;

namespace MudblazorAuth.Application.UseCases.Page.GetAllByIdProfile
{
	internal class GetAllByIdProfileUseCase : IGetAllByIdProfileUseCase
	{
		private readonly IPageReadOnlyRepository _pageReadOnlyRepository;
		private readonly IMapper _mapper;

		public GetAllByIdProfileUseCase(IPageReadOnlyRepository pageReadOnlyRepository, IMapper mapper)
		{
			_pageReadOnlyRepository = pageReadOnlyRepository;
			_mapper = mapper;
		}

		public async Task<IEnumerable<ResponseGetAllByIdProfile>> Execute()
		{
			var resultGetAllByIdProfile = await _pageReadOnlyRepository.GetAllByIdProfile(2);

			var response = _mapper.Map<IEnumerable<ResponseGetAllByIdProfile>>(resultGetAllByIdProfile);

			return response;
		}
	}
}
