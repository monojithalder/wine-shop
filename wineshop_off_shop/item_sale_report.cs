﻿using System;
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
    public partial class item_sale_report : Form
    {
        public item_sale_report()
        {
            InitializeComponent();
        }
        DataTable datatable = new DataTable();
        BindingSource bs = new BindingSource();
        int total_ml;
        private void item_sale_report_Load(object sender, EventArgs e)
        {
            Class1.Cn.Open();
            AutoCompleteStringCollection collection2 = new AutoCompleteStringCollection();
            OleDbCommand cmd2 = new OleDbCommand("select * from barcode", Class1.Cn);
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

            datatable.Columns.Add("Type");
            datatable.Columns.Add("Total_Ml");
            bs.DataSource = datatable;
            this.dataGridView1.DataSource = bs;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txttype.Text != "")
                {
                    datatable.Clear();
                    this.dataGridView1.DataSource = bs;
                    Class1.Cn.Open();
                    OleDbCommand cmd = new OleDbCommand("select * from billing", Class1.Cn);
                    OleDbDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        if (rd.GetDateTime(1).Year >= Convert.ToDateTime(this.dateTimePickerTo.Value).Year && rd.GetDateTime(1).Year <= Convert.ToDateTime(this.dateTimePickerFrom.Value).Year)
                        {
                            if (rd.GetDateTime(1).Month >= Convert.ToDateTime(this.dateTimePickerTo.Value).Month && rd.GetDateTime(1).Month <= Convert.ToDateTime(this.dateTimePickerFrom.Value).Month)
                            {
                                if (rd.GetDateTime(1).Date >= Convert.ToDateTime(this.dateTimePickerTo.Value).Date)
                                {
                                    if (rd.GetDateTime(1).Date <= Convert.ToDateTime(this.dateTimePickerFrom.Value).Date)
                                    {
                                        //if (rd.GetInt32(4) == 0)
                                        //{
                                        //    total_ml += rd.GetInt32(3) * rd.GetInt32(8);
                                        //}
                                        //else
                                        //{
                                        //    total_ml += rd.GetInt32(3);
                                        //}
                                        int a = rd.GetInt32(0);
                                        OleDbCommand cmd2 = new OleDbCommand("select * from bill_product where bill_no=" + rd.GetInt32(0) + " and product_name='" + this.txttype.Text + "'", Class1.Cn);
                                        OleDbDataReader rd2 = cmd2.ExecuteReader();
                                        while (rd2.Read())
                                        {
                                            if (rd2.GetString(2) == this.txttype.Text && Convert.ToInt32(this.txtmlperbottle.Text)==rd2.GetInt32(7))
                                            {
                                                total_ml += rd2.GetInt32(7)*rd2.GetInt32(4);
                                            }
                                        }
                                        rd2.Close();
                                    }
                                }
                            }
                        }
                    }

                    datatable.Rows.Add(this.txttype.Text, total_ml.ToString());
                    total_ml = 0;
                    Class1.Cn.Close();
                }
                else
                {
                    MessageBox.Show("Please Enter Product_type");
                }
            }
            catch (Exception e1)
            {
                Class1.Cn.Close();
                MessageBox.Show(e1.Message);
            }
        }
    }
}