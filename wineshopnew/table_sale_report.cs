using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace wineshopnew
{
    public partial class table_sale_report : Form
    {
        public table_sale_report()
        {
            InitializeComponent();
        }
        DataTable dt = new DataTable();
        BindingSource bs = new BindingSource();
        private void table_sale_report_Load(object sender, EventArgs e)
        {
            dt.Columns.Add("Bill_No");
            //dt.Columns.Add("Table_No");
            dt.Columns.Add("Date Time");
            dt.Columns.Add("user");
            dt.Columns.Add("Pro_Name");
            dt.Columns.Add("Pro_price(per)");
            dt.Columns.Add("Pro_Type");
            dt.Columns.Add("Quantity");
            dt.Columns.Add("Total_Ml");
            // dt.Columns.Add("No_Of_Bill_Print");
            //dt.Columns.Add("Total_Bill_Amount");
            bs.DataSource = dt;
            this.dataGridView1.DataSource = bs;
            this.dataGridView1.Columns[1].Width = 300;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dt.Clear();
            this.dataGridView1.DataSource = bs;
            Class1.Cn.Open();
            OleDbCommand cmd = new OleDbCommand("select * from billing where table_no=" + Convert.ToInt32(this.txttableno.Text) + "", Class1.Cn);
            OleDbDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                if (rd.GetDateTime(1).Year == Convert.ToDateTime(this.dateTimePicker1.Value).Year)
                {
                    if (rd.GetDateTime(1).Month == Convert.ToDateTime(this.dateTimePicker1.Value).Month && rd.GetDateTime(1).Date == Convert.ToDateTime(this.dateTimePicker1.Value).Date)
                    {
                        int bill_no = rd.GetInt32(0);
                        dt.Rows.Add(bill_no, rd.GetDateTime(1), rd.GetString(4));
                        OleDbCommand cmd1 = new OleDbCommand("select * from table_product where bill_no=" + bill_no + "", Class1.Cn);
                        OleDbDataReader rd1 = cmd1.ExecuteReader();
                        while (rd1.Read())
                        {
                            dt.Rows.Add("", "", "", rd1.GetString(2), rd1.GetValue(3), rd1.GetString(5), rd1.GetInt32(6), rd1.GetInt32(7));
                        }
                        rd1.Close();

                    }
                }
            }
            rd.Close();
            Class1.Cn.Close();
        }
    }
}
