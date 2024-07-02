namespace MudblazorAuth.Exception.ExceptionsBase
{
    public abstract class ExceptionBase : SystemException
    {
        protected ExceptionBase(string message) : base(message){}

        public abstract int StatusCode { get; }
        public abstract List<string> GetErrors();
    }
}
