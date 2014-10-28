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
    public partial class view_income_expenses : Form
    {
        public view_income_expenses()
        {
            InitializeComponent();
        }
        DataTable dt = new DataTable();
        BindingSource bs = new BindingSource();
        decimal dr = 0, cr = 0;
        decimal n = 0;
        private void view_income_expenses_Load(object sender, EventArgs e)
        {
            dt.Columns.Add("Head Name");
            dt.Columns.Add("DR");
            dt.Columns.Add("CR");
            //dt.Columns.Add("Total");
            bs.DataSource = dt;
            this.dataGridView1.DataSource = bs;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime date = Convert.ToDateTime(this.dateTimePicker1.Value);
            Class1.Cn.Open();
            OleDbCommand cmd = new OleDbCommand("select * from incexp", Class1.Cn);
            OleDbDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                if (rd.GetDateTime(2).Year == date.Year)
                {
                    if (rd.GetDateTime(2).Month == date.Month)
                    {
                        if (rd.GetDateTime(2).Day == date.Day)
                        {
                            dt.Rows.Add(rd.GetString(1), rd.GetValue(3), rd.GetValue(4));
                        }
                    }
                }

            }
            rd.Close();
            Class1.Cn.Close();
            for (int i = 0; i < this.dataGridView1.Rows.Count - 1; i++)
            {
                dr += Convert.ToDecimal(this.dataGridView1.Rows[i].Cells[1].Value);
                cr += Convert.ToDecimal(this.dataGridView1.Rows[i].Cells[2].Value);
            }
            dt.Rows.Add("Total", dr, cr);
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
