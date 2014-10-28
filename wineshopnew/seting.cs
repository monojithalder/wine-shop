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
    public partial class seting : Form
    {
        public seting()
        {
            InitializeComponent();
        }

        private void seting_Load(object sender, EventArgs e)
        {
            show_pack_size();
            show_ml_per_bottle();
            show_vat();
            show_stock();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            update_pack_size();
            update_ml_per_bottle();
            update_vat();
            update_stock();
            MessageBox.Show("Information Updated");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult diolog = MessageBox.Show("Are You Sure To Restore Default Settings", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (diolog == DialogResult.Yes)
            {
                Class1.Cn.Open();
                OleDbCommand cmd = new OleDbCommand("update setting set value1='30' where type='small_pack'", Class1.Cn);
                cmd.ExecuteNonQuery();
                cmd = new OleDbCommand("update setting set value1='60' where type='large_pack'", Class1.Cn);
                cmd.ExecuteNonQuery();
                cmd = new OleDbCommand("update setting set value1='6' where type='ml2000'", Class1.Cn);
                cmd.ExecuteNonQuery();
                cmd = new OleDbCommand("update setting set value1='9' where type='ml1000'", Class1.Cn);
                cmd.ExecuteNonQuery();
                cmd = new OleDbCommand("update setting set value1='12' where type='ml750'", Class1.Cn);
                cmd.ExecuteNonQuery();
                cmd = new OleDbCommand("update setting set value1='24' where type='ml500'", Class1.Cn);
                cmd.ExecuteNonQuery();
                cmd = new OleDbCommand("update setting set value1='24' where type='ml375'", Class1.Cn);
                cmd.ExecuteNonQuery();
                cmd = new OleDbCommand("update setting set value1='48' where type='ml180'", Class1.Cn);
                cmd.ExecuteNonQuery();
                cmd = new OleDbCommand("update setting set value1='24' where type='ml275'", Class1.Cn);
                cmd.ExecuteNonQuery();
                cmd = new OleDbCommand("update setting set value1='12' where type='ml650'", Class1.Cn);
                cmd.ExecuteNonQuery();
                cmd = new OleDbCommand("update setting set value1='14.5' where type='vat_persentage'", Class1.Cn);
                cmd.ExecuteNonQuery();
                cmd = new OleDbCommand("update setting set value1='yes' where type='vat_status'", Class1.Cn);
                cmd.ExecuteNonQuery();
                cmd = new OleDbCommand("update setting set value1='LIFO' where type='method'", Class1.Cn);
                cmd.ExecuteNonQuery();
                cmd = new OleDbCommand("update setting set value1='2' where type='stock_low'", Class1.Cn);
                cmd.ExecuteNonQuery();
                cmd = new OleDbCommand("update setting set value1='8' where type='stock_medium'", Class1.Cn);
                cmd.ExecuteNonQuery();
                cmd = new OleDbCommand("update setting set value1='9' where type='stock_high'", Class1.Cn);
                cmd.ExecuteNonQuery();
                Class1.Cn.Close();
                MessageBox.Show("Setting Restored");

            }
        }
        private void show_pack_size()
        {
            Class1.Cn.Open();
            OleDbCommand cmd = new OleDbCommand("select * from setting where type='small_pack'", Class1.Cn);
            OleDbDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                this.txtsmallpack.Text = rd.GetString(2);
            }
            rd.Close();
            cmd = new OleDbCommand("select * from setting where type='large_pack'", Class1.Cn);
            rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                this.txtlargepack.Text = rd.GetString(2);
            }
            rd.Close();
            Class1.Cn.Close();

        }
        private void update_pack_size()
        {
            Class1.Cn.Open();
            OleDbCommand cmd = new OleDbCommand("update setting set value1='" + this.txtsmallpack.Text + "' where type='small_pack'", Class1.Cn);
            cmd.ExecuteNonQuery();
            cmd = new OleDbCommand("update setting set value1='" + this.txtlargepack.Text + "' where type='large_pack'", Class1.Cn);
            cmd.ExecuteNonQuery();
            Class1.Cn.Close();
        }
        private void show_ml_per_bottle()
        {
            Class1.Cn.Open();
            OleDbCommand cmd = new OleDbCommand("select * from setting where type='ml2000'", Class1.Cn);
            OleDbDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                this.txt2000ml.Text = rd.GetString(2);
            }
            rd.Close();
            cmd = new OleDbCommand("select * from setting where type='ml1000'", Class1.Cn);
            rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                this.txt1000ml.Text = rd.GetString(2);
            }
            rd.Close();
            cmd = new OleDbCommand("select * from setting where type='ml750'", Class1.Cn);
            rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                this.txt750ml.Text = rd.GetString(2);
            }
            rd.Close();
            cmd = new OleDbCommand("select * from setting where type='ml500'", Class1.Cn);
            rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                this.txt500ml.Text = rd.GetString(2);
            }
            rd.Close();
            cmd = new OleDbCommand("select * from setting where type='ml375'", Class1.Cn);
            rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                this.txt375ml.Text = rd.GetString(2);
            }
            rd.Close();
            cmd = new OleDbCommand("select * from setting where type='ml180'", Class1.Cn);
            rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                this.txt180ml.Text = rd.GetString(2);
            }
            rd.Close();
            cmd = new OleDbCommand("select * from setting where type='ml275'", Class1.Cn);
            rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                this.txt275ml.Text = rd.GetString(2);
            }
            rd.Close();
            cmd = new OleDbCommand("select * from setting where type='ml650'", Class1.Cn);
            rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                this.txt650ml.Text = rd.GetString(2);
            }
            rd.Close();
            Class1.Cn.Close();
        }
        private void update_ml_per_bottle()
        {
            Class1.Cn.Open();
            OleDbCommand cmd = new OleDbCommand("update setting set value1='" + this.txt2000ml.Text + "' where type='ml2000'", Class1.Cn);
            cmd.ExecuteNonQuery();
            cmd = new OleDbCommand("update setting set value1='" + this.txt1000ml.Text + "' where type='ml1000'", Class1.Cn);
            cmd.ExecuteNonQuery();
            cmd = new OleDbCommand("update setting set value1='" + this.txt750ml.Text + "' where type='ml750'", Class1.Cn);
            cmd.ExecuteNonQuery();
            cmd = new OleDbCommand("update setting set value1='" + this.txt500ml.Text + "' where type='ml500'", Class1.Cn);
            cmd.ExecuteNonQuery();
            cmd = new OleDbCommand("update setting set value1='" + this.txt375ml.Text + "' where type='ml375'", Class1.Cn);
            cmd.ExecuteNonQuery();
            cmd = new OleDbCommand("update setting set value1='" + this.txt180ml.Text + "' where type='ml180'", Class1.Cn);
            cmd.ExecuteNonQuery();
            cmd = new OleDbCommand("update setting set value1='" + this.txt275ml.Text + "' where type='ml275'", Class1.Cn);
            cmd.ExecuteNonQuery();
            cmd = new OleDbCommand("update setting set value1='" + this.txt650ml.Text + "' where type='ml650'", Class1.Cn);
            cmd.ExecuteNonQuery();
            Class1.Cn.Close();
        }
        private void show_vat()
        {
            Class1.Cn.Open();
            OleDbCommand cmd = new OleDbCommand("select * from setting where type='vat_persentage'", Class1.Cn);
            OleDbDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                this.txtvatpersantage.Text = rd.GetString(2);
            }
            rd.Close();
            cmd = new OleDbCommand("select * from setting where type='vat_status'", Class1.Cn);
            rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                this.comboBox1.Text = rd.GetString(2);
            }
            rd.Close();
            Class1.Cn.Close();

        }
        private void update_vat()
        {
            Class1.Cn.Open();
            OleDbCommand cmd = new OleDbCommand("update setting set value1='" + this.txtvatpersantage.Text + "' where type='vat_persentage'", Class1.Cn);
            cmd.ExecuteNonQuery();
            cmd = new OleDbCommand("update setting set value1='" + this.comboBox1.Text + "' where type='vat_status'", Class1.Cn);
            cmd.ExecuteNonQuery();
            Class1.Cn.Close();

        }
        private void show_stock()
        {
            Class1.Cn.Open();
            OleDbCommand cmd = new OleDbCommand("select * from setting where type='method'", Class1.Cn);
            OleDbDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                this.comboBox2.Text = rd.GetString(2);
            }
            rd.Close();
            cmd = new OleDbCommand("select * from setting where type='stock_low'", Class1.Cn);
            rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                this.txtlow.Text = rd.GetString(2);
            }
            rd.Close();
            cmd = new OleDbCommand("select * from setting where type='stock_medium'", Class1.Cn);
            rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                this.txtmediam.Text = rd.GetString(2);
            }
            rd.Close();
            cmd = new OleDbCommand("select * from setting where type='stock_high'", Class1.Cn);
            rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                this.txthigh.Text = rd.GetString(2);
            }
            rd.Close();
            Class1.Cn.Close();

        }
        private void update_stock()
        {
            Class1.Cn.Open();
            OleDbCommand cmd = new OleDbCommand("update setting set value1='" + this.comboBox2.Text + "' where type='method'", Class1.Cn);
            cmd.ExecuteNonQuery();
            cmd = new OleDbCommand("update setting set value1='" + this.txtlow.Text + "' where type='stock_low'", Class1.Cn);
            cmd.ExecuteNonQuery();
            cmd = new OleDbCommand("update setting set value1='" + this.txtmediam.Text + "' where type='stock_medium'", Class1.Cn);
            cmd.ExecuteNonQuery();
            cmd = new OleDbCommand("update setting set value1='" + this.txthigh.Text + "' where type='stock_high'", Class1.Cn);
            cmd.ExecuteNonQuery();
            Class1.Cn.Close();
        }
    }
}
