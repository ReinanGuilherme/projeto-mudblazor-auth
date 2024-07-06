using MudblazorAuth.Domain.Entities;

namespace MudblazorAuth.Domain.Repositories
{
    public interface IAccountReadOnlyRepository
    {
        Task<Account?> GetByUsername(string username);
        Task<IEnumerable<Account>?> GetAllByIdProfile(int idProfile);
    }
}
