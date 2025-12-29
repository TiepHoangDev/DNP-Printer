namespace DNP.Core.Exceptions;

public class PrintJobException : DNPPrinterException
{
    public PrintJobException(string message) : base(message)
    {
    }

    public PrintJobException(string message, Exception innerException) 
        : base(message, innerException)
    {
    }
}
