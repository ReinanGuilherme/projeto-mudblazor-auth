namespace MudblazorAuth.Communication.Responses
{
	public class ResponseGetAllByIdProfile
	{
		public long Id { get; set; }
		public string Url { get; set; } = string.Empty;
		public bool IsPrivate { get; set; }
	}
}
