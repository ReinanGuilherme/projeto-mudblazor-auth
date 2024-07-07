using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MudblazorAuth.Domain.Entities
{
	public class Page
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public long Id { get; set; }

		public string Url { get; set; } = string.Empty;

        [Column("is_private")]
        public bool IsPrivate { get; set; }

		public virtual ICollection<ProfilePage> ProfilePages { get; set; } = default!;
	}
}
