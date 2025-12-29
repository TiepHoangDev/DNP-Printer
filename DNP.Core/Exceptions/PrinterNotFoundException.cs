namespace DNP.Core.Exceptions;

public class PrinterNotFoundException : DNPPrinterException
{
    public PrinterNotFoundException(string printerName) 
        : base($"Printer '{printerName}' not found")
    {
    }
}
