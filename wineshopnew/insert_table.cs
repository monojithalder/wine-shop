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
    public partial class insert_table : Form
    {
        public insert_table()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Class1.Cn.Open();
            int table_no = Convert.ToInt32(this.txttableno.Text);
            int flag = 0;
            OleDbCommand cmd = new OleDbCommand("select * from table_no", Class1.Cn);
            OleDbDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                if (table_no == rd.GetInt32(1))
                {
                    flag++;
                }
            }
            if (flag > 0)
            {
                MessageBox.Show("Table no already exsits");
            }
            else
            {
                cmd = new OleDbCommand("insert into table_no (table_no) values ('" + table_no + "')", Class1.Cn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Table No Inserted");
                this.txttableno.Text = "";
            }
            rd.Read();
            Class1.Cn.Close();
        }

        private void insert_table_Load(object sender, EventArgs e)
        {

        }
    }
}
