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
    public partial class insert_newproducttype : Form
    {
        public insert_newproducttype()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Class1.Cn.Open();
                int flag = 0;
                OleDbCommand cmd = new OleDbCommand("select * from product_type", Class1.Cn);
                OleDbDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    if (this.txtprotype.Text.ToLower() == rd.GetString(1))
                    {
                        //
                        flag++;
                    }

                }
                if (flag > 0)
                {
                    MessageBox.Show("Product Type Already Inserted");
                }
                else
                {
                    cmd = new OleDbCommand("insert into product_type (product_type) values ('" + this.txtprotype.Text.ToLower() + "')", Class1.Cn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Product Type Inserted");
                    this.txtprotype.Text = "";
                }
                rd.Close();
                Class1.Cn.Close();

            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }

        private void insert_newproducttype_Load(object sender, EventArgs e)
        {

        }

       
    }
}
