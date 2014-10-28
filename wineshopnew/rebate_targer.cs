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
    public partial class rebate_targer : Form
    {
        public rebate_targer()
        {
            InitializeComponent();
        }
        public DataTable dt = new DataTable();
        public BindingSource bs = new BindingSource();
        int year, month;
        private void button1_Click(object sender, EventArgs e)
        {
            dt.Clear();
            this.dataGridView1.DataSource = bs;
            int i = 0;
            string[] name = new string[sizeof(double)];
            int[] quan = new int[sizeof(int)];
            DateTime today = DateTime.Now;
            TimeSpan[] tp = new TimeSpan[sizeof(double)];
            year = Convert.ToDateTime(this.dateTimePicker1.Value).Year;
            month = Convert.ToDateTime(this.dateTimePicker1.Value).Month;
            Class1.Cn.Open();
            OleDbCommand cmd = new OleDbCommand("select * from rebate", Class1.Cn);
            OleDbDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                if (rd.GetDateTime(3).Month == month && rd.GetDateTime(3).Year == year)
                {
                    name[i] = rd.GetString(1);
                    quan[i] = rd.GetInt32(2);
                    tp[i] = today - rd.GetDateTime(3);
                    i++;
                }
            }
            rd.Close();
            for (int j = 0; j <= i; j++)
            {
                cmd = new OleDbCommand("select * from main_stock where supplier_name='" + name[j] + "'", Class1.Cn);
                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    dt.Rows.Add(name[j], quan[j], rd.GetInt32(4), tp[j]);
                }

            }
            Class1.Cn.Close();

        }

        private void rebate_targer_Load(object sender, EventArgs e)
        {
            dt.Columns.Add("Creditor name");
            dt.Columns.Add("Rebate Quantuty");
            dt.Columns.Add("Total Purchese");
            dt.Columns.Add("Remaining Time");
            //dt.Columns.Add("TimeSpan");
            bs.DataSource = dt;
            this.dataGridView1.DataSource = bs;
        }
    }
}
