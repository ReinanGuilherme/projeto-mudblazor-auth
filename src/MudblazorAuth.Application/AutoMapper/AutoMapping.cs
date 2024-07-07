using AutoMapper;
using MudblazorAuth.Communication.Requests.Account;
using MudblazorAuth.Communication.Responses;
using MudblazorAuth.Domain.Entities;
using AM = AutoMapper;


namespace MudblazorAuth.Application.AutoMapper
{
    public class AutoMapping : AM.Profile
    {
        public AutoMapping()
        {
            RequestToEntity();
            EntityToResponse();
        }

        private void RequestToEntity()
        {
            CreateMap<RequestAccountRegister, Account>()
                .ForMember(dest => dest.Password, config => config.Ignore());
        }

        private void EntityToResponse()
        {
			CreateMap<Account, ResponseAccountGetAllUsers>();
			CreateMap<Page, ResponseGetAllByIdProfile>();
		}
    }
}
