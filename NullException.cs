namespace DebtRegister
{
    internal class NullException : Exception
    {
        const string message = "Input is null !!!";

        public NullException() : base(message)
        { }
        public NullException(string errorMessage) : base($"Error : {message}, {errorMessage}") { }
        public NullException(string infoMessage, Exception innerException) : base(String.Format($"Error : {message}, {infoMessage}. {innerException}"))
        { }
    }
}
