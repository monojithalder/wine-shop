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
    public partial class create_user : Form
    {
        public create_user()
        {
            InitializeComponent();
        }
        int flag = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            Class1.Cn.Open();
            OleDbCommand cmd = new OleDbCommand("select * from user_ac", Class1.Cn);
            OleDbDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                if (this.txtuser.Text == rd.GetString(1))
                {
                    MessageBox.Show("User Account Already Created");
                    flag++;
                }
            }
            rd.Close();
            if (flag < 1)
            {
                if (this.txtuser.Text == "" && this.txtpassword.Text == "")
                {
                    MessageBox.Show("Please Enter userid and passoword to create user account");
                }
                else
                {
                    cmd = new OleDbCommand("insert into user_ac (userid,pass) values('" + this.txtuser.Text + "','" + this.txtpassword.Text + "')", Class1.Cn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User Account Created");
                    this.txtpassword.Text = "";
                    this.txtuser.Text = "";
                    this.txtuser.Focus();
                }
            }
            Class1.Cn.Close();
        }

        private void create_user_Load(object sender, EventArgs e)
        {

        }
    }
}
