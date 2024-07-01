namespace MudblazorAuth.Domain.Repositories
{
	public interface IUnitOfWork
	{
        Task Commit();
	}
}
