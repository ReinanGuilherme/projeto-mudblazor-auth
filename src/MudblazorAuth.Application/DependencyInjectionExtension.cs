using Microsoft.Extensions.DependencyInjection;
using MudblazorAuth.Application.AutoMapper;
using MudblazorAuth.Application.UseCases.Account.Register;

namespace MudblazorAuth.Application
{
    public static class DependencyInjectionExtension
    {
        public static void AddApllication(this IServiceCollection services)
        {
            AddAutoMapper(services);
            AddUseCases(services);
        }

        private static void AddAutoMapper(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapping));
        }

        private static void AddUseCases(IServiceCollection services)
        {
            services.AddScoped<IAccountRegisterUseCase, AccountRegisterUseCase>();
        }
    }
}
