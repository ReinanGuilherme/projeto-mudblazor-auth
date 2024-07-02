using MudblazorAuth.Domain.Entities;

namespace MudblazorAuth.Domain.Repositories
{
    public interface IAccountReadOnlyRepository
    {
        Task<Account?> GetByUsername(string username);
    }
}
