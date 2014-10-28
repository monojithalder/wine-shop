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
    public partial class creditor_money_return : Form
    {
        public creditor_money_return()
        {
            InitializeComponent();
        }
        int flag;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int creditor_id = creditorid(this.txtcreditorname.Text);
                Class1.Cn.Open();
                if (flag < 1)
                {
                    MessageBox.Show("Creditors name not available");
                }
                else
                {

                    OleDbCommand cmd = new OleDbCommand("insert into creditor_account(creditor_id,creditor_name,dr,cr,stock_date" +
                        ") values(" + creditor_id + ",'" + this.txtcreditorname.Text + "'," + Convert.ToDecimal(this.txtamount.Text) + "" +
                        ",0.00,'" + Convert.ToDateTime(this.dateTimePicker1.Value) + "')", Class1.Cn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Inserted");
                    this.txtamount.Text = "";
                    this.txtcreditorname.Text = "";
                }
                Class1.Cn.Close();
            }
            catch(Exception e1)
            {
                Class1.Cn.Close();
                MessageBox.Show(e1.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Class1.Cn.Open();
                OleDbCommand cmd = new OleDbCommand("select * from creditors where creditor_name='"+this.txtcreditorname.Text+"'", Class1.Cn);
                OleDbDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    flag++;
                }
                Class1.Cn.Close();
            }
            catch
            {
                Class1.Cn.Close();
            }
        }
        int creditors_id;
        public int creditorid(string creditor_name)
        {
           
            Class1.Cn.Open();
            OleDbCommand cmd = new OleDbCommand("select * from creditors where creditor_name='" + this.txtcreditorname.Text + "'", Class1.Cn);
            OleDbDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                creditors_id = rd.GetInt32(0);
            }
            rd.Close();
            Class1.Cn.Close();
            return creditors_id;
        }

        private void creditor_money_return_Load(object sender, EventArgs e)
        {
            Class1.Cn.Open();
            AutoCompleteStringCollection collection2 = new AutoCompleteStringCollection();
            OleDbCommand cmd2 = new OleDbCommand("select * from creditors", Class1.Cn);
            OleDbDataReader rd2 = cmd2.ExecuteReader();
            while (rd2.Read())
            {
                collection2.Add(rd2.GetValue(1).ToString());
            }
            this.txtcreditorname.AutoCompleteMode = AutoCompleteMode.Suggest;
            this.txtcreditorname.AutoCompleteSource = AutoCompleteSource.CustomSource;
            this.txtcreditorname.AutoCompleteCustomSource = collection2;
            rd2.Close();
            Class1.Cn.Close();
        }

    }
}
