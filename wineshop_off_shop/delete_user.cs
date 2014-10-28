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
    public partial class delete_user : Form
    {
        public delete_user()
        {
            InitializeComponent();
        }
        int flag = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            Class1.Cn.Open();
            OleDbCommand cmd = new OleDbCommand("select * from user_ac where userid='"+this.txtuser.Text+"'",Class1.Cn);
            OleDbDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                flag++;
            }
            rd.Close();
            if (flag > 0)
            {
                if (this.txtuser.Text == "")
                {
                }
                else
                {
                    cmd = new OleDbCommand("delete from user_ac where userid='" + this.txtuser.Text + "'", Class1.Cn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("user deleted");
                }
            }
            else
            {
                MessageBox.Show("user no exsits");
            }
            Class1.Cn.Close();
        }

        private void delete_user_Load(object sender, EventArgs e)
        {

        }
    }
}
