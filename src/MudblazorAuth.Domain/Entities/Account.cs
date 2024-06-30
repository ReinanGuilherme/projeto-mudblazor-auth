using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MudblazorAuth.Domain.Entities
{
	public class Account
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public string Username { get; set; } = string.Empty;
		public string Password { get; set; } = string.Empty;
		[ForeignKey("Profile")]
		public int IdProfile { get; set; }
		public Profile Profile { get; set; } = default!;
	}
}
