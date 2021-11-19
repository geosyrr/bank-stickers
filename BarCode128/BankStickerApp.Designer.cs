
namespace BarCode128
{
    partial class BankStickerApp
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SelectBankLabel = new System.Windows.Forms.Label();
            this.BankCodeLabel = new System.Windows.Forms.Label();
            this.VoucherNoLabel = new System.Windows.Forms.Label();
            this.QuantinyNoLabel = new System.Windows.Forms.Label();
            this.SelectBank = new System.Windows.Forms.ComboBox();
            this.VoucherNo = new System.Windows.Forms.TextBox();
            this.CodeOfBank = new System.Windows.Forms.TextBox();
            this.quantityNo = new System.Windows.Forms.NumericUpDown();
            this.SelectBankError = new System.Windows.Forms.Label();
            this.SelectBankCodeError = new System.Windows.Forms.Label();
            this.Print = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.quantityNo)).BeginInit();
            this.SuspendLayout();
            // 
            // SelectBankLabel
            // 
            this.SelectBankLabel.AutoSize = true;
            this.SelectBankLabel.Location = new System.Drawing.Point(51, 40);
            this.SelectBankLabel.Name = "SelectBankLabel";
            this.SelectBankLabel.Size = new System.Drawing.Size(97, 13);
            this.SelectBankLabel.TabIndex = 0;
            this.SelectBankLabel.Text = "Επιλογή Τράπεζας";
            // 
            // BankCodeLabel
            // 
            this.BankCodeLabel.AutoSize = true;
            this.BankCodeLabel.Location = new System.Drawing.Point(51, 94);
            this.BankCodeLabel.Name = "BankCodeLabel";
            this.BankCodeLabel.Size = new System.Drawing.Size(81, 13);
            this.BankCodeLabel.TabIndex = 1;
            this.BankCodeLabel.Text = "Κωδ. Υποκ/τος";
            // 
            // VoucherNoLabel
            // 
            this.VoucherNoLabel.AutoSize = true;
            this.VoucherNoLabel.Location = new System.Drawing.Point(51, 147);
            this.VoucherNoLabel.Name = "VoucherNoLabel";
            this.VoucherNoLabel.Size = new System.Drawing.Size(26, 13);
            this.VoucherNoLabel.TabIndex = 2;
            this.VoucherNoLabel.Text = "Α/Α";
            // 
            // QuantinyNoLabel
            // 
            this.QuantinyNoLabel.AutoSize = true;
            this.QuantinyNoLabel.Location = new System.Drawing.Point(51, 190);
            this.QuantinyNoLabel.Name = "QuantinyNoLabel";
            this.QuantinyNoLabel.Size = new System.Drawing.Size(58, 13);
            this.QuantinyNoLabel.TabIndex = 3;
            this.QuantinyNoLabel.Text = "Ποσότητα";
            // 
            // SelectBank
            // 
            this.SelectBank.FormattingEnabled = true;
            this.SelectBank.Items.AddRange(new object[] {
            "ALPHA BANK",
            "EUROBANK",
            "EGNATIA TRAPEZA"});
            this.SelectBank.Location = new System.Drawing.Point(165, 37);
            this.SelectBank.Name = "SelectBank";
            this.SelectBank.Size = new System.Drawing.Size(178, 21);
            this.SelectBank.TabIndex = 4;
            // 
            // VoucherNo
            // 
            this.VoucherNo.Location = new System.Drawing.Point(165, 140);
            this.VoucherNo.Name = "VoucherNo";
            this.VoucherNo.Size = new System.Drawing.Size(178, 20);
            this.VoucherNo.TabIndex = 6;
            // 
            // CodeOfBank
            // 
            this.CodeOfBank.Location = new System.Drawing.Point(165, 91);
            this.CodeOfBank.MaxLength = 4;
            this.CodeOfBank.Name = "CodeOfBank";
            this.CodeOfBank.Size = new System.Drawing.Size(178, 20);
            this.CodeOfBank.TabIndex = 8;
            // 
            // quantityNo
            // 
            this.quantityNo.Location = new System.Drawing.Point(165, 188);
            this.quantityNo.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.quantityNo.Name = "quantityNo";
            this.quantityNo.Size = new System.Drawing.Size(178, 20);
            this.quantityNo.TabIndex = 9;
            this.quantityNo.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // SelectBankError
            // 
            this.SelectBankError.AutoSize = true;
            this.SelectBankError.Location = new System.Drawing.Point(171, 21);
            this.SelectBankError.Name = "SelectBankError";
            this.SelectBankError.Size = new System.Drawing.Size(10, 13);
            this.SelectBankError.TabIndex = 10;
            this.SelectBankError.Text = " ";
            // 
            // SelectBankCodeError
            // 
            this.SelectBankCodeError.AutoSize = true;
            this.SelectBankCodeError.Location = new System.Drawing.Point(171, 75);
            this.SelectBankCodeError.Name = "SelectBankCodeError";
            this.SelectBankCodeError.Size = new System.Drawing.Size(10, 13);
            this.SelectBankCodeError.TabIndex = 11;
            this.SelectBankCodeError.Text = " ";
            // 
            // Print
            // 
            this.Print.Location = new System.Drawing.Point(174, 284);
            this.Print.Name = "Print";
            this.Print.Size = new System.Drawing.Size(156, 34);
            this.Print.TabIndex = 13;
            this.Print.Text = "Εκτύπωση";
            this.Print.UseVisualStyleBackColor = true;
            this.Print.Click += new System.EventHandler(this.Print_Click_1);
            // 
            // BankStickerApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 361);
            this.Controls.Add(this.Print);
            this.Controls.Add(this.SelectBankCodeError);
            this.Controls.Add(this.SelectBankError);
            this.Controls.Add(this.quantityNo);
            this.Controls.Add(this.CodeOfBank);
            this.Controls.Add(this.VoucherNo);
            this.Controls.Add(this.SelectBank);
            this.Controls.Add(this.QuantinyNoLabel);
            this.Controls.Add(this.VoucherNoLabel);
            this.Controls.Add(this.BankCodeLabel);
            this.Controls.Add(this.SelectBankLabel);
            this.Name = "BankStickerApp";
            this.Text = "Πρόγραμμα Εκτύπωσης Sticker Τραπεζών";
            ((System.ComponentModel.ISupportInitialize)(this.quantityNo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label SelectBankLabel;
        private System.Windows.Forms.Label BankCodeLabel;
        private System.Windows.Forms.Label VoucherNoLabel;
        private System.Windows.Forms.Label QuantinyNoLabel;
        private System.Windows.Forms.ComboBox SelectBank;
        private System.Windows.Forms.TextBox VoucherNo;
        private System.Windows.Forms.TextBox CodeOfBank;
        private System.Windows.Forms.NumericUpDown quantityNo;
        private System.Windows.Forms.Label SelectBankError;
        private System.Windows.Forms.Label SelectBankCodeError;
        private System.Windows.Forms.Button Print;
    }
}

