using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MudblazorAuth.Domain.Entities
{
	public class ProfilePage
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public long Id { get; set; }

		[ForeignKey("Profile")]
		public long IdProfile { get; set; }

		[ForeignKey("Page")]
		public long IdPage { get; set; }

		public Profile Profile { get; set; } = default!;
		public Page Page { get; set; } = default!;
	}
}
