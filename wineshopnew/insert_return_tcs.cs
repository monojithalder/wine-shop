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
    public partial class insert_return_tcs : Form
    {
        public insert_return_tcs()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Class1.Cn.Open();
                OleDbCommand cmd = new OleDbCommand("insert into tcs_return (dealer_name,return_amount,return_date"
                    + ") values ('" + this.txtdealer.Text + "','" + Convert.ToDecimal(this.txtamount.Text) + "','" + Convert.ToDateTime(this.dateTimePicker1.Value) + "')", Class1.Cn);
                cmd.ExecuteNonQuery();
                Class1.Cn.Close();
                MessageBox.Show("Inserted");
            }
            catch (Exception e1)
            {
                Class1.Cn.Close();
                MessageBox.Show(e1.Message);
            }
        }

        private void insert_return_tcs_Load(object sender, EventArgs e)
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
