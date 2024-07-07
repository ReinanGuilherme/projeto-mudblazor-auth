using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MudblazorAuth.Domain.Repositories;
using MudblazorAuth.Domain.Security.Cryptography;
using MudblazorAuth.Domain.Security.Tokens;
using MudblazorAuth.Infrastructure.Database;
using MudblazorAuth.Infrastructure.Database.Repositories;
using MudblazorAuth.Infrastructure.Security.Cryptography;

namespace MudblazorAuth.Infrastructure
{
	public static class DependencyInjectionExtension
	{
		public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
		{
			AddDbContext(services, configuration);
			AddRepositories(services);
            AddSecurity(services, configuration);
		}
        private static void AddSecurity(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICryptography, Cryptography>();

            var expirationTimeMinutes = configuration.GetValue<uint>("Settings:Jwt:ExpiresMinutes");
            var signingKey = configuration.GetValue<string>("Settings:Jwt:SigningKey");
            services.AddScoped<IToken>(config => new Security.Tokens.Token(expirationTimeMinutes, signingKey!));
        }

        private static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
		{
			var connectionString = configuration.GetConnectionString("Connection");
			services.AddDbContext<ApplicationDbContext>(options =>
				options.UseSqlServer(connectionString));
		}
		private static void AddRepositories(IServiceCollection services)
		{
			services.AddScoped<IUnitOfWork, UnitOfWork>();
			services.AddScoped<IAccountWriteOnlyRepository, AccountRepository>();
			services.AddScoped<IAccountReadOnlyRepository, AccountRepository>();
			services.AddScoped<IPageReadOnlyRepository, PageRepository>();
		}
	}
}
