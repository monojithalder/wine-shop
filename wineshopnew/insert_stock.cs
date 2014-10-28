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
    public partial class insert_stock : Form
    {
        public insert_stock()
        {
            
            InitializeComponent();
            
        }
        public DataTable dt = null;

        //public DataTable dt1 = null;
        public BindingSource bs = null;
        //public OleDbConnection Cn;
        //public delegate void delPassData(TextBox text);
        int bottle = 0;
        private void insert_stock_Load(object sender, EventArgs e)
        {
            //Cn = new OleDbConnection("Provider = Microsoft.Jet.OLEDB.4.0; Data Source =" + Class1.path + "; Jet OLEDB:Database password = medicine");
            dt = new DataTable();
            dt.Columns.Add("Batch_no                      ");
            bs = new BindingSource();
            bs.DataSource = dt;
            this.gridbatch.DataSource = bs;
        }

        private void txtsup_MouseClick(object sender, MouseEventArgs e)
        {
            creditor cr = new creditor();
            //delPassData del = new delPassData(cr.funData);
            //del(this.txtmlper);

            cr.AddressUpdated += new creditor.AddressUpdateHandler(AddressForm_ButtonClicked);
            cr.txtcdate.Text = this.txtsdate.Value.ToShortDateString();
            cr.Show();
            //this.txtsup.Text = cr.txtcraditor.Text;
        }
        private void AddressForm_ButtonClicked(object sender, wineshopnew.creditor.AddressUpdateEventArgs e)
        {
            // update the forms values from the event args
            this.txtsup.Text = e._creditor;
        }
        public string abc;
        public void send_data()
        {
            this.txtsup.Text = Class1.temp;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //try
            //{
            int flag = check_barcode(this.txtbarcode.Text);
            int flag2 = check_null();
            if (flag2 < 1)
            {
                if (flag == 1)
                {
                    insert_stock1();
                    insert_mainstock();
                    insert_reccipt();
                    insert_icharge();
                    //insert_creditor();
                    insert_batchno();
                    insert_stockacount();
                    insert_pass_no();
                    MessageBox.Show("Stock Inserted");
                    this.txtbarcode.Text = "";
                    this.txtbrandname.Text = "";
                    this.txtcase.Text = "0";
                    this.txticharge.Text = "0";
                    this.txtinvoice.Text = "";
                    this.txtlose.Text = "0";
                    this.txtmlper.Text = "0";
                    this.txtoriginal.Text = "0";
                    this.txtpassno.Text = "";
                    this.txtproname.Text = "";
                    this.txtsale.Text = "0";
                    this.txtsup.Text = "";

                }
                else
                {
                    insert_barcode();
                    insert_stock1();
                    insert_mainstock();
                    insert_reccipt();
                    insert_icharge();
                    //insert_creditor();
                    insert_batchno();
                    insert_stockacount();
                    insert_pass_no();
                    MessageBox.Show("Stock Inserted");
                    this.txtbarcode.Text = "";
                    this.txtbrandname.Text = "";
                    this.txtcase.Text = "0";
                    this.txticharge.Text = "0";
                    this.txtinvoice.Text = "";
                    this.txtlose.Text = "0";
                    this.txtmlper.Text = "0";
                    this.txtoriginal.Text = "0";
                    this.txtpassno.Text = "";
                    this.txtproname.Text = "";
                    this.txtsale.Text = "0";
                    this.txtsup.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Pls Enter All data");
            }

            //}
            //catch (Exception e1)
            //{
            //    MessageBox.Show(e1.Message);
            //}

        }

        private void txtsup_KeyUp(object sender, KeyEventArgs e)
        {
            creditor cr = new creditor();
            //delPassData del = new delPassData(cr.funData);
            //del(this.txtmlper);

            cr.AddressUpdated += new creditor.AddressUpdateHandler(AddressForm_ButtonClicked);
            cr.txtcdate.Text = this.txtsdate.Value.ToShortDateString();
            cr.Show();
        }
        private void insert_pass_no()
        {
            Class1.Cn.Open();
            OleDbCommand cmd = new OleDbCommand("insert into pass_no (invoice_no,pass_no) values ('" + this.txtinvoice.Text + "','" + this.txtpassno.Text + "')", Class1.Cn);
            cmd.ExecuteNonQuery();
            Class1.Cn.Close();
        }
        public int check_barcode(string barcode)
        {
            //try
            //{
            Class1.Cn.Open();
            int flag = 0;
            OleDbCommand cmd = new OleDbCommand("select * from barcode where barcode='" + barcode + "'", Class1.Cn);
            OleDbDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                flag++;
            }
            rd.Close();
            Class1.Cn.Close();
            if (flag > 0)
            {
                return 1;

            }
            else
            {
                return 0;
            }


            //}
            //catch(Exception e)
            //{
            //    MessageBox.Show(e.Message);
            //}
        }
        public int check_null()
        {
            int j = 0;
            for (int i = 0; i < this.gridbatch.Rows.Count - 1; i++)
            {
                j++;
            }
            if (this.txtbarcode.Text == "")
            {
                MessageBox.Show("Please Enter Barcode");
                return 1;
            }
            else if (this.txtcase.Text == "")
            {
                MessageBox.Show("Please Enter Case");
                return 1;
            }
            else if (this.txtinvoice.Text == "")
            {
                MessageBox.Show("Please Enter Invoice No");
                return 1;
            }
            //else if (this.txtlose.Text == "")
            //{
            //    MessageBox.Show("Please Enter ");
            //    return 1;
            //}
            else if (this.txtmlper.Text == "")
            {
                MessageBox.Show("Please Enter Ml PerBottle");
                return 1;
            }
            else if (this.txtoriginal.Text == "")
            {
                MessageBox.Show("Please Enter Original Price");
                return 1;
            }
            else if (this.txtsale.Text == "")
            {
                MessageBox.Show("Please Enter Salling Price");
                return 1;
            }
            else if (this.txtsup.Text == "")
            {
                MessageBox.Show("Please Enter Suplier");
                return 1;
            }
            //else if (this.txttotalbol.Text == "")
            //{
            //    MessageBox.Show("Please Enter Barcode");
            //    return 1;
            //}
            //else if (this.txttotalml.Text == "")
            //{
            //    MessageBox.Show("Please Enter Barcode");
            //    return 1;
            //}
            else if (this.txttype.Text == "")
            {
                MessageBox.Show("Please Enter Product Type");
                return 1;
            }
            //else if (this.txtsdate.Text == "")
            //{
            //    MessageBox.Show("Please Enter Stock Date");
            //    return 1;
            //}
            else if (this.txtproname.Text == "")
            {
                MessageBox.Show("Please Enter Product Name");
                return 1;
            }
            else if (j == 0)
            {
                MessageBox.Show("Please Enter Batch No");
                return 1;
            }
            else if (this.txticharge.Text == "")
            {
                MessageBox.Show("Please Enter I Charge");
                return 1;
            }
            else
            {
                return 0;
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
        public void insert_barcode()
        {
            //try
            //{
            Class1.Cn.Open();
            OleDbCommand cmd = new OleDbCommand("insert into barcode(barcode,product_name,product_type,ml_per_bottle,brand_name)" +
            " values ('" + this.txtbarcode.Text + "','" + this.txtproname.Text.ToLower() + "'," +
            "'" + this.txttype.Text.ToLower() + "'," + Convert.ToInt32(this.txtmlper.Text) + ",'" + this.txtbrandname.Text + "')", Class1.Cn);
            cmd.ExecuteNonQuery();
            Class1.Cn.Close();
            //insert_stock1();
            //insert_mainstock();
            //insert_reccipt();
            //insert_icharge();
            //insert_creditor();
            //insert_batchno();
            //insert_stockacount();
            //}
            //catch (Exception e1)
            //{
            //    Class1.Cn.Close();
            //    MessageBox.Show(e1.Message);

            //}
        }
        public void insert_stock1()
        {
            //try
            //{
            Class1.Cn.Open();
            string barcode = this.txtbarcode.Text;
            int ml_per_bottle = Convert.ToInt32(this.txtmlper.Text);
            int no_of_case = Convert.ToInt32(this.txtcase.Text);
            int no_lose_botle = Convert.ToInt32(this.txtlose.Text);
            int total_bottle = Convert.ToInt32(this.txttotalbol.Text);
            int total_ml = Convert.ToInt32(this.txttotalml.Text);
            Decimal origianl_price = Convert.ToDecimal(this.txtoriginal.Text);
            Decimal salling_price = Convert.ToDecimal(this.txtsale.Text);
            DateTime stock_date = Convert.ToDateTime(this.txtsdate.Value);
            Decimal i_charge = Convert.ToDecimal(this.txticharge.Text);
            OleDbCommand cmd = new OleDbCommand("insert into stock (barcode,product_type,ml_per_bottle,no_of_case," +
                "no_of_lose_bottle,total_bottle,total_ml,original_price,salling_price,stock_date,invoice_no,i_charge,supplier_name,product_name,brand_name" +
                ") values ('" + barcode + "','" + this.txttype.Text.ToLower() + "'," + ml_per_bottle + "," + no_of_case + "," + no_lose_botle + "" +
                "," + total_bottle + "," + total_ml + "," + origianl_price + "," + salling_price + ",'" + stock_date + "'" +
                ",'" + this.txtinvoice.Text + "'," + i_charge + ",'" + this.txtsup.Text.ToLower() + "','" + this.txtproname.Text.ToLower() + "','" + this.txtbrandname.Text + "')", Class1.Cn);
            cmd.ExecuteNonQuery();
            Class1.Cn.Close();
            //}
            //catch (Exception e1)
            //{
            //    Class1.Cn.Close();
            //    MessageBox.Show(e1.Message);
            //}
        }
        public void insert_mainstock()
        {
            //try
            //{
            Class1.Cn.Open();
            string barcode = this.txtbarcode.Text;
            int ml_per_bottle = Convert.ToInt32(this.txtmlper.Text);
            int no_of_case = Convert.ToInt32(this.txtcase.Text);
            int no_lose_botle = Convert.ToInt32(this.txtlose.Text);
            int total_bottle = Convert.ToInt32(this.txttotalbol.Text);
            int total_ml = Convert.ToInt32(this.txttotalml.Text);
            Decimal origianl_price = Convert.ToDecimal(this.txtoriginal.Text);
            Decimal salling_price = Convert.ToDecimal(this.txtsale.Text);
            DateTime stock_date = Convert.ToDateTime(this.txtsdate.Value);
            Decimal i_charge = Convert.ToDecimal(this.txticharge.Text);
            OleDbCommand cmd = new OleDbCommand("insert into main_stock(barcode,product_type,ml_per_bottle,no_of_case," +
                "no_of_lose_bottle,total_bottle,total_ml,original_price,salling_price,stock_date,invoice_no,i_charge,supplier_name,product_name,brand_name" +
                ") values ('" + barcode + "','" + this.txttype.Text.ToLower() + "'," + ml_per_bottle + "," + no_of_case + "," + no_lose_botle + "" +
                "," + total_bottle + "," + total_ml + "," + origianl_price + "," + salling_price + ",'" + stock_date + "'" +
                ",'" + this.txtinvoice.Text + "'," + i_charge + ",'" + this.txtsup.Text.ToLower() + "','" + this.txtproname.Text.ToLower() + "','" + this.txtbrandname.Text + "')", Class1.Cn);
            cmd.ExecuteNonQuery();
            Class1.Cn.Close();
            //}
            //catch (Exception e1)
            //{
            //    Class1.Cn.Close();
            //    MessageBox.Show(e1.Message);
            //}
        }
        //public void insert_creditor()
        //{
        //}
        public void insert_batchno()
        {
            //try
            //{
            Class1.Cn.Open();
            OleDbCommand cmd = new OleDbCommand("select * from stock order by id DESC", Class1.Cn);
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
            Class1.Cn.Close();
            //}
            //catch (Exception e1)
            //{
            //    Class1.Cn.Close();
            //    MessageBox.Show(e1.Message);
            //}
        }
        public void insert_reccipt()
        {
            //try
            //{
            Class1.Cn.Open();
            string barcode = this.txtbarcode.Text;
            int ml_per_bottle = Convert.ToInt32(this.txtmlper.Text);
            int no_of_case = Convert.ToInt32(this.txtcase.Text);
            int no_lose_botle = Convert.ToInt32(this.txtlose.Text);
            int total_bottle = Convert.ToInt32(this.txttotalbol.Text);
            int total_ml = Convert.ToInt32(this.txttotalml.Text);
            //Decimal origianl_price = Convert.ToDecimal(this.txtoriginal.Text);
            //Decimal salling_price = Convert.ToDecimal(this.txtsale.Text);
            DateTime stock_date = Convert.ToDateTime(this.txtsdate.Value);
            //Decimal i_charge = Convert.ToDecimal(this.txticharge.Text);
            // Class1.Cn.Open();
            OleDbCommand cmd = new OleDbCommand("select * from stock order by id DESC", Class1.Cn);
            OleDbDataReader rd = cmd.ExecuteReader();
            rd.Read();
            string invoice_no = rd.GetString(11);
            int stock_id = rd.GetInt32(0);
            cmd = new OleDbCommand("insert into recipt (invoice_no,product_name,product_type,product_size,num_of_bottle" +
                ",num_of_case,total_ml,recipt_date,stock_id) values ('" + invoice_no + "','" + this.txtproname.Text.ToLower() + "'" +
                ",'" + this.txttype.Text.ToLower() + "'," + ml_per_bottle + "," + total_bottle + "," + no_of_case + "," + total_ml + ",'" + stock_date + "'," + stock_id + ") ", Class1.Cn);
            cmd.ExecuteNonQuery();
            rd.Close();
            Class1.Cn.Close();
            //}
            //catch (Exception e1)
            //{
            //    Class1.Cn.Close();
            //    MessageBox.Show(e1.Message);
            //}

        }
        public void insert_icharge()
        {
            //try
            //{
            Decimal i_charge = Convert.ToDecimal(this.txticharge.Text);
            Decimal origianl_price = Convert.ToDecimal(this.txtoriginal.Text);
            //Decimal salling_price = Convert.ToDecimal(this.txtsale.Text);
            int total_bottle = Convert.ToInt32(this.txttotalbol.Text);
            Decimal total_cost = total_bottle * origianl_price;
            Decimal icharge_persentage = (i_charge * 100) / total_cost;
            DateTime stock_date = Convert.ToDateTime(this.txtsdate.Value);
            Class1.Cn.Open();
            OleDbCommand cmd = new OleDbCommand("select * from stock order by id DESC", Class1.Cn);
            OleDbDataReader rd = cmd.ExecuteReader();
            rd.Read();
            string invoice_no = rd.GetString(11);
            int stock_id = rd.GetInt32(0);
            cmd = new OleDbCommand("insert into icharge (invoice_no,total_amount,icharge_persentage,total_icharge" +
                ",stock_id,stock_date) values ('" + invoice_no + "'," + total_cost + "," + icharge_persentage + "," + i_charge + "" +
                "," + stock_id + ",'" + stock_date + "')", Class1.Cn);
            cmd.ExecuteNonQuery();
            rd.Close();
            Class1.Cn.Close();

            //}
            //catch (Exception e1)
            //{
            //    Class1.Cn.Close();
            //    MessageBox.Show(e1.Message);
            //}

        }
        public void insert_stockacount()
        {
            Decimal origianl_price = Convert.ToDecimal(this.txtoriginal.Text);
            //Decimal salling_price = Convert.ToDecimal(this.txtsale.Text);
            int total_bottle = Convert.ToInt32(this.txttotalbol.Text);
            Decimal total_cost = total_bottle * origianl_price;
            DateTime stock_date = Convert.ToDateTime(this.txtsdate.Value);
            Class1.Cn.Open();
            OleDbCommand cmd = new OleDbCommand("select * from stock order by id DESC", Class1.Cn);
            OleDbDataReader rd = cmd.ExecuteReader();
            rd.Read();
            string invoice_no = rd.GetString(11);
            int stock_id = rd.GetInt32(0);
            cmd = new OleDbCommand("insert into stock_acount (stock_id,number_of_bottle,per_bottle_price" +
                ",total_price,stock_date,suplier_name,invoice_no) values (" + stock_id + "," + total_bottle + "," + origianl_price + "" +
                "," + total_cost + ",'" + stock_date + "','" + this.txtsup.Text.ToLower() + "','" + invoice_no + "')", Class1.Cn);
            cmd.ExecuteNonQuery();
            rd.Close();
            Class1.Cn.Close();

        }
        public void insert_packdetail()
        {
            try
            {
            }
            catch (Exception e1)
            {
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
                total_bottle = Convert.ToInt32(this.txtcase.Text) * bottle + Convert.ToInt32(this.txtlose.Text);
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

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void txticharge_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtproname_TextChanged(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

       
        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void txtbrandname_TextChanged(object sender, EventArgs e)
        {

        }

        private void gridbatch_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtmlper_TextChanged(object sender, EventArgs e)
        {

        }

        private void txttotalbol_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtoriginal_TextChanged(object sender, EventArgs e)
        {

        }

        private void txttotalml_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtsup_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtinvoice_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtsale_TextChanged(object sender, EventArgs e)
        {

        }

        private void txttype_TextChanged(object sender, EventArgs e)
        {

        }


      
       
    }
}
