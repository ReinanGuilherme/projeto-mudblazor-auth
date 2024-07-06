using Microsoft.EntityFrameworkCore;
using MudblazorAuth.Domain.Entities;
using MudblazorAuth.Domain.Repositories;

namespace MudblazorAuth.Infrastructure.Database.Repositories
{
    internal class AccountRepository : IAccountWriteOnlyRepository, IAccountReadOnlyRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public AccountRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<long> Add(Account account)
        {
            await _dbContext.Accounts.AddAsync(account);

            return account.Id;
        }		

		public async Task<Account?> GetByUsername(string username)
        {
            return await _dbContext.Accounts.AsNoTracking().FirstOrDefaultAsync(account => account.Username.Equals(username));
        }

		public async Task<IEnumerable<Account>?> GetAllByIdProfile(int idProfile)
		{
			return await _dbContext.Accounts.Where(x => x.IdProfile == idProfile).AsNoTracking().ToListAsync();
		}

		public async Task Remove(Account account)
		{
			_dbContext.Accounts.Remove(account);
            await Task.CompletedTask;
		}
	}
}
