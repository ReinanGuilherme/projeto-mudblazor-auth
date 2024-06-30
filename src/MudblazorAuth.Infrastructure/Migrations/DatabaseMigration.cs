using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MudblazorAuth.Infrastructure.Database;

namespace MudblazorAuth.Infrastructure.Migrations
{
	public static class DatabaseMigration
	{
		public async static Task MigrateDatabase(IServiceProvider serviceProvider)
		{
			var dbContext = serviceProvider.GetRequiredService<ApplicationDbContext>();

			await dbContext.Database.MigrateAsync();
		}
	}
}
