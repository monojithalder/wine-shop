using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace wineshop_off_shop
{
    public partial class show_user_ac : Form
    {
        public show_user_ac()
        {
            InitializeComponent();
        }
        DataTable dt = new DataTable();
        BindingSource bs = new BindingSource();
        private void show_user_ac_Load(object sender, EventArgs e)
        {
            dt.Columns.Add("User Id");
            dt.Columns.Add("Password");
            bs.DataSource = dt;
            this.dataGridView1.DataSource = bs;
            Class1.Cn.Open();
            OleDbCommand cmd = new OleDbCommand("select * from user_ac",Class1.Cn);
            OleDbDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                dt.Rows.Add(rd.GetString(0),rd.GetString(1));
            }
            rd.Close();
            Class1.Cn.Close();
        }
    }
}
