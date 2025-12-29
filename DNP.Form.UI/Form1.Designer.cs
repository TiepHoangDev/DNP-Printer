namespace DNP.Form.UI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            grpPrinter = new GroupBox();
            btnRefreshPrinters = new Button();
            cboPrinters = new ComboBox();
            lblPrinter = new Label();
            grpSettings = new GroupBox();
            chkOvercoat = new CheckBox();
            chkBorder = new CheckBox();
            numCopies = new NumericUpDown();
            lblCopies = new Label();
            cboColorMode = new ComboBox();
            lblColorMode = new Label();
            cboOrientation = new ComboBox();
            lblOrientation = new Label();
            cboQuality = new ComboBox();
            lblQuality = new Label();
            chkTwoInchCut = new CheckBox();
            cboLayout = new ComboBox();
            lblLayout = new Label();
            cboPaperSize = new ComboBox();
            lblPaperSize = new Label();
            grpImages = new GroupBox();
            btnClearImages = new Button();
            btnAddImage = new Button();
            lstImages = new ListBox();
            btnPrint = new Button();
            txtLog = new TextBox();
            grpPrinter.SuspendLayout();
            grpSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numCopies).BeginInit();
            grpImages.SuspendLayout();
            SuspendLayout();
            // 
            // grpPrinter
            // 
            grpPrinter.Controls.Add(btnRefreshPrinters);
            grpPrinter.Controls.Add(cboPrinters);
            grpPrinter.Controls.Add(lblPrinter);
            grpPrinter.Location = new Point(12, 12);
            grpPrinter.Name = "grpPrinter";
            grpPrinter.Size = new Size(400, 80);
            grpPrinter.TabIndex = 0;
            grpPrinter.TabStop = false;
            grpPrinter.Text = "Printer Selection";
            // 
            // btnRefreshPrinters
            // 
            btnRefreshPrinters.Location = new Point(310, 40);
            btnRefreshPrinters.Name = "btnRefreshPrinters";
            btnRefreshPrinters.Size = new Size(75, 23);
            btnRefreshPrinters.TabIndex = 2;
            btnRefreshPrinters.Text = "Refresh";
            btnRefreshPrinters.UseVisualStyleBackColor = true;
            // 
            // cboPrinters
            // 
            cboPrinters.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPrinters.FormattingEnabled = true;
            cboPrinters.Location = new Point(70, 40);
            cboPrinters.Name = "cboPrinters";
            cboPrinters.Size = new Size(230, 23);
            cboPrinters.TabIndex = 1;
            // 
            // lblPrinter
            // 
            lblPrinter.AutoSize = true;
            lblPrinter.Location = new Point(15, 43);
            lblPrinter.Name = "lblPrinter";
            lblPrinter.Size = new Size(47, 15);
            lblPrinter.TabIndex = 0;
            lblPrinter.Text = "Printer:";
            // 
            // grpSettings
            // 
            grpSettings.Controls.Add(chkOvercoat);
            grpSettings.Controls.Add(chkBorder);
            grpSettings.Controls.Add(numCopies);
            grpSettings.Controls.Add(lblCopies);
            grpSettings.Controls.Add(cboColorMode);
            grpSettings.Controls.Add(lblColorMode);
            grpSettings.Controls.Add(cboOrientation);
            grpSettings.Controls.Add(lblOrientation);
            grpSettings.Controls.Add(cboQuality);
            grpSettings.Controls.Add(lblQuality);
            grpSettings.Controls.Add(chkTwoInchCut);
            grpSettings.Controls.Add(cboLayout);
            grpSettings.Controls.Add(lblLayout);
            grpSettings.Controls.Add(cboPaperSize);
            grpSettings.Controls.Add(lblPaperSize);
            grpSettings.Location = new Point(12, 98);
            grpSettings.Name = "grpSettings";
            grpSettings.Size = new Size(400, 280);
            grpSettings.TabIndex = 1;
            grpSettings.TabStop = false;
            grpSettings.Text = "Print Settings";
            // 
            // chkOvercoat
            // 
            chkOvercoat.AutoSize = true;
            chkOvercoat.Checked = true;
            chkOvercoat.CheckState = CheckState.Checked;
            chkOvercoat.Location = new Point(220, 245);
            chkOvercoat.Name = "chkOvercoat";
            chkOvercoat.Size = new Size(115, 19);
            chkOvercoat.TabIndex = 14;
            chkOvercoat.Text = "Overcoat Finish";
            chkOvercoat.UseVisualStyleBackColor = true;
            // 
            // chkBorder
            // 
            chkBorder.AutoSize = true;
            chkBorder.Location = new Point(220, 220);
            chkBorder.Name = "chkBorder";
            chkBorder.Size = new Size(61, 19);
            chkBorder.TabIndex = 13;
            chkBorder.Text = "Border";
            chkBorder.UseVisualStyleBackColor = true;
            // 
            // numCopies
            // 
            numCopies.Location = new Point(90, 215);
            numCopies.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            numCopies.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numCopies.Name = "numCopies";
            numCopies.Size = new Size(100, 23);
            numCopies.TabIndex = 12;
            numCopies.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblCopies
            // 
            lblCopies.AutoSize = true;
            lblCopies.Location = new Point(15, 217);
            lblCopies.Name = "lblCopies";
            lblCopies.Size = new Size(48, 15);
            lblCopies.TabIndex = 11;
            lblCopies.Text = "Copies:";
            // 
            // cboColorMode
            // 
            cboColorMode.DropDownStyle = ComboBoxStyle.DropDownList;
            cboColorMode.FormattingEnabled = true;
            cboColorMode.Location = new Point(90, 180);
            cboColorMode.Name = "cboColorMode";
            cboColorMode.Size = new Size(295, 23);
            cboColorMode.TabIndex = 10;
            // 
            // lblColorMode
            // 
            lblColorMode.AutoSize = true;
            lblColorMode.Location = new Point(15, 183);
            lblColorMode.Name = "lblColorMode";
            lblColorMode.Size = new Size(74, 15);
            lblColorMode.TabIndex = 9;
            lblColorMode.Text = "Color Mode:";
            // 
            // cboOrientation
            // 
            cboOrientation.DropDownStyle = ComboBoxStyle.DropDownList;
            cboOrientation.FormattingEnabled = true;
            cboOrientation.Location = new Point(90, 145);
            cboOrientation.Name = "cboOrientation";
            cboOrientation.Size = new Size(295, 23);
            cboOrientation.TabIndex = 8;
            // 
            // lblOrientation
            // 
            lblOrientation.AutoSize = true;
            lblOrientation.Location = new Point(15, 148);
            lblOrientation.Name = "lblOrientation";
            lblOrientation.Size = new Size(72, 15);
            lblOrientation.TabIndex = 7;
            lblOrientation.Text = "Orientation:";
            // 
            // cboQuality
            // 
            cboQuality.DropDownStyle = ComboBoxStyle.DropDownList;
            cboQuality.FormattingEnabled = true;
            cboQuality.Location = new Point(90, 110);
            cboQuality.Name = "cboQuality";
            cboQuality.Size = new Size(295, 23);
            cboQuality.TabIndex = 6;
            // 
            // lblQuality
            // 
            lblQuality.AutoSize = true;
            lblQuality.Location = new Point(15, 113);
            lblQuality.Name = "lblQuality";
            lblQuality.Size = new Size(51, 15);
            lblQuality.TabIndex = 5;
            lblQuality.Text = "Quality:";
            // 
            // chkTwoInchCut
            // 
            chkTwoInchCut.AutoSize = true;
            chkTwoInchCut.Location = new Point(220, 79);
            chkTwoInchCut.Name = "chkTwoInchCut";
            chkTwoInchCut.Size = new Size(94, 19);
            chkTwoInchCut.TabIndex = 4;
            chkTwoInchCut.Text = "2-inch Cut";
            chkTwoInchCut.UseVisualStyleBackColor = true;
            // 
            // cboLayout
            // 
            cboLayout.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLayout.FormattingEnabled = true;
            cboLayout.Location = new Point(90, 75);
            cboLayout.Name = "cboLayout";
            cboLayout.Size = new Size(100, 23);
            cboLayout.TabIndex = 3;
            // 
            // lblLayout
            // 
            lblLayout.AutoSize = true;
            lblLayout.Location = new Point(15, 78);
            lblLayout.Name = "lblLayout";
            lblLayout.Size = new Size(47, 15);
            lblLayout.TabIndex = 2;
            lblLayout.Text = "Layout:";
            // 
            // cboPaperSize
            // 
            cboPaperSize.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPaperSize.FormattingEnabled = true;
            cboPaperSize.Location = new Point(90, 40);
            cboPaperSize.Name = "cboPaperSize";
            cboPaperSize.Size = new Size(295, 23);
            cboPaperSize.TabIndex = 1;
            // 
            // lblPaperSize
            // 
            lblPaperSize.AutoSize = true;
            lblPaperSize.Location = new Point(15, 43);
            lblPaperSize.Name = "lblPaperSize";
            lblPaperSize.Size = new Size(65, 15);
            lblPaperSize.TabIndex = 0;
            lblPaperSize.Text = "Paper Size:";
            // 
            // grpImages
            // 
            grpImages.Controls.Add(btnClearImages);
            grpImages.Controls.Add(btnAddImage);
            grpImages.Controls.Add(lstImages);
            grpImages.Location = new Point(418, 12);
            grpImages.Name = "grpImages";
            grpImages.Size = new Size(370, 366);
            grpImages.TabIndex = 2;
            grpImages.TabStop = false;
            grpImages.Text = "Images";
            // 
            // btnClearImages
            // 
            btnClearImages.Location = new Point(100, 330);
            btnClearImages.Name = "btnClearImages";
            btnClearImages.Size = new Size(80, 23);
            btnClearImages.TabIndex = 2;
            btnClearImages.Text = "Clear All";
            btnClearImages.UseVisualStyleBackColor = true;
            // 
            // btnAddImage
            // 
            btnAddImage.Location = new Point(10, 330);
            btnAddImage.Name = "btnAddImage";
            btnAddImage.Size = new Size(80, 23);
            btnAddImage.TabIndex = 1;
            btnAddImage.Text = "Add Image";
            btnAddImage.UseVisualStyleBackColor = true;
            // 
            // lstImages
            // 
            lstImages.FormattingEnabled = true;
            lstImages.ItemHeight = 15;
            lstImages.Location = new Point(10, 25);
            lstImages.Name = "lstImages";
            lstImages.Size = new Size(350, 289);
            lstImages.TabIndex = 0;
            // 
            // btnPrint
            // 
            btnPrint.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnPrint.Location = new Point(12, 384);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(400, 50);
            btnPrint.TabIndex = 3;
            btnPrint.Text = "PRINT";
            btnPrint.UseVisualStyleBackColor = true;
            // 
            // txtLog
            // 
            txtLog.Font = new Font("Consolas", 9F);
            txtLog.Location = new Point(12, 440);
            txtLog.Multiline = true;
            txtLog.Name = "txtLog";
            txtLog.ReadOnly = true;
            txtLog.ScrollBars = ScrollBars.Vertical;
            txtLog.Size = new Size(776, 150);
            txtLog.TabIndex = 4;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 600);
            Controls.Add(txtLog);
            Controls.Add(btnPrint);
            Controls.Add(grpImages);
            Controls.Add(grpSettings);
            Controls.Add(grpPrinter);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "DNP DS-RX1HS Test Tool";
            grpPrinter.ResumeLayout(false);
            grpPrinter.PerformLayout();
            grpSettings.ResumeLayout(false);
            grpSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numCopies).EndInit();
            grpImages.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox grpPrinter;
        private Button btnRefreshPrinters;
        private ComboBox cboPrinters;
        private Label lblPrinter;
        private GroupBox grpSettings;
        private ComboBox cboPaperSize;
        private Label lblPaperSize;
        private ComboBox cboLayout;
        private Label lblLayout;
        private CheckBox chkTwoInchCut;
        private ComboBox cboQuality;
        private Label lblQuality;
        private ComboBox cboOrientation;
        private Label lblOrientation;
        private ComboBox cboColorMode;
        private Label lblColorMode;
        private NumericUpDown numCopies;
        private Label lblCopies;
        private CheckBox chkBorder;
        private CheckBox chkOvercoat;
        private GroupBox grpImages;
        private ListBox lstImages;
        private Button btnAddImage;
        private Button btnClearImages;
        private Button btnPrint;
        private TextBox txtLog;
    }
}
