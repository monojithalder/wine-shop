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
    public partial class bill_product : Form
    {
        public bill_product()
        {
            InitializeComponent();
        }
        DataTable dt = new DataTable();
        BindingSource bs = new BindingSource();
        DataTable dt1 = new DataTable();
        BindingSource bs1 = new BindingSource();
        public int bill_no;
        int total_amount_first;
        private void bill_product_Load(object sender, EventArgs e)
        {
            dt.Columns.Add("Bill_No");
            dt.Columns.Add("Table_No");
            dt.Columns.Add("Pro_Name");
            dt.Columns.Add("Pro_price(per)");
            dt.Columns.Add("Pro_Type");
            dt.Columns.Add("Quantity");
            dt.Columns.Add("Total_Ml");
            dt.Columns.Add("No_Of_Bill_Print");
            dt.Columns.Add("Total_Bill_Amount");
            bs.DataSource = dt;
            this.dataGridView1.DataSource = bs;
            dt1.Columns.Add("Bill_No");
            dt1.Columns.Add("Table_No");
            dt1.Columns.Add("Pro_Name");
            dt1.Columns.Add("Pro_price(per)");
            dt1.Columns.Add("Pro_Type");
            dt1.Columns.Add("Quantity");
            dt1.Columns.Add("Total_Ml");
            dt1.Columns.Add("No_Of_Bill_Print");
            dt1.Columns.Add("Total_Bill_Amount");
            bs1.DataSource = dt1;
            this.dataGridView2.DataSource = bs1;
            show_first_grid();
            show_sceound_grid();
        }
        public void show_first_grid()
        {
            total_amount_first = 0;
            int number_of_bill_print = bill_print(bill_no);
            Class1.Cn.Open();
            OleDbCommand cmd = new OleDbCommand("select * from table_gross_product where bill_no=" + bill_no + "", Class1.Cn);
            OleDbDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                dt.Rows.Add(bill_no, rd.GetInt32(1), rd.GetString(2), rd.GetValue(3), rd.GetString(5), rd.GetInt32(6), rd.GetInt32(7), number_of_bill_print, "");
            }
            rd.Read();
            Class1.Cn.Close();
            for (int i = 0; i < this.dataGridView1.Rows.Count - 1; i++)
            {
                total_amount_first += Convert.ToInt32(this.dataGridView1.Rows[i].Cells[3].Value);
            }
            dt.Rows.Add("", "", "", "", "", "", "", "", total_amount_first);

        }

        private int bill_print(int bil_no)
        {
            Class1.Cn.Open();
            int flag = 0;
            OleDbCommand cmd = new OleDbCommand("select * from bill_print where bill_no=" + bil_no + "", Class1.Cn);
            OleDbDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                flag++;
            }
            rd.Close();
            Class1.Cn.Close();
            if (flag < 1)
            {
                return 0;
            }
            else
            {
                return flag;
            }
        }
        public void show_sceound_grid()
        {
            int number_of_bill_print = bill_print(bill_no);
            total_amount_first = 0;
            Class1.Cn.Open();
            OleDbCommand cmd = new OleDbCommand("select * from table_product where bill_no=" + bill_no + "", Class1.Cn);
            OleDbDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                dt1.Rows.Add(bill_no, rd.GetInt32(1), rd.GetString(2), rd.GetValue(3), rd.GetString(5), rd.GetInt32(6), rd.GetInt32(7), number_of_bill_print, "");
            }
            rd.Read();
            Class1.Cn.Close();
            for (int i = 0; i < this.dataGridView1.Rows.Count - 1; i++)
            {
                total_amount_first += Convert.ToInt32(this.dataGridView2.Rows[i].Cells[3].Value);
            }
            dt1.Rows.Add("", "", "", "", "", "", "", "", total_amount_first);
        }
    }
}
