namespace wineshopnew
{
    partial class invoice_scan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(invoice_scan));
            this.pictureBoxScannedImage = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtinvoice = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxScannedImage)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxScannedImage
            // 
            this.pictureBoxScannedImage.BackColor = System.Drawing.SystemColors.Info;
            this.pictureBoxScannedImage.Location = new System.Drawing.Point(14, 47);
            this.pictureBoxScannedImage.Name = "pictureBoxScannedImage";
            this.pictureBoxScannedImage.Size = new System.Drawing.Size(1119, 397);
            this.pictureBoxScannedImage.TabIndex = 0;
            this.pictureBoxScannedImage.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "INVOICE NO";
            // 
            // txtinvoice
            // 
            this.txtinvoice.BackColor = System.Drawing.Color.MistyRose;
            this.txtinvoice.Location = new System.Drawing.Point(99, 20);
            this.txtinvoice.Name = "txtinvoice";
            this.txtinvoice.Size = new System.Drawing.Size(145, 20);
            this.txtinvoice.TabIndex = 3;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(250, 18);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(142, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "SCAN AND SAVE";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // invoice_scan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1147, 456);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtinvoice);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBoxScannedImage);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "invoice_scan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "invoice_scan";
            this.Load += new System.EventHandler(this.invoice_scan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxScannedImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxScannedImage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtinvoice;
        private System.Windows.Forms.Button button2;
    }
}