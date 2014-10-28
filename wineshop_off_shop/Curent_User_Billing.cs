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
    public partial class Curent_User_Billing : Form
    {
        public Curent_User_Billing()
        {
            InitializeComponent();
        }

        DataTable dt = new DataTable();
        BindingSource bs = new BindingSource();
        //string[] user_id;
        //int arr = 0;
        int total_amount = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            dt.Clear();
            this.dataGridView1.DataSource = bs;
            show_data();
        }

        private void Curent_User_Billing_Load(object sender, EventArgs e)
        {
            dt.Columns.Add("USER ID");
            dt.Columns.Add("BILLING TIME");
            dt.Columns.Add("TOTAL AMOUNT");
            bs.DataSource = dt;
            this.dataGridView1.DataSource = bs;
            
        }

        private void show_data()
        {
            int month = Convert.ToDateTime(this.dateTimePicker1.Value).Month;
            // int date=Convert.ToDateTime(this.dateTimePicker1.Value).Date;
            int year = Convert.ToDateTime(this.dateTimePicker1.Value).Year;
            Class1.Cn.Open();
            
                OleDbCommand cmd = new OleDbCommand("select * from user_biling where user_name='" + Class1.user + "'", Class1.Cn);
                OleDbDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    if (rd.GetDateTime(3).Year == year)
                    {
                        if (rd.GetDateTime(3).Month == month && rd.GetDateTime(3).Date == Convert.ToDateTime(this.dateTimePicker1.Value).Date)
                        {
                            total_amount += rd.GetInt32(2);
                        }
                    }
                }
                dt.Rows.Add(Class1.user, this.dateTimePicker1.Value, total_amount);
                total_amount = 0;
            Class1.Cn.Close();



        }
        
        

    }
}
