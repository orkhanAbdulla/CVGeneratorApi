namespace CVGeneratorApp.Api.Common.Exceptions
{
    public class FileFormatException:Exception
    {
        public FileFormatException() : base() { }
        public FileFormatException(string message) : base(message) { }
        public FileFormatException(string message, Exception innerException) : base(message, innerException) { }
    }
}
