namespace DNP.Core.Models;

public class PrinterInfo
{
    public string Name { get; set; } = string.Empty;
    
    public string DriverName { get; set; } = string.Empty;
    
    public string PortName { get; set; } = string.Empty;
    
    public bool IsOnline { get; set; }
    
    public bool IsDefault { get; set; }
    
    public string Status { get; set; } = string.Empty;
}
