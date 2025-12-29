using System.Drawing;
using System.Drawing.Printing;
using System.Runtime.InteropServices;
using DNP.Core.Enums;
using DNP.Core.Exceptions;
using DNP.Core.Interfaces;
using DNP.Core.Models;

namespace DNP.Core.Services;

public class DNPPrinter : IDNPPrinter
{
    public async Task<List<PrinterInfo>> GetAvailablePrintersAsync()
    {
        return await Task.Run(() =>
        {
            var printers = new List<PrinterInfo>();
            
            foreach (string printerName in PrinterSettings.InstalledPrinters)
            {
                try
                {
                    var ps = new PrinterSettings { PrinterName = printerName };
                    
                    printers.Add(new PrinterInfo
                    {
                        Name = printerName,
                        IsOnline = ps.IsValid,
                        IsDefault = ps.IsDefaultPrinter,
                        Status = ps.IsValid ? "Ready" : "Offline"
                    });
                }
                catch
                {
                }
            }
            
            return printers;
        });
    }

    public async Task<PrinterInfo> GetPrinterInfoAsync(string printerName)
    {
        return await Task.Run(() =>
        {
            var ps = new PrinterSettings { PrinterName = printerName };
            
            if (!ps.IsValid)
                throw new PrinterNotFoundException(printerName);

            return new PrinterInfo
            {
                Name = printerName,
                IsOnline = ps.IsValid,
                IsDefault = ps.IsDefaultPrinter,
                Status = ps.IsValid ? "Ready" : "Offline"
            };
        });
    }

    public bool IsPrinterOnline(string printerName)
    {
        try
        {
            var ps = new PrinterSettings { PrinterName = printerName };
            return ps.IsValid;
        }
        catch
        {
            return false;
        }
    }

    public async Task PrintAsync(PrintJob job, string printerName)
    {
        if (job.Images == null || job.Images.Count == 0)
            throw new PrintJobException("No images provided for printing");

        if (job.Settings.Layout == PrintLayout.Double && job.Images.Count != 2)
            throw new PrintJobException($"Layout is set to Double but {job.Images.Count} images provided. Expected 2 images.");

        await Task.Run(() =>
        {
            using var printDoc = new PrintDocument();
            printDoc.PrinterSettings.PrinterName = printerName;

            if (!printDoc.PrinterSettings.IsValid)
                throw new PrinterNotFoundException(printerName);

            ApplyPrintSettings(printDoc, job.Settings);

            var imageIndex = 0;
            var images = job.Images.Select(imgBytes =>
            {
                using var ms = new MemoryStream(imgBytes);
                return new Bitmap(ms);
            }).ToList();

            try
            {
                printDoc.PrintPage += (sender, e) =>
                {
                    if (imageIndex >= images.Count || e.Graphics == null)
                    {
                        e.HasMorePages = false;
                        return;
                    }

                    var img = images[imageIndex];
                    
                    if (job.Settings.Layout == PrintLayout.Double && imageIndex == 0)
                    {
                        DrawDoubleLayout(e.Graphics, images[0], images[1], e.PageBounds);
                        imageIndex = 2;
                    }
                    else
                    {
                        e.Graphics.DrawImage(img, e.PageBounds);
                        imageIndex++;
                    }

                    e.HasMorePages = imageIndex < images.Count;
                };

                printDoc.DocumentName = job.JobName ?? "DNP Print Job";
                printDoc.Print();
            }
            finally
            {
                foreach (var img in images)
                {
                    img.Dispose();
                }
            }
        });
    }

    private void ApplyPrintSettings(PrintDocument printDoc, PrintJobSettings settings)
    {
        printDoc.DefaultPageSettings.Landscape = settings.Orientation == Enums.Orientation.Landscape;
        
        printDoc.DefaultPageSettings.Color = settings.ColorMode == Enums.ColorMode.Color;
        
        printDoc.PrinterSettings.Copies = (short)settings.Copies;

        var paperSize = GetPaperSize(settings.PaperSize);
        if (paperSize != null)
        {
            printDoc.DefaultPageSettings.PaperSize = paperSize;
        }
    }

    private System.Drawing.Printing.PaperSize? GetPaperSize(Enums.PaperSize size)
    {
        var paperName = size switch
        {
            Enums.PaperSize.Size_6x4 => "6x4",
            Enums.PaperSize.Size_6x8 => "6x8",
            Enums.PaperSize.Size_5x7 => "5x7",
            Enums.PaperSize.Size_4x6 => "4x6",
            Enums.PaperSize.Size_6x9 => "6x9",
            _ => null
        };

        if (paperName == null)
            return null;

        var ps = new PrinterSettings();
        foreach (System.Drawing.Printing.PaperSize paper in ps.PaperSizes)
        {
            if (paper.PaperName.Contains(paperName, StringComparison.OrdinalIgnoreCase))
                return paper;
        }

        return null;
    }

    private void DrawDoubleLayout(Graphics g, Image img1, Image img2, Rectangle bounds)
    {
        var halfHeight = bounds.Height / 2;
        
        var rect1 = new Rectangle(bounds.X, bounds.Y, bounds.Width, halfHeight);
        g.DrawImage(img1, rect1);
        
        var rect2 = new Rectangle(bounds.X, bounds.Y + halfHeight, bounds.Width, halfHeight);
        g.DrawImage(img2, rect2);
    }
}
