namespace DNP.Core.Exceptions;

public class DNPPrinterException : Exception
{
    public DNPPrinterException(string message) : base(message)
    {
    }

    public DNPPrinterException(string message, Exception innerException) 
        : base(message, innerException)
    {
    }
}
