using MudblazorAuth.Domain.Entities;

namespace MudblazorAuth.Domain.Repositories
{
    public interface IAccountWriteOnlyRepository
    {
        Task<long> Add(Account account);
        Task Remove(Account account);
    }
}
