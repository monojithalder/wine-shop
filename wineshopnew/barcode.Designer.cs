﻿namespace wineshopnew
{
    partial class barcode
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(barcode));
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtmlper = new System.Windows.Forms.TextBox();
            this.txttype = new System.Windows.Forms.TextBox();
            this.txtbarcode = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtproname = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtbrandname = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(29, 40);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(54, 13);
            this.label12.TabIndex = 29;
            this.label12.Text = "Barcode";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(29, 154);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(86, 13);
            this.label11.TabIndex = 28;
            this.label11.Text = "Product_Type";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(30, 192);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(85, 13);
            this.label10.TabIndex = 27;
            this.label10.Text = "Ml_Per_bottle";
            // 
            // txtmlper
            // 
            this.txtmlper.AutoCompleteCustomSource.AddRange(new string[] {
            "2000",
            "1000",
            "750",
            "650",
            "500",
            "375",
            "275",
            "180"});
            this.txtmlper.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtmlper.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtmlper.BackColor = System.Drawing.Color.LightYellow;
            this.txtmlper.Location = new System.Drawing.Point(136, 185);
            this.txtmlper.Name = "txtmlper";
            this.txtmlper.Size = new System.Drawing.Size(135, 20);
            this.txtmlper.TabIndex = 4;
            // 
            // txttype
            // 
            this.txttype.BackColor = System.Drawing.Color.LightYellow;
            this.txttype.Location = new System.Drawing.Point(136, 151);
            this.txttype.Name = "txttype";
            this.txttype.Size = new System.Drawing.Size(135, 20);
            this.txttype.TabIndex = 3;
            // 
            // txtbarcode
            // 
            this.txtbarcode.BackColor = System.Drawing.Color.AntiqueWhite;
            this.txtbarcode.Location = new System.Drawing.Point(136, 33);
            this.txtbarcode.Name = "txtbarcode";
            this.txtbarcode.Size = new System.Drawing.Size(187, 20);
            this.txtbarcode.TabIndex = 0;
            this.txtbarcode.TextChanged += new System.EventHandler(this.txtbarcode_TextChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(243, 237);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(80, 30);
            this.button2.TabIndex = 6;
            this.button2.Text = "UPDATE";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 32;
            this.label1.Text = "Product_name";
            // 
            // txtproname
            // 
            this.txtproname.BackColor = System.Drawing.Color.LightYellow;
            this.txtproname.Location = new System.Drawing.Point(136, 72);
            this.txtproname.Name = "txtproname";
            this.txtproname.Size = new System.Drawing.Size(187, 20);
            this.txtproname.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 36;
            this.label3.Text = "Brand Name";
            // 
            // txtbrandname
            // 
            this.txtbrandname.BackColor = System.Drawing.Color.LightYellow;
            this.txtbrandname.Location = new System.Drawing.Point(136, 111);
            this.txtbrandname.Name = "txtbrandname";
            this.txtbrandname.Size = new System.Drawing.Size(187, 20);
            this.txtbrandname.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(343, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(763, 493);
            this.groupBox1.TabIndex = 37;
            this.groupBox1.TabStop = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Info;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 16);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(757, 474);
            this.dataGridView1.TabIndex = 20;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(152, 237);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 30);
            this.button1.TabIndex = 5;
            this.button1.Text = "INSERT";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 237);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(134, 30);
            this.button3.TabIndex = 7;
            this.button3.Text = "CHANGE BARCODE";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // barcode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1118, 525);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtbrandname);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtproname);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtmlper);
            this.Controls.Add(this.txttype);
            this.Controls.Add(this.txtbarcode);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "barcode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BARCODE [ ON SHOP ]";
            this.Load += new System.EventHandler(this.barcode_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtmlper;
        private System.Windows.Forms.TextBox txttype;
        private System.Windows.Forms.TextBox txtbarcode;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtproname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtbrandname;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
    }
}