using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MudblazorAuth.Domain.Entities
{
	public class Profile
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public long Id { get; set; }

		[Required]
		[MaxLength(255)]
		public string Description { get; set; } = string.Empty;

		public ICollection<Account> Accounts { get; set; } = default!;
		public ICollection<ProfilePage> ProfilePages { get; set; } = default!;
	}
}
