namespace MudblazorAuth.Domain.Repositories
{
	public interface IPageReadOnlyRepository
	{
		Task<IEnumerable<Domain.Entities.Page>> GetAllByIdProfile(int idProfile);
	}
}
