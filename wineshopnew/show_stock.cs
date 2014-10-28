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
    public partial class show_stock : Form
    {
        public show_stock()
        {
            InitializeComponent();
        }
        DataTable dt = new DataTable();
        BindingSource bs = new BindingSource();
        private void show_stock_Load(object sender, EventArgs e)
        {
            dt.Columns.Add("Barcode");
            dt.Columns.Add("Product Type");
            dt.Columns.Add("Ml Per Bottle");
            dt.Columns.Add("No Of Case");
            dt.Columns.Add("No of Lose Bottle");
            dt.Columns.Add("Total Bottle");
            dt.Columns.Add("Total Ml");
            dt.Columns.Add("Original Price");
            dt.Columns.Add("Stcok Date");
            dt.Columns.Add("Invoice No");
            bs.DataSource = dt;
            this.dataGridView1.DataSource = bs;
            Class1.Cn.Open();
            OleDbCommand cmd = new OleDbCommand("select * from stock", Class1.Cn);
            OleDbDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                dt.Rows.Add(rd.GetString(1), rd.GetString(2), rd.GetInt32(3), rd.GetInt32(4), rd.GetInt32(5), rd.GetInt32(6), rd.GetInt32(7), rd.GetValue(8), rd.GetDateTime(10), rd.GetString(11));
            }
            rd.Close();
            Class1.Cn.Close();

        }
    }
}
