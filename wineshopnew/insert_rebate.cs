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
    public partial class insert_rebate : Form
    {
        public insert_rebate()
        {
            InitializeComponent();
        }
        int id;
        private void insert_rebate_Load(object sender, EventArgs e)
        {
            Class1.Cn.Open();
            AutoCompleteStringCollection collection2 = new AutoCompleteStringCollection();
            OleDbCommand cmd2 = new OleDbCommand("select * from creditors", Class1.Cn);
            OleDbDataReader rd2 = cmd2.ExecuteReader();
            while (rd2.Read())
            {
                collection2.Add(rd2.GetValue(1).ToString());
            }
            this.txtname.AutoCompleteMode = AutoCompleteMode.Suggest;
            this.txtname.AutoCompleteSource = AutoCompleteSource.CustomSource;
            this.txtname.AutoCompleteCustomSource = collection2;
            rd2.Close();
            Class1.Cn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int creditor_id = show_creditor_id(this.txtname.Text);
                Class1.Cn.Open();
                //OleDbCommand cmd = new OleDbCommand("insert into rebate(creditors_name,rebate_on_box,current_date" +
                //    ",duration,creditors_id) values ('" + this.txtname.Text + "'," + Convert.ToInt32(this.txtquantity.Text) + "" +
                //    ",'" + Convert.ToDateTime(this.dateTimePicker1.Value) + "'," + Convert.ToInt32(this.txtduration.Text) + "," + creditor_id + ")", Class1.Cn);
                string name = this.txtname.Text;
                int rebate_on_box = Convert.ToInt32(this.txtquantity.Text);
                DateTime current_date = Convert.ToDateTime(this.dateTimePicker1.Value);
                int duration = Convert.ToInt32(this.txtduration.Text);

                OleDbCommand cmd = new OleDbCommand("insert into rebate(creditors_name,rebate_on_box,current_date1" +
                    ",duration,creditors_id,rebate_box) values ('" + name + "'," + rebate_on_box + ",'" + current_date + "'," + duration + "," +
                    "" + creditor_id + "," + Convert.ToInt32(this.txtamount.Text) + ")", Class1.Cn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Rebate Inserted");
                Class1.Cn.Close();
            }
            catch (Exception e1)
            {
                Class1.Cn.Close();
                MessageBox.Show(e1.Message);
            }

        }
        private int show_creditor_id(string creditor_name)
        {
            //try
            //{
            Class1.Cn.Open();
            OleDbCommand cmd = new OleDbCommand("select * from creditors where creditor_name='" + creditor_name + "'", Class1.Cn);
            OleDbDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                id = rd.GetInt32(0);
            }
            rd.Close();
            Class1.Cn.Close();
            return id;
            //}
            //catch (Exception e1)
            //{
            //    MessageBox.Show(e1.Message);
            //}
        }
    }
}
