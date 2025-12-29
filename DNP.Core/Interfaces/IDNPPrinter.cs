using DNP.Core.Models;

namespace DNP.Core.Interfaces;

public interface IDNPPrinter
{
    Task<List<PrinterInfo>> GetAvailablePrintersAsync();
    
    Task PrintAsync(PrintJob job, string printerName);
    
    Task<PrinterInfo> GetPrinterInfoAsync(string printerName);
    
    bool IsPrinterOnline(string printerName);
}
