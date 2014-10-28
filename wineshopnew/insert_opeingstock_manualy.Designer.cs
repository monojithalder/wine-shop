namespace wineshopnew
{
    partial class insert_opeingstock_manualy
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(insert_opeingstock_manualy));
            this.txtbrandname = new System.Windows.Forms.TextBox();
            this.txticharge = new System.Windows.Forms.TextBox();
            this.txtproname = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.gridbatch = new System.Windows.Forms.DataGridView();
            this.txtmlper = new System.Windows.Forms.TextBox();
            this.txttotalbol = new System.Windows.Forms.TextBox();
            this.txtoriginal = new System.Windows.Forms.TextBox();
            this.txtcase = new System.Windows.Forms.TextBox();
            this.txtlose = new System.Windows.Forms.TextBox();
            this.txttotalml = new System.Windows.Forms.TextBox();
            this.txtsup = new System.Windows.Forms.TextBox();
            this.txtinvoice = new System.Windows.Forms.TextBox();
            this.txtsale = new System.Windows.Forms.TextBox();
            this.txttype = new System.Windows.Forms.TextBox();
            this.txtbarcode = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtsdate = new System.Windows.Forms.MaskedTextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtpassno = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridbatch)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtbrandname
            // 
            this.txtbrandname.Enabled = false;
            this.txtbrandname.Location = new System.Drawing.Point(638, 62);
            this.txtbrandname.Name = "txtbrandname";
            this.txtbrandname.ReadOnly = true;
            this.txtbrandname.Size = new System.Drawing.Size(208, 20);
            this.txtbrandname.TabIndex = 51;
            // 
            // txticharge
            // 
            this.txticharge.BackColor = System.Drawing.SystemColors.Info;
            this.txticharge.Location = new System.Drawing.Point(547, 15);
            this.txticharge.Name = "txticharge";
            this.txticharge.Size = new System.Drawing.Size(116, 20);
            this.txticharge.TabIndex = 47;
            this.txticharge.Text = "0";
            // 
            // txtproname
            // 
            this.txtproname.Enabled = false;
            this.txtproname.Location = new System.Drawing.Point(638, 17);
            this.txtproname.Multiline = true;
            this.txtproname.Name = "txtproname";
            this.txtproname.ReadOnly = true;
            this.txtproname.Size = new System.Drawing.Size(208, 36);
            this.txtproname.TabIndex = 45;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.PeachPuff;
            this.button2.Location = new System.Drawing.Point(547, 79);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(116, 63);
            this.button2.TabIndex = 62;
            this.button2.Text = "CLEAR";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Tomato;
            this.button1.Location = new System.Drawing.Point(323, 79);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 63);
            this.button1.TabIndex = 61;
            this.button1.Text = "INSERT";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // gridbatch
            // 
            this.gridbatch.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridbatch.BackgroundColor = System.Drawing.SystemColors.Info;
            this.gridbatch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridbatch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridbatch.ColumnHeadersVisible = false;
            this.gridbatch.GridColor = System.Drawing.SystemColors.Control;
            this.gridbatch.Location = new System.Drawing.Point(103, 65);
            this.gridbatch.Name = "gridbatch";
            this.gridbatch.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.gridbatch.RowHeadersVisible = false;
            this.gridbatch.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.gridbatch.Size = new System.Drawing.Size(116, 130);
            this.gridbatch.TabIndex = 48;
            // 
            // txtmlper
            // 
            this.txtmlper.Enabled = false;
            this.txtmlper.Location = new System.Drawing.Point(382, 59);
            this.txtmlper.Name = "txtmlper";
            this.txtmlper.ReadOnly = true;
            this.txtmlper.Size = new System.Drawing.Size(150, 20);
            this.txtmlper.TabIndex = 34;
            // 
            // txttotalbol
            // 
            this.txttotalbol.BackColor = System.Drawing.Color.MistyRose;
            this.txttotalbol.Location = new System.Drawing.Point(538, 20);
            this.txttotalbol.Multiline = true;
            this.txttotalbol.Name = "txttotalbol";
            this.txttotalbol.ReadOnly = true;
            this.txttotalbol.Size = new System.Drawing.Size(103, 35);
            this.txttotalbol.TabIndex = 37;
            this.txttotalbol.Text = "0";
            // 
            // txtoriginal
            // 
            this.txtoriginal.BackColor = System.Drawing.SystemColors.Info;
            this.txtoriginal.Location = new System.Drawing.Point(98, 22);
            this.txtoriginal.Name = "txtoriginal";
            this.txtoriginal.Size = new System.Drawing.Size(135, 20);
            this.txtoriginal.TabIndex = 39;
            // 
            // txtcase
            // 
            this.txtcase.BackColor = System.Drawing.SystemColors.Info;
            this.txtcase.Location = new System.Drawing.Point(90, 19);
            this.txtcase.Name = "txtcase";
            this.txtcase.Size = new System.Drawing.Size(105, 20);
            this.txtcase.TabIndex = 35;
            this.txtcase.Text = "0";
            this.txtcase.TextChanged += new System.EventHandler(this.txtcase_TextChanged);
            // 
            // txtlose
            // 
            this.txtlose.BackColor = System.Drawing.SystemColors.Info;
            this.txtlose.Location = new System.Drawing.Point(339, 19);
            this.txtlose.Name = "txtlose";
            this.txtlose.Size = new System.Drawing.Size(114, 20);
            this.txtlose.TabIndex = 36;
            this.txtlose.Text = "0";
            this.txtlose.TextChanged += new System.EventHandler(this.txtlose_TextChanged);
            // 
            // txttotalml
            // 
            this.txttotalml.BackColor = System.Drawing.Color.MistyRose;
            this.txttotalml.Location = new System.Drawing.Point(721, 19);
            this.txttotalml.Multiline = true;
            this.txttotalml.Name = "txttotalml";
            this.txttotalml.ReadOnly = true;
            this.txttotalml.Size = new System.Drawing.Size(138, 32);
            this.txttotalml.TabIndex = 38;
            this.txttotalml.Text = "0";
            // 
            // txtsup
            // 
            this.txtsup.BackColor = System.Drawing.Color.MistyRose;
            this.txtsup.Location = new System.Drawing.Point(547, 20);
            this.txtsup.Name = "txtsup";
            this.txtsup.ReadOnly = true;
            this.txtsup.Size = new System.Drawing.Size(141, 20);
            this.txtsup.TabIndex = 43;
            this.txtsup.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtsup_MouseClick);
            this.txtsup.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtsup_KeyUp);
            // 
            // txtinvoice
            // 
            this.txtinvoice.BackColor = System.Drawing.SystemColors.Info;
            this.txtinvoice.Location = new System.Drawing.Point(103, 16);
            this.txtinvoice.Name = "txtinvoice";
            this.txtinvoice.Size = new System.Drawing.Size(135, 20);
            this.txtinvoice.TabIndex = 41;
            // 
            // txtsale
            // 
            this.txtsale.Location = new System.Drawing.Point(318, 18);
            this.txtsale.Name = "txtsale";
            this.txtsale.Size = new System.Drawing.Size(135, 20);
            this.txtsale.TabIndex = 40;
            // 
            // txttype
            // 
            this.txttype.Enabled = false;
            this.txttype.Location = new System.Drawing.Point(382, 17);
            this.txttype.Name = "txttype";
            this.txttype.ReadOnly = true;
            this.txttype.Size = new System.Drawing.Size(150, 20);
            this.txttype.TabIndex = 33;
            // 
            // txtbarcode
            // 
            this.txtbarcode.BackColor = System.Drawing.Color.MistyRose;
            this.txtbarcode.Location = new System.Drawing.Point(77, 21);
            this.txtbarcode.Name = "txtbarcode";
            this.txtbarcode.Size = new System.Drawing.Size(187, 20);
            this.txtbarcode.TabIndex = 32;
            this.txtbarcode.TextChanged += new System.EventHandler(this.txtbarcode_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.txtbrandname);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.txtproname);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.txtbarcode);
            this.groupBox1.Controls.Add(this.txttype);
            this.groupBox1.Controls.Add(this.txtmlper);
            this.groupBox1.Location = new System.Drawing.Point(58, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(865, 92);
            this.groupBox1.TabIndex = 66;
            this.groupBox1.TabStop = false;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(12, 24);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(54, 13);
            this.label17.TabIndex = 23;
            this.label17.Text = "Barcode";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(544, 62);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(74, 13);
            this.label18.TabIndex = 31;
            this.label18.Text = "Brand name";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(290, 62);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(85, 13);
            this.label19.TabIndex = 21;
            this.label19.Text = "Ml_Per_bottle";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(290, 20);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(86, 13);
            this.label20.TabIndex = 22;
            this.label20.Text = "Product_Type";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(544, 20);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(88, 13);
            this.label21.TabIndex = 27;
            this.label21.Text = "Product_name";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label22);
            this.groupBox2.Controls.Add(this.txtcase);
            this.groupBox2.Controls.Add(this.txtlose);
            this.groupBox2.Controls.Add(this.txttotalbol);
            this.groupBox2.Controls.Add(this.txttotalml);
            this.groupBox2.Location = new System.Drawing.Point(59, 110);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(865, 61);
            this.groupBox2.TabIndex = 67;
            this.groupBox2.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(658, 23);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 13);
            this.label10.TabIndex = 13;
            this.label10.Text = "Total ML";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(459, 23);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(73, 13);
            this.label11.TabIndex = 18;
            this.label11.Text = "Total Bottle";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(224, 23);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(106, 13);
            this.label12.TabIndex = 19;
            this.label12.Text = "No of Lose Bottle";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(14, 22);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(70, 13);
            this.label22.TabIndex = 20;
            this.label22.Text = "No of Case";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dateTimePicker1);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.txtoriginal);
            this.groupBox3.Controls.Add(this.txtsale);
            this.groupBox3.Controls.Add(this.txtsup);
            this.groupBox3.Location = new System.Drawing.Point(59, 177);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(865, 59);
            this.groupBox3.TabIndex = 68;
            this.groupBox3.TabStop = false;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(771, 18);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(88, 20);
            this.dateTimePicker1.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Original Price";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(459, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Suplier Name";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(694, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Stock Date";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(239, 21);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "Salling Price";
            // 
            // txtsdate
            // 
            this.txtsdate.Location = new System.Drawing.Point(680, 19);
            this.txtsdate.Mask = "00/00/0000";
            this.txtsdate.Name = "txtsdate";
            this.txtsdate.Size = new System.Drawing.Size(158, 20);
            this.txtsdate.TabIndex = 42;
            this.txtsdate.ValidatingType = typeof(System.DateTime);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.txtpassno);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.txtsdate);
            this.groupBox4.Controls.Add(this.txticharge);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.button2);
            this.groupBox4.Controls.Add(this.button1);
            this.groupBox4.Controls.Add(this.txtinvoice);
            this.groupBox4.Controls.Add(this.gridbatch);
            this.groupBox4.Location = new System.Drawing.Point(59, 251);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(865, 211);
            this.groupBox4.TabIndex = 69;
            this.groupBox4.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Invoice No";
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(263, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 32;
            this.label3.Text = "Pass No";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(486, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "I Charge";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Batch No";
            // 
            // insert_opeingstock_manualy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(987, 474);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "insert_opeingstock_manualy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "insert_opeingstock_manualy";
            this.Load += new System.EventHandler(this.insert_opeingstock_manualy_Load);
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

        private System.Windows.Forms.TextBox txtbrandname;
        private System.Windows.Forms.TextBox txticharge;
        private System.Windows.Forms.TextBox txtproname;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView gridbatch;
        private System.Windows.Forms.TextBox txtmlper;
        private System.Windows.Forms.TextBox txttotalbol;
        private System.Windows.Forms.TextBox txtoriginal;
        private System.Windows.Forms.TextBox txtcase;
        private System.Windows.Forms.TextBox txtlose;
        private System.Windows.Forms.TextBox txttotalml;
        public System.Windows.Forms.TextBox txtsup;
        private System.Windows.Forms.TextBox txtinvoice;
        private System.Windows.Forms.TextBox txtsale;
        private System.Windows.Forms.TextBox txttype;
        private System.Windows.Forms.TextBox txtbarcode;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.MaskedTextBox txtsdate;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtpassno;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
    }
}