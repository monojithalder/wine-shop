using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Data.OleDb;
namespace wineshop_off_shop
{
    public partial class search_by_invoice : Form
    {
        public search_by_invoice()
        {
            InitializeComponent();
        }
        DataTable dt = new DataTable();
        string pic_path = "";
        BindingSource bs = new BindingSource();
        private void button1_Click(object sender, EventArgs e)
        {
            this.pictureBox1.ImageLocation = "";
            dt.Clear();
            this.dataGridView1.DataSource = bs;
            if (this.textBox1.Text != "")
            {
                load_pic();
                Class1.Cn.Open();
                OleDbCommand cmd = new OleDbCommand("select * from main_stock where invoice_no='"+textBox1.Text+"'", Class1.Cn);
                OleDbDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    dt.Rows.Add("PRODUCT NAME", rd.GetString(14).ToUpper());
                    dt.Rows.Add("PRODUCT TYPE", rd.GetString(2).ToUpper());
                    dt.Rows.Add("TOTAL CASE",rd.GetInt32(4));
                    dt.Rows.Add("ML_PER_BOTTLE", rd.GetInt32(3));
                    dt.Rows.Add("I CHARGE", rd.GetValue(12));
                    dt.Rows.Add("STOCK DATE", rd.GetDateTime(10));
                }
                rd.Close();
                cmd = new OleDbCommand("select * from batch_no where invoice_no='" + textBox1.Text + "'", Class1.Cn);
                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    dt.Rows.Add("BATCH NO", rd.GetString(3));
                }
                rd.Close();
                cmd = new OleDbCommand("select * from tcs where invoice_no='" + textBox1.Text + "'", Class1.Cn);
                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    dt.Rows.Add("TOTAL TCS", rd.GetValue(2));
                    dt.Rows.Add("TCS  %", rd.GetValue(1));
                } 
                rd.Close();
                Class1.Cn.Close();
            }
            else
            {
                MessageBox.Show("Please Enter Invoice No");
            }
        }

        private void search_by_invoice_Load(object sender, EventArgs e)
        {
            dt.Columns.Add("HEAD");
            dt.Columns.Add("VALUE");
            bs.DataSource = dt;
            this.dataGridView1.DataSource = bs;
            this.dataGridView1.Columns[0].Width = 200;
            this.dataGridView1.Columns[1].Width = 200;

        }
        private void load_pic()
        {
            Class1.Cn.Open();
            OleDbCommand cmd = new OleDbCommand("select * from scan_invoice where invoice_no='" + this.textBox1.Text + "'",Class1.Cn);
            OleDbDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                pic_path = Environment.CurrentDirectory + "\\scanimage\\"+rd.GetString(2);
            }
            rd.Close();
            Class1.Cn.Close();
            this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pictureBox1.ImageLocation = pic_path;
            pic_path = "";
        }

    }
}
