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
    public partial class creditor : Form
    {
        public creditor()
        {
            InitializeComponent();
        }
        public delegate void AddressUpdateHandler(object sender, AddressUpdateEventArgs e);
        public event AddressUpdateHandler AddressUpdated;
        OleDbConnection cn = new OleDbConnection("Provider = Microsoft.Jet.OLEDB.4.0; Data Source =" + Class1.path + "; Jet OLEDB:Database password = medicine");

        private void creditor_Load(object sender, EventArgs e)
        {
            Class1.Cn.Open();
            AutoCompleteStringCollection collection2 = new AutoCompleteStringCollection();
            OleDbCommand cmd2 = new OleDbCommand("select * from creditors", Class1.Cn);
            OleDbDataReader rd2 = cmd2.ExecuteReader();
            while (rd2.Read())
            {
                collection2.Add(rd2.GetValue(1).ToString());
            }
            this.txtcraditor.AutoCompleteMode = AutoCompleteMode.Suggest;
            this.txtcraditor.AutoCompleteSource = AutoCompleteSource.CustomSource;
            this.txtcraditor.AutoCompleteCustomSource = collection2;
            rd2.Close();
            Class1.Cn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int flag = check_creditor();
            if (flag > 0)
            {
                insert_creditorsacount();
                string cre = txtcraditor.Text;
                AddressUpdateEventArgs args = new AddressUpdateEventArgs(cre);
                AddressUpdated(this, args);
                this.Dispose();

            }
            else
            {
                insert_creditors();
                insert_creditorsacount();
                string cre = txtcraditor.Text;
                AddressUpdateEventArgs args = new AddressUpdateEventArgs(cre);
                AddressUpdated(this, args);
                this.Dispose();
            }
           
        }
        public void funData(TextBox txtForm1)
        {
            label1.Text = txtForm1.Text;
        }
        public class AddressUpdateEventArgs : System.EventArgs
        {
            // add local member variables to hold text
            private string cre;
            //private string mCity;
            //private string mState;
            //private string mZipCode;

            // class constructor
            public AddressUpdateEventArgs(string cre)
            {
                this.cre = cre;
                //this.mStreet = sStreet;
                //this.mCity = sCity;
                //this.mState = sState;
                //this.mZipCode = sZip;
            }

            // Properties - Viewable by each listener

            public string _creditor
            {
                get
                {
                    return cre;
                }
            }

            //public string City
            //{
            //    get
            //    {
            //        return mCity;
            //    }
            //}


            //public string State
            //{
            //    get
            //    {
            //        return mState;
            //    }
            //}

            //public string ZipCode
            //{
            //    get
            //    {
            //        return mZipCode;
            //    }
            //}
        }
        public int check_creditor()
        {
            int j=0;
            //Class1.Cn.Open();
            cn.Open();
            OleDbCommand cmd = new OleDbCommand("select * from creditors where creditor_name='"+this.txtcraditor.Text+"'", cn);
            OleDbDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                j++;
            }
            //Class1.Cn.Close();
            cn.Close();
            if (j > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public void insert_creditorsacount()
        {
            try
            {
                //Class1.Cn.Open();
                cn.Open();
                OleDbCommand cmd = new OleDbCommand("select * from creditors where creditor_name='" + this.txtcraditor.Text + "'",cn);
                OleDbDataReader rd = cmd.ExecuteReader();
                rd.Read();
                int cr_id = rd.GetInt32(0);
                Decimal cr = Convert.ToDecimal(this.txtcreditbalance.Text);
                DateTime stock_date = DateTime.Now;
                cmd = new OleDbCommand("insert into creditor_account (creditor_id,creditor_name,dr,cr,stock_date" +
                    ") values (" + cr_id + ",'" + this.txtcraditor.Text + "',0," + cr + ",'" + stock_date + "')", cn);
                cmd.ExecuteReader();
                rd.Close();
                cn.Close();
                //Class1.Cn.Close();
            }
            catch (Exception e1)
            {
                Class1.Cn.Close();
                MessageBox.Show(e1.Message);
            }

        }
        public void insert_creditors()
        {
            try
            {
            //    Class1.Cn.Open();
                cn.Open();
                OleDbCommand cmd = new OleDbCommand("insert into creditors (creditor_name) values ('" + this.txtcraditor.Text + "')", cn);
                cmd.ExecuteNonQuery();
                cn.Close();
            }
            catch (Exception e1)
            {
                Class1.Cn.Close();
                MessageBox.Show(e1.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

       
    }
}
