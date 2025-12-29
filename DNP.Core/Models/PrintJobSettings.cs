using DNP.Core.Enums;

namespace DNP.Core.Models;

public class PrintJobSettings
{
    public PaperSize PaperSize { get; set; } = PaperSize.Size_6x4;
    
    public PrintLayout Layout { get; set; } = PrintLayout.Single;
    
    public bool TwoInchCut { get; set; } = false;
    
    public PrintQuality Quality { get; set; } = PrintQuality.Fine_300x600;
    
    public Enums.Orientation Orientation { get; set; } = Enums.Orientation.Portrait;
    
    public ColorMode ColorMode { get; set; } = ColorMode.Color;
    
    public int Copies { get; set; } = 1;
    
    public bool EnableBorder { get; set; } = false;
    
    public bool OvercoatFinish { get; set; } = true;
}
