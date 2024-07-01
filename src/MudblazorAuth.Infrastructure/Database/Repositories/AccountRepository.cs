using MudblazorAuth.Domain.Entities;
using MudblazorAuth.Domain.Repositories;

namespace MudblazorAuth.Infrastructure.Database.Repositories
{
    internal class AccountRepository : IAccountWriteOnlyRepository
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
    }
}
