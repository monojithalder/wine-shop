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
    public partial class insert_pack_detail : Form
    {
        public insert_pack_detail()
        {
            InitializeComponent();
        }
        private string barcode1;
        string type;
        private void insert_pack_detail_Load(object sender, EventArgs e)
        {
            Class1.Cn.Open();
            AutoCompleteStringCollection collection2 = new AutoCompleteStringCollection();
            OleDbCommand cmd2 = new OleDbCommand("select * from barcode", Class1.Cn);
            OleDbDataReader rd2 = cmd2.ExecuteReader();
            while (rd2.Read())
            {
                collection2.Add(rd2.GetValue(1).ToString());
            }
            this.txtproduct.AutoCompleteMode = AutoCompleteMode.Suggest;
            this.txtproduct.AutoCompleteSource = AutoCompleteSource.CustomSource;
            this.txtproduct.AutoCompleteCustomSource = collection2;
            rd2.Close();
            Class1.Cn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int flag = check_pack_detail(this.txtfullname.Text, this.txtshortname.Text, this.comboBox1.Text);
                string barcode = check_barcode(this.txtproduct.Text);
                string type = select_type(barcode);
                if (barcode != "")
                {
                    if (flag < 1)
                    {
                        Class1.Cn.Open();
                        string fullname = this.txtfullname.Text;
                        string shortname = this.txtshortname.Text;
                        decimal price = Convert.ToDecimal(this.txtprice.Text);
                        OleDbCommand cmd = new OleDbCommand("insert into pack_detail (name,short_name,price,size1,link_product,barcode,product_type)" +
                            " values ('" + fullname.ToLower() + "','" + shortname.ToLower() + "'," + price + ",'" + this.comboBox1.Text.ToLower() + "'," +
                            "'" + this.txtproduct.Text.ToLower() + "','" + barcode + "','" + type + "')", Class1.Cn);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Pack detail Inserted");
                        Class1.Cn.Close();
                    }
                    else
                    {
                        MessageBox.Show("Pack Name Already exsit");
                    }
                }
                else
                {
                    MessageBox.Show("Link Product Name Not Found");
                }
            }
            catch (Exception e1)
            {
                Class1.Cn.Close();
                MessageBox.Show(e1.Message);
            }

        }
        private int check_pack_detail(string fullname, string shortname, string size)
        {
            Class1.Cn.Open();
            int flag = 0;
            OleDbCommand cmd = new OleDbCommand("select * from pack_detail where name='" + fullname.ToLower() + "' and short_name='" + shortname.ToLower() + "' and size1='" + size + "'", Class1.Cn);
            OleDbDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                flag++;
            }
            Class1.Cn.Close();
            return flag;
        }
        private string check_barcode(string product_name)
        {
            Class1.Cn.Open();
            OleDbCommand cmd = new OleDbCommand("select * from barcode where product_name='" + product_name.ToLower() + "'", Class1.Cn);
            OleDbDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                barcode1 = rd.GetString(0);
            }
            Class1.Cn.Close();
            if (barcode1 != "")
            {
                return barcode1;
            }
            else
            {
                return "";
            }
        }
        private string select_type(string barcode)
        {
            Class1.Cn.Open();
            OleDbCommand cmd = new OleDbCommand("select * from barcode where barcode='" + barcode + "'", Class1.Cn);
            OleDbDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                type = rd.GetString(2);
            }
            rd.Close();
            Class1.Cn.Close();
            return type;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Class1.Cn.Open();
            OleDbCommand cmd = new OleDbCommand("select * from pack_detail where name='" + this.txtufullname.Text.ToLower() + "' and size1='" + this.comboBox2.Text + "'", Class1.Cn);
            OleDbDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                this.txtushortname.Text = rd.GetString(2);
                this.txtupackprice.Text = rd.GetValue(3).ToString();
                //this.txtulink.Text = rd.GetString(5);
            }
            rd.Close();
            Class1.Cn.Close();
            //this.txtufullname.ReadOnly = true;
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Class1.Cn.Open();
            OleDbCommand cmd = new OleDbCommand("update pack_detail set short_name='" + this.txtushortname.Text.ToLower() + "'" +
                ",price=" + Convert.ToDecimal(this.txtupackprice.Text) + " where name='" + this.txtufullname.Text.ToLower() + "'" +
                " and size1='" + this.comboBox2.Text + "'", Class1.Cn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Information Updated");
            Class1.Cn.Close();
        }
       
    }
}
