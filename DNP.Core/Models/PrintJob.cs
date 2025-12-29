namespace DNP.Core.Models;

public class PrintJob
{
    public PrintJobSettings Settings { get; set; } = new();
    
    public List<byte[]> Images { get; set; } = new();
    
    public string? JobName { get; set; }
}
