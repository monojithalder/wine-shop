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
    public partial class barcode : Form
    {
        public barcode()
        {
            InitializeComponent();
        }
        DataTable dt = new DataTable();
        BindingSource bs = new BindingSource();
        int id;
        private void barcode_Load(object sender, EventArgs e)
        {
            Class1.Cn.Open();
            AutoCompleteStringCollection collection2 = new AutoCompleteStringCollection();
            OleDbCommand cmd2 = new OleDbCommand("select * from product_type", Class1.Cn);
            OleDbDataReader rd2 = cmd2.ExecuteReader();
            while (rd2.Read())
            {
                collection2.Add(rd2.GetValue(1).ToString());
            }
            this.txttype.AutoCompleteMode = AutoCompleteMode.Suggest;
            this.txttype.AutoCompleteSource = AutoCompleteSource.CustomSource;
            this.txttype.AutoCompleteCustomSource = collection2;
            rd2.Close();
            Class1.Cn.Close();
            //Class1.Cn.Open();
            //AutoCompleteStringCollection collection3 = new AutoCompleteStringCollection();
            //cmd2 = new OleDbCommand("select * from barcode", Class1.Cn);
            //OleDbDataReader rd3 = cmd2.ExecuteReader();
            //while (rd3.Read())
            //{
            //    collection3.Add(rd3.GetValue(4).ToString());
            //}
            //this.txttype.AutoCompleteMode = AutoCompleteMode.Suggest;
            //this.txttype.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //this.txttype.AutoCompleteCustomSource = collection3;
            //rd3.Close();
            //Class1.Cn.Close();
            dt.Columns.Add("Barcode No");
            dt.Columns.Add("Product Name");
            dt.Columns.Add("Type");
            dt.Columns.Add("Brand Name");
            dt.Columns.Add("Ml Per Bottle");
            bs.DataSource = dt;
            this.dataGridView1.DataSource = bs;
            barcode_show();
        }
        private void barcode_show()
        {
            dt.Clear();
            this.dataGridView1.DataSource = bs;
            Class1.Cn.Open();
            OleDbCommand cmd = new OleDbCommand("select * from barcode",Class1.Cn);
            OleDbDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                dt.Rows.Add(rd.GetValue(0),rd.GetString(1),rd.GetString(2),rd.GetString(4),rd.GetInt32(3));
            }
            rd.Read();
            Class1.Cn.Close();
        }
        private void button1_Click(object sender, EventArgs e)//insert button event
        {
            //try
            //{
            int flag = check_barcode(this.txtbarcode.Text);
            int flag2 = check_product(this.txtproname.Text,this.txttype.Text,Convert.ToInt32(this.txtmlper.Text));
            Class1.Cn.Open();
            if (flag < 1)
            {
                if (flag2 < 1)
                {
                    string barcode = this.txtbarcode.Text.ToString();
                    int ml_per_bottle = Convert.ToInt32(this.txtmlper.Text);
                    OleDbCommand cmd = new OleDbCommand("insert into barcode (barcode,product_name,product_type,ml_per_bottle,brand_name)"
                + " values ('" + barcode + "','" + this.txtproname.Text.ToLower() + "','" + this.txttype.Text + "'," + ml_per_bottle + ",'" + this.txtbrandname.Text + "')", Class1.Cn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Inserted");
                }
                else
                {
                    MessageBox.Show("Product Already Inserted");
                }
            }
            else
            {
                MessageBox.Show("Barcode Number Already In Use");
            }
            Class1.Cn.Close();
            barcode_show();
            //MessageBox.Show("knknkn");
            //}
            //catch (Exception e1)
            //{
            //    MessageBox.Show(e1.Message);
            //}
        }
        private int check_barcode(string barcode)
        {
            Class1.Cn.Open();
            int flag = 0;
            OleDbCommand cmd = new OleDbCommand("select * from barcode where barcode='"+barcode+"'",Class1.Cn);
            OleDbDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                flag++;
            }
            rd.Close();
            Class1.Cn.Close();
            return flag;
        }
        private int check_product(string product_name,string product_type,int ml)
        {
            Class1.Cn.Open();
            int flag = 0;
            OleDbCommand cmd = new OleDbCommand("select * from barcode where product_name='" + product_name + "' and product_type='"+product_type+"' and ml_per_bottle="+ml+"", Class1.Cn);
            OleDbDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                flag++;
            }
            rd.Close();
            Class1.Cn.Close();
            return flag;
        }
        //public void insert_packdetail()
        //{
        //    //try
        //    //{
        //    //    Class1.Cn.Open();
        //        string namesmall = this.txtproname.Text;
        //        string namebig = this.txtproname.Text;
        //        OleDbCommand cmd = new OleDbCommand("insert into pack_deatil (name,short_name,value,size "+
        //            ") values ('"+namesmall+"','"+this.txtshortname.Text.ToLower()+"',1,'small')",Class1.Cn);
        //        cmd.ExecuteNonQuery();
        //        cmd = new OleDbCommand("insert into pack_deatil (name,short_name,value,size " +
        //            ") values ('" + namebig + "','" + this.txtshortname.Text.ToLower() + "',2,'large')", Class1.Cn);
        //        cmd.ExecuteNonQuery();
        //        Class1.Cn.Close();

        //    //}
        //    //catch (Exception e1)
        //    //{
        //    //    MessageBox.Show(e1.Message);
        //    //}
        //}

        private void button2_Click(object sender, EventArgs e)// save button event
        {
            //try
            //{
                Class1.Cn.Open();
                OleDbCommand cmd = new OleDbCommand("update barcode set product_name='"+this.txtproname.Text.ToLower()+"',"+
                    "product_type='" + this.txttype.Text.ToLower() + "',ml_per_bottle="+Convert.ToInt32(this.txtmlper.Text)+""+
                    ",brand_name='"+this.txtbrandname.Text+"' where barcode='"+this.txtbarcode.Text+"'", Class1.Cn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Information Updated");
                Class1.Cn.Close();
                barcode_show();
            //}
            //catch (Exception e1)
            //{
            //    MessageBox.Show(e1.Message);
            //}
        }

        private void txtbarcode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Class1.Cn.Open();
                OleDbCommand cmd = new OleDbCommand("select * from barcode where barcode='"+this.txtbarcode.Text+"'",Class1.Cn);
                OleDbDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    this.txtmlper.Text = rd.GetInt32(3).ToString();
                    this.txtproname.Text = rd.GetString(1);
                    this.txttype.Text = rd.GetString(2);
                    this.txtbrandname.Text = rd.GetString(4);
                }
                rd.Close();
                Class1.Cn.Close();
            }
            catch
            {
                Class1.Cn.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)//change barcode button event
        {
            Class1.Cn.Open();
            OleDbCommand cmd = new OleDbCommand("update barcode set barcode='"+this.txtbarcode.Text+"' where product_name='"+this.txtproname.Text.ToLower()+"'and "+
                "product_type='"+this.txttype.Text+"' and ml_per_bottle="+Convert.ToInt32(this.txtmlper.Text)+"",Class1.Cn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("barcode Changed");
            
            Class1.Cn.Close();
            barcode_show();
        }
    }
}
