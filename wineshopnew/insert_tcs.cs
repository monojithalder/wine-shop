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
    public partial class insert_tcs : Form
    {
        public insert_tcs()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //try
            //{
            int flag = check_dealer_name(this.txtdealer.Text);
            if (flag > 0)
            {
                Class1.Cn.Open();
                OleDbCommand cmd = new OleDbCommand("insert into tcs (invoice_no,tcs_persentage,total_tcs,dealer_name,invoice_date" +
                    ") values ('" + this.txtinvoice.Text + "','" + this.txttcsper.Text + "','" + this.txttotaltcs.Text + "','" + this.txtdealer.Text + "'" +
                    ",'" + Convert.ToDateTime(this.dateTimePicker1.Value) + "')", Class1.Cn);
                cmd.ExecuteNonQuery();
                Class1.Cn.Close();
                MessageBox.Show("Inserted");
                this.txtdealer.Text = "";
                this.txtinvoice.Text = "";
                this.txttcsper.Text = "";
                this.txttotaltcs.Text = "";
            }
            else
            {
                insert_dealer_name(this.txtdealer.Text);
                Class1.Cn.Open();
                OleDbCommand cmd = new OleDbCommand("insert into tcs (invoice_no,tcs_persentage,total_tcs,dealer_name,invoice_date" +
                    ") values ('" + this.txtinvoice.Text + "','" + this.txttcsper.Text + "','" + this.txttotaltcs.Text + "','" + this.txtdealer.Text + "'" +
                    ",'" + Convert.ToDateTime(this.dateTimePicker1.Value) + "')", Class1.Cn);
                cmd.ExecuteNonQuery();
                Class1.Cn.Close();
                MessageBox.Show("Inserted");
                this.txtdealer.Text = "";
                this.txtinvoice.Text = "";
                this.txttcsper.Text = "";
                this.txttotaltcs.Text = "";
            }
            //}
            //catch (Exception e1)
            //{
            //    Class1.Cn.Close();
            //    MessageBox.Show(e1.Message);
            //}
        }
        private int check_dealer_name(string name)
        {
            int i = 0;
            Class1.Cn.Open();
            OleDbCommand cmd = new OleDbCommand("select * from dealer_name where dealer_name='" + name + "'", Class1.Cn);
            OleDbDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                i++;
            }
            rd.Close();
            Class1.Cn.Close();
            return i;

        }
        private void insert_dealer_name(string name)
        {
            Class1.Cn.Open();
            OleDbCommand cmd = new OleDbCommand("insert into dealer_name (dealer_name) values ('" + name + "')", Class1.Cn);
            cmd.ExecuteNonQuery();
            Class1.Cn.Close();
        }

        private void insert_tcs_Load(object sender, EventArgs e)
        {
            Class1.Cn.Open();
            AutoCompleteStringCollection collection2 = new AutoCompleteStringCollection();
            OleDbCommand cmd2 = new OleDbCommand("select * from dealer_name", Class1.Cn);
            OleDbDataReader rd2 = cmd2.ExecuteReader();
            while (rd2.Read())
            {
                collection2.Add(rd2.GetValue(1).ToString());
            }
            this.txtdealer.AutoCompleteMode = AutoCompleteMode.Suggest;
            this.txtdealer.AutoCompleteSource = AutoCompleteSource.CustomSource;
            this.txtdealer.AutoCompleteCustomSource = collection2;
            rd2.Close();
            Class1.Cn.Close();
        }    
    }
}
