using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MudblazorAuth.Domain.Entities
{
	public class Page
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public long Id { get; set; }

		[Required]
		[MaxLength(255)]
		public string Url { get; set; } = string.Empty;

		[Required]
		public bool IsPrivate { get; set; }

		public ICollection<ProfilePage> ProfilePages { get; set; } = default!;
	}
}
