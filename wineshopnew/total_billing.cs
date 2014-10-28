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
    public partial class total_billing : Form
    {
        public total_billing()
        {
            InitializeComponent();
        }
        DataTable dt = new DataTable();
        BindingSource bs = new BindingSource();
        private void total_billing_Load(object sender, EventArgs e)
        {
            dt.Columns.Add("Bill_No");
            dt.Columns.Add("Billig_Date");
            dt.Columns.Add("Table_No");
            bs.DataSource = dt;
            this.dataGridView1.DataSource = bs;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dt.Clear();
            this.dataGridView1.DataSource = bs;
            DateTime billing_date = Convert.ToDateTime(this.dateTimePicker1.Value);
            Class1.Cn.Open();
            int year = billing_date.Year;
            int month = billing_date.Month;
            OleDbCommand cmd = new OleDbCommand("select * from billing", Class1.Cn);
            OleDbDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                if (rd.GetDateTime(1).Year == year)
                {
                    if (rd.GetDateTime(1).Month == month && rd.GetDateTime(1).Day == billing_date.Day)
                    {
                        dt.Rows.Add(rd.GetInt32(0), rd.GetDateTime(1), rd.GetInt32(2));
                    }

                }
            }
            Class1.Cn.Close();


        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                int row_index = Convert.ToInt32(this.dataGridView1.SelectedCells[0].RowIndex);
                bill_product bp = new bill_product();
                bp.bill_no = Convert.ToInt32(this.dataGridView1.Rows[row_index].Cells[0].Value);
                bp.Show();
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }
    }
}
