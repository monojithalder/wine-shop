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
    public partial class insert_opeingstock_manualy : Form
    {
        public insert_opeingstock_manualy()
        {
            InitializeComponent();
        }
        int bottle;
        public DataTable dt = null;

        //public DataTable dt1 = null;
        public BindingSource bs = null;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Class1.Cn.Open();
                string barcode = this.txtbarcode.Text;
                int ml_per_bottle = Convert.ToInt32(this.txtmlper.Text);
                int no_of_case = Convert.ToInt32(this.txtcase.Text);
                int no_lose_botle = Convert.ToInt32(this.txtlose.Text);
                int total_bottle = Convert.ToInt32(this.txttotalbol.Text);
                int total_ml = Convert.ToInt32(this.txttotalml.Text);
                Decimal origianl_price = Convert.ToDecimal(this.txtoriginal.Text);
                Decimal salling_price = Convert.ToDecimal(this.txtsale.Text);
                DateTime stock_date = DateTime.Now;
                DateTime today = DateTime.Now;
                Decimal i_charge = Convert.ToDecimal(this.txticharge.Text);
               OleDbCommand cmd = new OleDbCommand("insert into stock(barcode,product_type,ml_per_bottle,no_of_case," +
                    "no_of_lose_bottle,total_bottle,total_ml,original_price,salling_price,stock_date,invoice_no,i_charge,supplier_name,product_name,brand_name" +
                    ") values ('" + barcode + "','" + this.txttype.Text.ToLower() + "'," + ml_per_bottle + "," + no_of_case + "," + no_lose_botle + "" +
                    "," + total_bottle + "," + total_ml + "," + origianl_price + "," + salling_price + ",'" + stock_date + "'" +
                    ",'" + this.txtinvoice.Text + "'," + i_charge + ",'" + this.txtsup.Text.ToLower() + "','" + this.txtproname.Text.ToLower() + "','" + this.txtbrandname.Text + "')", Class1.Cn);
                cmd.ExecuteNonQuery();
                OleDbCommand cmd1 = new OleDbCommand("insert into opening_stock(product_ml,opening_date,product_name,product_price" +
                                   ",ml_per_bottle,product_type) values(" + total_ml + ",'" + today + "','" + this.txtproname.Text.ToLower() + "'," +
                                   "" + origianl_price + "," + ml_per_bottle + ",'" + this.txttype.Text.ToLower() + "')", Class1.Cn);
                cmd1.ExecuteNonQuery();
                cmd = new OleDbCommand("select * from stock order by id DESC", Class1.Cn);
                OleDbDataReader rd = cmd.ExecuteReader();
                rd.Read();
                int stock_id = rd.GetInt32(0);
                string invoice_no = rd.GetString(11);
                for (int i = 0; i < this.gridbatch.Rows.Count - 1; i++)
                {
                    string batch_no = this.gridbatch.Rows[i].Cells[0].Value.ToString();
                    cmd = new OleDbCommand("insert into batch_no (stock_id,invoice_no,batch_no) values (" + stock_id + ",'" + invoice_no + "','" + batch_no + "') ", Class1.Cn);
                    cmd.ExecuteNonQuery();
                }
                rd.Close();
                MessageBox.Show("Stock Inserted");
                Class1.Cn.Close();
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }

        private void txtbarcode_TextChanged(object sender, EventArgs e)
        {
            try
            {

                Class1.Cn.Open();
                OleDbCommand cmd = new OleDbCommand("select * from barcode where barcode='" + this.txtbarcode.Text + "'", Class1.Cn);
                OleDbDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    this.txttype.Text = rd.GetString(2);
                    this.txtproname.Text = rd.GetString(1);
                    this.txtmlper.Text = rd.GetInt32(3).ToString();
                    this.txtbrandname.Text = rd.GetString(4);
                }
                rd.Close();
                Class1.Cn.Close();
            }
            catch (Exception e1)
            {
                Class1.Cn.Close();
                MessageBox.Show(e1.Message);
            }
        }

        private void txtcase_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int ml_per_bottale = Convert.ToInt32(this.txtmlper.Text);
                string ml_per_bottle = "ml" + ml_per_bottale;
                int total_bottle = 0;
                int total_ml;
                Class1.Cn.Open();
                OleDbCommand cmd = new OleDbCommand("select * from setting where type='" + ml_per_bottle + "'", Class1.Cn);
                OleDbDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    bottle = Convert.ToInt32(rd.GetString(2));
                }
                total_bottle = Convert.ToInt32(this.txtcase.Text) * bottle;
                total_ml = ml_per_bottale * total_bottle;
                this.txttotalbol.Text = total_bottle.ToString();
                this.txttotalml.Text = total_ml.ToString();
                Class1.Cn.Close();
            }
            catch (Exception e1)
            {
                //    //MessageBox.Show(e1.Message);
                Class1.Cn.Close();
            }
        }

        private void txtlose_TextChanged(object sender, EventArgs e)
        {

            //try
            //{
            int ml_per_bottale = Convert.ToInt32(this.txtmlper.Text);
            string ml_per_bottle = "ml" + ml_per_bottale;
            int total_bottle = 0;
            int total_ml;
            Class1.Cn.Open();
            OleDbCommand cmd = new OleDbCommand("select * from setting where type='" + ml_per_bottle + "'", Class1.Cn);
            OleDbDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                bottle = Convert.ToInt32(rd.GetString(2));
            }
            total_bottle = Convert.ToInt32(this.txtcase.Text) * bottle + Convert.ToInt32(this.txtlose.Text);
            total_ml = ml_per_bottale * total_bottle;
            this.txttotalbol.Text = total_bottle.ToString();
            this.txttotalml.Text = total_ml.ToString();
            Class1.Cn.Close();
            //}
            //catch (Exception e1)
            //{
            //    //MessageBox.Show(e1.Message);
            //    Class1.Cn.Close();
            //}
        }

        private void txtsup_MouseClick(object sender, MouseEventArgs e)
        {
            creditor cr = new creditor();
            //delPassData del = new delPassData(cr.funData);
            //del(this.txtmlper);

            cr.AddressUpdated += new creditor.AddressUpdateHandler(AddressForm_ButtonClicked);
            cr.txtcdate.Text = this.txtsdate.Text;
            cr.Show();
        }

        private void txtsup_KeyUp(object sender, KeyEventArgs e)
        {
            creditor cr = new creditor();
            //delPassData del = new delPassData(cr.funData);
            //del(this.txtmlper);

            cr.AddressUpdated += new creditor.AddressUpdateHandler(AddressForm_ButtonClicked);
            cr.txtcdate.Text = this.txtsdate.Text;
            cr.Show();
        }
        private void AddressForm_ButtonClicked(object sender, wineshop_off_shop.creditor.AddressUpdateEventArgs e)
        {
            // update the forms values from the event args
            this.txtsup.Text = e._creditor;
        }

        private void insert_opeingstock_manualy_Load(object sender, EventArgs e)
        {
            dt = new DataTable();
            dt.Columns.Add("Batch_no                      ");
            bs = new BindingSource();
            bs.DataSource = dt;
            this.gridbatch.DataSource = bs;
        }
    }
}
