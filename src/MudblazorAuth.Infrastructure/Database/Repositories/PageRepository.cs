using Microsoft.EntityFrameworkCore;
using MudblazorAuth.Domain.Entities;
using MudblazorAuth.Domain.Repositories;

namespace MudblazorAuth.Infrastructure.Database.Repositories
{
	public class PageRepository : IPageReadOnlyRepository
	{
		private readonly ApplicationDbContext _dbContext;

		public PageRepository(ApplicationDbContext dbContext)
		{
			_dbContext = dbContext;
		}
		public async Task<IEnumerable<Domain.Entities.Page>> GetAllByIdProfile(int idProfile)
		{
			var pages = await _dbContext.Pages
					.Include(x => x.ProfilePages)
					.Where(x => x.ProfilePages.Any(p => p.IdProfile == idProfile))
					.Select(x => new Domain.Entities.Page
					{
						Id = x.Id,
						Url = x.Url,
						IsPrivate = x.IsPrivate
					})
					.ToListAsync();

			return pages;
		}


	}
}
