using DNP.Core.Enums;
using DNP.Core.Interfaces;
using DNP.Core.Models;
using DNP.Core.Services;

namespace DNP.Form.UI
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        private readonly IDNPPrinter _printer;
        private readonly List<string> _imagePaths = new();

        public Form1()
        {
            InitializeComponent();
            _printer = new DNPPrinter();
            InitializeControls();
            LoadPrinters();
        }

        private void InitializeControls()
        {
            cboPaperSize.DataSource = Enum.GetValues(typeof(PaperSize));
            cboLayout.DataSource = Enum.GetValues(typeof(PrintLayout));
            cboQuality.DataSource = Enum.GetValues(typeof(PrintQuality));
            cboOrientation.DataSource = Enum.GetValues(typeof(DNP.Core.Enums.Orientation));
            cboColorMode.DataSource = Enum.GetValues(typeof(ColorMode));

            btnRefreshPrinters.Click += BtnRefreshPrinters_Click;
            btnAddImage.Click += BtnAddImage_Click;
            btnClearImages.Click += BtnClearImages_Click;
            btnPrint.Click += BtnPrint_Click;
            cboLayout.SelectedIndexChanged += CboLayout_SelectedIndexChanged;
        }

        private async void LoadPrinters()
        {
            try
            {
                Log("Loading printers...");
                var printers = await _printer.GetAvailablePrintersAsync();
                
                cboPrinters.DataSource = printers;
                cboPrinters.DisplayMember = "Name";
                
                if (printers.Count > 0)
                {
                    var defaultPrinter = printers.FirstOrDefault(p => p.IsDefault);
                    if (defaultPrinter != null)
                    {
                        cboPrinters.SelectedItem = defaultPrinter;
                    }
                    Log($"Found {printers.Count} printer(s)");
                }
                else
                {
                    Log("No printers found", true);
                }
            }
            catch (Exception ex)
            {
                Log($"Error loading printers: {ex.Message}", true);
            }
        }

        private void BtnRefreshPrinters_Click(object? sender, EventArgs e)
        {
            LoadPrinters();
        }

        private void BtnAddImage_Click(object? sender, EventArgs e)
        {
            using var ofd = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp",
                Multiselect = true
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                foreach (var file in ofd.FileNames)
                {
                    _imagePaths.Add(file);
                    lstImages.Items.Add(Path.GetFileName(file));
                }
                Log($"Added {ofd.FileNames.Length} image(s)");
                ValidateImageCount();
            }
        }

        private void BtnClearImages_Click(object? sender, EventArgs e)
        {
            _imagePaths.Clear();
            lstImages.Items.Clear();
            Log("Cleared all images");
        }

        private async void BtnPrint_Click(object? sender, EventArgs e)
        {
            try
            {
                if (cboPrinters.SelectedItem is not PrinterInfo selectedPrinter)
                {
                    MessageBox.Show("Please select a printer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (_imagePaths.Count == 0)
                {
                    MessageBox.Show("Please add at least one image", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var layout = (PrintLayout)cboLayout.SelectedItem!;
                if (layout == PrintLayout.Double && _imagePaths.Count != 2)
                {
                    MessageBox.Show("Double layout requires exactly 2 images", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                btnPrint.Enabled = false;
                Log("Starting print job...");

                var job = new PrintJob
                {
                    Settings = new PrintJobSettings
                    {
                        PaperSize = (PaperSize)cboPaperSize.SelectedItem!,
                        Layout = layout,
                        TwoInchCut = chkTwoInchCut.Checked,
                        Quality = (PrintQuality)cboQuality.SelectedItem!,
                        Orientation = (DNP.Core.Enums.Orientation)cboOrientation.SelectedItem!,
                        ColorMode = (ColorMode)cboColorMode.SelectedItem!,
                        Copies = (int)numCopies.Value,
                        EnableBorder = chkBorder.Checked,
                        OvercoatFinish = chkOvercoat.Checked
                    },
                    JobName = $"DNP_Print_{DateTime.Now:yyyyMMdd_HHmmss}"
                };

                foreach (var imagePath in _imagePaths)
                {
                    var imageBytes = await File.ReadAllBytesAsync(imagePath);
                    job.Images.Add(imageBytes);
                }

                Log($"Printing to: {selectedPrinter.Name}");
                Log($"Settings: {job.Settings.PaperSize}, {job.Settings.Layout}, Quality: {job.Settings.Quality}");
                Log($"2-inch Cut: {job.Settings.TwoInchCut}, Copies: {job.Settings.Copies}");

                await _printer.PrintAsync(job, selectedPrinter.Name);

                Log("Print job sent successfully!");
                Log("---");
                Log("IMPORTANT: Paper cut will happen automatically when:");
                Log($"  - Print job completes ({job.Images.Count} image(s))");
                Log($"  - Paper is ejected based on {job.Settings.PaperSize}");
                if (job.Settings.TwoInchCut)
                {
                    Log("  - Then divided into 2-inch sections");
                }
                Log("---");

                MessageBox.Show("Print job sent successfully!\n\nPaper will be cut automatically when the job completes.", 
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Log($"Print error: {ex.Message}", true);
                MessageBox.Show($"Print failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnPrint.Enabled = true;
            }
        }

        private void CboLayout_SelectedIndexChanged(object? sender, EventArgs e)
        {
            ValidateImageCount();
        }

        private void ValidateImageCount()
        {
            if (cboLayout.SelectedItem is PrintLayout layout)
            {
                var requiredCount = layout == PrintLayout.Double ? 2 : 1;
                var hasCorrectCount = _imagePaths.Count == requiredCount || _imagePaths.Count == 0;
                
                if (!hasCorrectCount && _imagePaths.Count > 0)
                {
                    Log($"Warning: {layout} layout requires {requiredCount} image(s), but {_imagePaths.Count} selected", true);
                }
            }
        }

        private void Log(string message, bool isError = false)
        {
            var timestamp = DateTime.Now.ToString("HH:mm:ss");
            var prefix = isError ? "[ERROR]" : "[INFO]";
            var logMessage = $"{timestamp} {prefix} {message}";
            
            if (txtLog.InvokeRequired)
            {
                txtLog.Invoke(() => AppendLog(logMessage));
            }
            else
            {
                AppendLog(logMessage);
            }
        }

        private void AppendLog(string message)
        {
            txtLog.AppendText(message + Environment.NewLine);
            txtLog.SelectionStart = txtLog.Text.Length;
            txtLog.ScrollToCaret();
        }
    }
}
