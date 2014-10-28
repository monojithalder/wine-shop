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
    public partial class login_detail : Form
    {
        public login_detail()
        {
            InitializeComponent();
        }
        DataTable dt = new DataTable();
        BindingSource bs = new BindingSource();
        private void button1_Click(object sender, EventArgs e)
        {
            dt.Clear();
            this.dataGridView1.DataSource = bs;
            Class1.Cn.Open();
            OleDbCommand cmd = new OleDbCommand("select * from user_login", Class1.Cn);
            OleDbDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                string temp = rd.GetValue(4).ToString();
                //if ( temp!= "")
                //{
                dt.Rows.Add(rd.GetString(1), rd.GetString(2), rd.GetDateTime(3), rd.GetString(4));
                //}
                //else
                // {
                //   dt.Rows.Add(rd.GetString(1), rd.GetString(2), rd.GetDateTime(3));
                //}
            }
            rd.Close();
            Class1.Cn.Close();
        }

        private void login_detail_Load(object sender, EventArgs e)
        {
            dt.Columns.Add("User ID");
            dt.Columns.Add("Login Time");
            dt.Columns.Add("Login Date");
            dt.Columns.Add("Logout Time");
            bs.DataSource = dt;
            this.dataGridView1.DataSource = bs;
        }
    }
}
