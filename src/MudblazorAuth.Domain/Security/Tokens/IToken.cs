using MudblazorAuth.Domain.Entities;

namespace MudblazorAuth.Domain.Security.Tokens
{
    public interface IToken
    {
        string Generate(Account account);
    }
}
