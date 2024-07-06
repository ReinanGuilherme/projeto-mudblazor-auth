using System.Net;

namespace MudblazorAuth.Exception.ExceptionsBase
{
	public class ErrorInvalidLoginException : ExceptionBase
	{
		public ErrorInvalidLoginException() : base(ResourceErrorMessages.USERNAME_OR_PASSWORD_INVALID) {}

		public override int StatusCode => (int)HttpStatusCode.Unauthorized;

		public override List<string> GetErrors()
		{
			return [Message];
		}
	}
}
