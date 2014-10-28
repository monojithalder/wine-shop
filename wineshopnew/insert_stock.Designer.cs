namespace wineshopnew
{
    partial class insert_stock
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(insert_stock));
            this.txtbarcode = new System.Windows.Forms.TextBox();
            this.txttype = new System.Windows.Forms.TextBox();
            this.txtsale = new System.Windows.Forms.TextBox();
            this.txtinvoice = new System.Windows.Forms.TextBox();
            this.txtsup = new System.Windows.Forms.TextBox();
            this.txttotalml = new System.Windows.Forms.TextBox();
            this.txtlose = new System.Windows.Forms.TextBox();
            this.txtcase = new System.Windows.Forms.TextBox();
            this.txtoriginal = new System.Windows.Forms.TextBox();
            this.txttotalbol = new System.Windows.Forms.TextBox();
            this.txtmlper = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.gridbatch = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.txtproname = new System.Windows.Forms.TextBox();
            this.txticharge = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtbrandname = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtpassno = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtsdate = new System.Windows.Forms.DateTimePicker();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridbatch)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtbarcode
            // 
            this.txtbarcode.BackColor = System.Drawing.Color.MistyRose;
            this.txtbarcode.Location = new System.Drawing.Point(78, 17);
            this.txtbarcode.Name = "txtbarcode";
            this.txtbarcode.Size = new System.Drawing.Size(190, 20);
            this.txtbarcode.TabIndex = 0;
            this.txtbarcode.TextChanged += new System.EventHandler(this.txtbarcode_TextChanged);
            // 
            // txttype
            // 
            this.txttype.Enabled = false;
            this.txttype.Location = new System.Drawing.Point(382, 17);
            this.txttype.Name = "txttype";
            this.txttype.ReadOnly = true;
            this.txttype.Size = new System.Drawing.Size(150, 20);
            this.txttype.TabIndex = 14;
            this.txttype.TextChanged += new System.EventHandler(this.txttype_TextChanged);
            // 
            // txtsale
            // 
            this.txtsale.BackColor = System.Drawing.SystemColors.Info;
            this.txtsale.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtsale.Location = new System.Drawing.Point(323, 18);
            this.txtsale.Name = "txtsale";
            this.txtsale.Size = new System.Drawing.Size(116, 20);
            this.txtsale.TabIndex = 4;
            this.txtsale.TextChanged += new System.EventHandler(this.txtsale_TextChanged);
            // 
            // txtinvoice
            // 
            this.txtinvoice.BackColor = System.Drawing.SystemColors.Info;
            this.txtinvoice.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtinvoice.Location = new System.Drawing.Point(103, 19);
            this.txtinvoice.Name = "txtinvoice";
            this.txtinvoice.Size = new System.Drawing.Size(116, 20);
            this.txtinvoice.TabIndex = 7;
            this.txtinvoice.TextChanged += new System.EventHandler(this.txtinvoice_TextChanged);
            // 
            // txtsup
            // 
            this.txtsup.BackColor = System.Drawing.Color.MistyRose;
            this.txtsup.Location = new System.Drawing.Point(547, 20);
            this.txtsup.Name = "txtsup";
            this.txtsup.ReadOnly = true;
            this.txtsup.Size = new System.Drawing.Size(116, 20);
            this.txtsup.TabIndex = 5;
            this.txtsup.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtsup_MouseClick);
            this.txtsup.TextChanged += new System.EventHandler(this.txtsup_TextChanged);
            this.txtsup.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtsup_KeyUp);
            // 
            // txttotalml
            // 
            this.txttotalml.BackColor = System.Drawing.Color.MistyRose;
            this.txttotalml.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttotalml.Location = new System.Drawing.Point(746, 19);
            this.txttotalml.Multiline = true;
            this.txttotalml.Name = "txttotalml";
            this.txttotalml.ReadOnly = true;
            this.txttotalml.Size = new System.Drawing.Size(100, 34);
            this.txttotalml.TabIndex = 19;
            this.txttotalml.Text = "0";
            this.txttotalml.TextChanged += new System.EventHandler(this.txttotalml_TextChanged);
            // 
            // txtlose
            // 
            this.txtlose.BackColor = System.Drawing.SystemColors.Info;
            this.txtlose.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtlose.Location = new System.Drawing.Point(339, 19);
            this.txtlose.Name = "txtlose";
            this.txtlose.Size = new System.Drawing.Size(100, 20);
            this.txtlose.TabIndex = 2;
            this.txtlose.Text = "0";
            this.txtlose.TextChanged += new System.EventHandler(this.txtlose_TextChanged);
            // 
            // txtcase
            // 
            this.txtcase.BackColor = System.Drawing.SystemColors.Info;
            this.txtcase.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtcase.Location = new System.Drawing.Point(103, 20);
            this.txtcase.Name = "txtcase";
            this.txtcase.Size = new System.Drawing.Size(100, 20);
            this.txtcase.TabIndex = 1;
            this.txtcase.Text = "0";
            this.txtcase.TextChanged += new System.EventHandler(this.txtcase_TextChanged);
            // 
            // txtoriginal
            // 
            this.txtoriginal.BackColor = System.Drawing.SystemColors.Info;
            this.txtoriginal.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtoriginal.Location = new System.Drawing.Point(103, 18);
            this.txtoriginal.Name = "txtoriginal";
            this.txtoriginal.Size = new System.Drawing.Size(116, 20);
            this.txtoriginal.TabIndex = 3;
            this.txtoriginal.TextChanged += new System.EventHandler(this.txtoriginal_TextChanged);
            // 
            // txttotalbol
            // 
            this.txttotalbol.BackColor = System.Drawing.Color.MistyRose;
            this.txttotalbol.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttotalbol.Location = new System.Drawing.Point(547, 19);
            this.txttotalbol.Multiline = true;
            this.txttotalbol.Name = "txttotalbol";
            this.txttotalbol.ReadOnly = true;
            this.txttotalbol.Size = new System.Drawing.Size(116, 34);
            this.txttotalbol.TabIndex = 18;
            this.txttotalbol.Text = "0";
            this.txttotalbol.TextChanged += new System.EventHandler(this.txttotalbol_TextChanged);
            // 
            // txtmlper
            // 
            this.txtmlper.Enabled = false;
            this.txtmlper.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmlper.Location = new System.Drawing.Point(382, 43);
            this.txtmlper.Multiline = true;
            this.txtmlper.Name = "txtmlper";
            this.txtmlper.ReadOnly = true;
            this.txtmlper.Size = new System.Drawing.Size(150, 34);
            this.txtmlper.TabIndex = 16;
            this.txtmlper.TextChanged += new System.EventHandler(this.txtmlper_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(459, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Suplier Name";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(683, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Total ML";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(681, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Stock Date";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(239, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Salling Price";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Invoice No";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Original Price";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(459, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Total Bottle";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(224, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(106, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "No of Lose Bottle";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(14, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "No of Case";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(290, 62);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(85, 13);
            this.label10.TabIndex = 21;
            this.label10.Text = "Ml_Per_bottle";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(290, 20);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(86, 13);
            this.label11.TabIndex = 22;
            this.label11.Text = "Product_Type";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 24);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(54, 13);
            this.label12.TabIndex = 23;
            this.label12.Text = "Barcode";
            this.label12.Click += new System.EventHandler(this.label12_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(12, 58);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(60, 13);
            this.label13.TabIndex = 24;
            this.label13.Text = "Batch No";
            this.label13.Click += new System.EventHandler(this.label13_Click);
            // 
            // gridbatch
            // 
            this.gridbatch.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridbatch.BackgroundColor = System.Drawing.SystemColors.Info;
            this.gridbatch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridbatch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridbatch.ColumnHeadersVisible = false;
            this.gridbatch.GridColor = System.Drawing.SystemColors.Control;
            this.gridbatch.Location = new System.Drawing.Point(103, 58);
            this.gridbatch.Name = "gridbatch";
            this.gridbatch.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.gridbatch.RowHeadersVisible = false;
            this.gridbatch.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.gridbatch.Size = new System.Drawing.Size(116, 130);
            this.gridbatch.TabIndex = 10;
            this.gridbatch.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridbatch_CellContentClick);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Tomato;
            this.button1.Location = new System.Drawing.Point(323, 81);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 61);
            this.button1.TabIndex = 11;
            this.button1.Text = "INSERT";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.PeachPuff;
            this.button2.Location = new System.Drawing.Point(547, 81);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(116, 61);
            this.button2.TabIndex = 13;
            this.button2.Text = "CLEAR";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(544, 20);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(88, 13);
            this.label14.TabIndex = 27;
            this.label14.Text = "Product_name";
            this.label14.Click += new System.EventHandler(this.label14_Click);
            // 
            // txtproname
            // 
            this.txtproname.Enabled = false;
            this.txtproname.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtproname.Location = new System.Drawing.Point(638, 17);
            this.txtproname.Multiline = true;
            this.txtproname.Name = "txtproname";
            this.txtproname.ReadOnly = true;
            this.txtproname.Size = new System.Drawing.Size(208, 34);
            this.txtproname.TabIndex = 15;
            this.txtproname.TextChanged += new System.EventHandler(this.txtproname_TextChanged);
            // 
            // txticharge
            // 
            this.txticharge.BackColor = System.Drawing.SystemColors.Info;
            this.txticharge.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txticharge.Location = new System.Drawing.Point(547, 16);
            this.txticharge.Name = "txticharge";
            this.txticharge.Size = new System.Drawing.Size(116, 20);
            this.txticharge.TabIndex = 9;
            this.txticharge.Text = "0";
            this.txticharge.TextChanged += new System.EventHandler(this.txticharge_TextChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(486, 19);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(55, 13);
            this.label15.TabIndex = 30;
            this.label15.Text = "I Charge";
            this.label15.Click += new System.EventHandler(this.label15_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(544, 62);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(74, 13);
            this.label16.TabIndex = 31;
            this.label16.Text = "Brand name";
            this.label16.Click += new System.EventHandler(this.label16_Click);
            // 
            // txtbrandname
            // 
            this.txtbrandname.Enabled = false;
            this.txtbrandname.Location = new System.Drawing.Point(638, 59);
            this.txtbrandname.Name = "txtbrandname";
            this.txtbrandname.ReadOnly = true;
            this.txtbrandname.Size = new System.Drawing.Size(208, 20);
            this.txtbrandname.TabIndex = 17;
            this.txtbrandname.TextChanged += new System.EventHandler(this.txtbrandname_TextChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(263, 19);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(54, 13);
            this.label17.TabIndex = 32;
            this.label17.Text = "Pass No";
            // 
            // txtpassno
            // 
            this.txtpassno.BackColor = System.Drawing.SystemColors.Info;
            this.txtpassno.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtpassno.Location = new System.Drawing.Point(323, 15);
            this.txtpassno.Name = "txtpassno";
            this.txtpassno.Size = new System.Drawing.Size(116, 20);
            this.txtpassno.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.txtbarcode);
            this.groupBox1.Controls.Add(this.txttype);
            this.groupBox1.Controls.Add(this.txtmlper);
            this.groupBox1.Controls.Add(this.txtbrandname);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.txtproname);
            this.groupBox1.Location = new System.Drawing.Point(42, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(865, 92);
            this.groupBox1.TabIndex = 34;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtcase);
            this.groupBox2.Controls.Add(this.txttotalml);
            this.groupBox2.Controls.Add(this.txtlose);
            this.groupBox2.Controls.Add(this.txttotalbol);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Location = new System.Drawing.Point(42, 111);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(865, 61);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtsdate);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.txtsale);
            this.groupBox3.Controls.Add(this.txtsup);
            this.groupBox3.Controls.Add(this.txtoriginal);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Location = new System.Drawing.Point(42, 185);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(865, 59);
            this.groupBox3.TabIndex = 35;
            this.groupBox3.TabStop = false;
            // 
            // txtsdate
            // 
            this.txtsdate.Location = new System.Drawing.Point(758, 18);
            this.txtsdate.Name = "txtsdate";
            this.txtsdate.Size = new System.Drawing.Size(88, 20);
            this.txtsdate.TabIndex = 18;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtinvoice);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.txtpassno);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Controls.Add(this.button2);
            this.groupBox4.Controls.Add(this.button1);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.txticharge);
            this.groupBox4.Controls.Add(this.gridbatch);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Location = new System.Drawing.Point(42, 259);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(865, 201);
            this.groupBox4.TabIndex = 36;
            this.groupBox4.TabStop = false;
            // 
            // insert_stock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(955, 498);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "insert_stock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "INSERT STOCK [ ON SHOP ]";
            this.Load += new System.EventHandler(this.insert_stock_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridbatch)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txttype;
        private System.Windows.Forms.TextBox txtsale;
        private System.Windows.Forms.TextBox txtinvoice;
        private System.Windows.Forms.TextBox txttotalml;
        private System.Windows.Forms.TextBox txtlose;
        private System.Windows.Forms.TextBox txtcase;
        private System.Windows.Forms.TextBox txtoriginal;
        private System.Windows.Forms.TextBox txttotalbol;
        private System.Windows.Forms.TextBox txtmlper;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DataGridView gridbatch;
        private System.Windows.Forms.TextBox txtbarcode;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        public System.Windows.Forms.TextBox txtsup;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtproname;
        private System.Windows.Forms.TextBox txticharge;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtbrandname;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtpassno;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DateTimePicker txtsdate;
    }
}