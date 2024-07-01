using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MudblazorAuth.Domain.Repositories;
using MudblazorAuth.Infrastructure.Database;
using MudblazorAuth.Infrastructure.Database.Repositories;

namespace MudblazorAuth.Infrastructure
{
	public static class DependencyInjectionExtension
	{
		public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
		{
			AddDbContext(services, configuration);
			AddRepositories(services);
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
		}
	}
}
