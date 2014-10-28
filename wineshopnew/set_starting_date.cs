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
    public partial class set_starting_date : Form
    {
        public set_starting_date()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Class1.Cn.Open();
            int flag = 0;
            DateTime start_date = Convert.ToDateTime(this.dateTimePicker1.Value);
            OleDbCommand cmd = new OleDbCommand("select * from start_date", Class1.Cn);
            OleDbDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                flag++;
            }
            if (flag > 0)
            {
                cmd = new OleDbCommand("update start_date set start_date='" + start_date + "' where id=1", Class1.Cn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Start date Updated");
            }
            else
            {
                cmd = new OleDbCommand("insert into start_date (start_date) values ('" + start_date + "')", Class1.Cn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Start date Inserted");
            }
            Class1.Cn.Close();
        }

        private void set_starting_date_Load(object sender, EventArgs e)
        {

        }
    }
}
