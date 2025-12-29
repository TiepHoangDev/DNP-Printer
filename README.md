# DNP DS-RX1HS Printer SDK

SDK C# để điều khiển máy in ảnh DNP DS-RX1HS qua Windows Print Driver.

## Kiến trúc

### DNP.Core (Library)

SDK chính để điều khiển máy in qua Windows Printing Stack.

**Không có API `CutPaper()`** - Cắt giấy xảy ra tự động khi print job hoàn tất.

### DNP.Form.UI (WinForms Test Tool)

Ứng dụng test để verify các chức năng của SDK.

## Cách hoạt động của Paper Cut

Máy in DNP DS-RX1HS **KHÔNG** cho phép app ra lệnh cắt giấy trực tiếp.

### Khi nào máy cắt giấy?

Máy cắt tự động khi:

1. **Print job hoàn tất** - Tất cả ảnh trong job đã được in
2. **Giấy được đẩy ra** - Dựa trên `PaperSize` đã chọn
3. **Layout hoàn tất** - Nếu `Layout = Double`, phải in đủ 2 ảnh

### Yếu tố quyết định việc cắt

| Setting      | Ảnh hưởng                                        |
| ------------ | ------------------------------------------------ |
| `PaperSize`  | Chiều dài giấy kéo ra (6x4, 6x8, 5x7...)         |
| `Layout`     | Số ảnh trên 1 lần kéo giấy (Single=1, Double=2)  |
| `TwoInchCut` | Có chia nhỏ thành các tờ 2-inch sau khi in không |
| Job boundary | Máy chỉ cắt khi job kết thúc                     |

### Ví dụ

**Ví dụ 1: In 1 ảnh 4x6**

```csharp
var job = new PrintJob
{
    Settings = new PrintJobSettings
    {
        PaperSize = PaperSize.Size_6x4,
        Layout = PrintLayout.Single,
        TwoInchCut = false
    },
    Images = { imageBytes }
};
```

→ Máy in 1 ảnh → đẩy giấy → **cắt 1 lần**

**Ví dụ 2: In 2 ảnh 4x6 trên cùng 1 tờ**

```csharp
var job = new PrintJob
{
    Settings = new PrintJobSettings
    {
        PaperSize = PaperSize.Size_6x4,
        Layout = PrintLayout.Double,
        TwoInchCut = false
    },
    Images = { imageBytes1, imageBytes2 }
};
```

→ Máy in ảnh 1 → in ảnh 2 → đẩy giấy → **cắt 1 lần**

**Ví dụ 3: In 6x8 rồi cắt thành 4 tờ nhỏ**

```csharp
var job = new PrintJob
{
    Settings = new PrintJobSettings
    {
        PaperSize = PaperSize.Size_6x8,
        Layout = PrintLayout.Single,
        TwoInchCut = true  // Chia thành các tờ 2-inch
    },
    Images = { imageBytes }
};
```

→ Máy in ảnh 6x8 → **cắt thành 4 tờ 4x6**

## API Usage

### 1. Khởi tạo printer service

```csharp
IDNPPrinter printer = new DNPPrinter();
```

### 2. Lấy danh sách printers

```csharp
var printers = await printer.GetAvailablePrintersAsync();
foreach (var p in printers)
{
    Console.WriteLine($"{p.Name} - {p.Status}");
}
```

### 3. Tạo print job

```csharp
var job = new PrintJob
{
    Settings = new PrintJobSettings
    {
        PaperSize = PaperSize.Size_6x4,
        Layout = PrintLayout.Single,
        TwoInchCut = false,
        Quality = PrintQuality.Fine_300x600,
        Orientation = Orientation.Portrait,
        ColorMode = ColorMode.Color,
        Copies = 1,
        EnableBorder = false,
        OvercoatFinish = true
    },
    JobName = "MyPrintJob"
};

// Load images
var imageBytes = await File.ReadAllBytesAsync("photo.jpg");
job.Images.Add(imageBytes);
```

### 4. Print

```csharp
await printer.PrintAsync(job, "DNP DS-RX1HS");
// Giấy sẽ tự động được cắt khi job hoàn tất
```

## Print Settings

### PaperSize

- `Size_6x4` - 6x4 inch
- `Size_6x8` - 6x8 inch
- `Size_5x7` - 5x7 inch
- `Size_4x6` - 4x6 inch
- `Size_6x9` - 6x9 inch

### PrintLayout

- `Single` - 1 ảnh
- `Double` - 2 ảnh (yêu cầu đúng 2 images trong job)

### PrintQuality

- `Standard_300x300`
- `Fine_300x600` (recommended)
- `SuperFine_600x600`

### Orientation

- `Portrait`
- `Landscape`

### ColorMode

- `Color`
- `Monochrome`

## Lưu ý quan trọng

### ❌ KHÔNG làm

```csharp
// KHÔNG có API này
printer.CutPaper(); // ❌ Không tồn tại
```

### ✅ NÊN làm

```csharp
// Thiết kế job đúng để máy tự cắt
var job = new PrintJob
{
    Settings = new PrintJobSettings
    {
        PaperSize = PaperSize.Size_6x4,
        Layout = PrintLayout.Double,
        TwoInchCut = false
    },
    Images = { img1, img2 } // Đúng 2 ảnh cho Double layout
};

await printer.PrintAsync(job, printerName);
// Máy sẽ tự động cắt khi in xong 2 ảnh
```

## Requirements

- .NET 8.0
- Windows 11
- DNP DS-RX1HS Printer Driver installed

## Build

```powershell
dotnet build DNP.Core\DNP.Core.csproj
dotnet build DNP.Form.UI\DNP.Form.UI.csproj
```

## Run Test Tool

```powershell
dotnet run --project DNP.Form.UI\DNP.Form.UI.csproj
```
