using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Drawing.Printing;

namespace wineshopnew
{
    public partial class show_profitandloss : Form
    {
        public show_profitandloss()
        {
            InitializeComponent();
        }
        DataTable dt = new DataTable();
        BindingSource bs = new BindingSource();
        decimal purchase_amount = 0;
        decimal opening_amount = 0;
        decimal sale_amount = 0;
        decimal closing_amount = 0;
        decimal exp = 0;
        decimal dr = 0;
        decimal cr = 0;
        PrintDocument pd;
        private void show_profitandloss_Load(object sender, EventArgs e)
        {
            dt.Columns.Add("Head");
            dt.Columns.Add("Dr");
            dt.Columns.Add("Cr");
            bs.DataSource = dt;
            this.dataGridView1.DataSource = bs;
            this.dataGridView1.Columns[0].Width = 200;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dt.Clear();
            this.dataGridView1.DataSource = bs;
            decimal purchase = purchase_stock_price();
            int pur_ml = purchase_stock_ml();
            decimal opening = opening_stock_price();
            int ope_ml = opening_stock_ml();
            decimal sale = sale_stock_price();
            int sale_ml = sale_stock_ml();
            decimal closing = closing_stock_price();
            int clo_ml = closing_stock_ml();
            decimal exp=expenses();
            dt.Rows.Add("Opeing Stock  " + ope_ml + "ML", opening.ToString("00.00"), 0);
            dt.Rows.Add("Purchese Stock  " + pur_ml + "ML", purchase.ToString("00.00"), 0);
            dt.Rows.Add("Sale " + sale_ml + "ML", 0, sale);
            dt.Rows.Add("Expenses",exp,0);
            dt.Rows.Add("Closing Stock " + clo_ml + "ML", 0, closing.ToString("00.00"));
            purchase_amount = 0;
            opening_amount = 0;
            sale_amount = 0;
            closing_amount = 0;
            for (int i = 0; i < this.dataGridView1.Rows.Count - 1; i++)
            {
                dr += Convert.ToDecimal(this.dataGridView1.Rows[i].Cells[1].Value);
                cr += Convert.ToDecimal(this.dataGridView1.Rows[i].Cells[2].Value);

            }
            if (dr > cr)
            {
                dt.Rows.Add("To Loss", "", (dr - cr).ToString("00.00"));
                dt.Rows.Add("Total", dr.ToString("00.00"), dr.ToString("00.00"));
            }
            else if (cr > dr)
            {
                dt.Rows.Add("To Profit", (cr - dr).ToString("00.00"), "");
                dt.Rows.Add("Total", cr.ToString("00.00"), cr.ToString("00.00"));
            }
            this.button2.Enabled = true;
            dr = 0;
            cr = 0;

        }
        private decimal purchase_stock_price()
        {
            DateTime date = Convert.ToDateTime(this.dateTimePicker1.Value);
            //int total_ml = 0;
            Class1.Cn.Open();
            OleDbCommand cmd = new OleDbCommand("select * from main_stock", Class1.Cn);
            OleDbDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                if (rd.GetDateTime(10).Year == date.Year && rd.GetDateTime(10).Month == date.Month)
                {

                    purchase_amount += rd.GetInt32(6) * Convert.ToDecimal(rd.GetValue(8));
                    //total_ml = rd.GetInt32(7);
                }
            }
            rd.Close();
            Class1.Cn.Close();
            return purchase_amount;
        }
        private int purchase_stock_ml()
        {
            DateTime date = Convert.ToDateTime(this.dateTimePicker1.Value);
            int total_ml = 0;
            Class1.Cn.Open();
            OleDbCommand cmd = new OleDbCommand("select * from main_stock", Class1.Cn);
            OleDbDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                if (rd.GetDateTime(10).Year == date.Year && rd.GetDateTime(10).Month == date.Month)
                {

                    //purchase_amount += rd.GetInt32(6) * Convert.ToDecimal(rd.GetValue(8));
                    total_ml = rd.GetInt32(7);
                }
            }
            rd.Close();
            Class1.Cn.Close();
            return total_ml;
        }
        private decimal opening_stock_price()
        {
            DateTime date = Convert.ToDateTime(this.dateTimePicker1.Value);
            // int total_ml = 0;
            decimal temp;
            Class1.Cn.Open();
            OleDbCommand cmd = new OleDbCommand("select * from opening_stock", Class1.Cn);
            OleDbDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                if (rd.GetDateTime(2).Year == date.Year && rd.GetDateTime(2).Month == date.Month)
                {

                    temp = Convert.ToDecimal(rd.GetValue(4)) / rd.GetInt32(5);
                    opening_amount += rd.GetInt32(1) * temp;
                    //total_ml = rd.GetInt32(7);
                }
            }
            rd.Close();
            Class1.Cn.Close();
            return opening_amount;
        }
        private int opening_stock_ml()
        {
            DateTime date = Convert.ToDateTime(this.dateTimePicker1.Value);
            int total_ml = 0;
            Class1.Cn.Open();
            OleDbCommand cmd = new OleDbCommand("select * from opening_stock", Class1.Cn);
            OleDbDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                if (rd.GetDateTime(2).Year == date.Year && rd.GetDateTime(2).Month == date.Month)
                {

                    //purchase_amount += rd.GetInt32(6) * Convert.ToDecimal(rd.GetValue(8));
                    total_ml += rd.GetInt32(1);
                }
            }
            rd.Close();
            Class1.Cn.Close();
            return total_ml;
        }
        private decimal sale_stock_price()
        {
            DateTime date = Convert.ToDateTime(this.dateTimePicker1.Value);
            // int total_ml = 0;
            decimal temp;
            Class1.Cn.Open();
            OleDbCommand cmd = new OleDbCommand("select * from bill_product", Class1.Cn);
            OleDbDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                OleDbCommand cmd1 = new OleDbCommand("select * from billing", Class1.Cn);
                OleDbDataReader rd1 = cmd1.ExecuteReader();
                rd1.Read();
                if (rd1.GetDateTime(1).Year == date.Year && rd1.GetDateTime(1).Month == date.Month)
                {

                    //temp = Convert.ToDecimal(rd.GetValue(4)) / rd.GetInt32(5);
                    sale_amount += Convert.ToDecimal(rd.GetValue(3));
                    //total_ml = rd.GetInt32(7);
                }
                rd1.Close();
            }
            rd.Close();
            Class1.Cn.Close();
            return sale_amount;
        }
        private int sale_stock_ml()
        {
            DateTime date = Convert.ToDateTime(this.dateTimePicker1.Value);
            int total_ml = 0;
            Class1.Cn.Open();
            OleDbCommand cmd = new OleDbCommand("select * from table_product", Class1.Cn);
            OleDbDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                OleDbCommand cmd1 = new OleDbCommand("select * from billing", Class1.Cn);
                OleDbDataReader rd1 = cmd1.ExecuteReader();
                rd1.Read();
                if (rd1.GetDateTime(1).Year == date.Year && rd1.GetDateTime(1).Month == date.Month)
                {

                    //purchase_amount += rd.GetInt32(6) * Convert.ToDecimal(rd.GetValue(8));
                    total_ml += rd.GetInt32(7)*rd.GetInt32(6);
                }
                rd1.Close();
            }
            rd.Close();
            Class1.Cn.Close();
            return total_ml;
        }
        private decimal closing_stock_price()
        {
            DateTime date = Convert.ToDateTime(this.dateTimePicker1.Value);
            // int total_ml = 0;
            decimal temp;
            Class1.Cn.Open();
            OleDbCommand cmd = new OleDbCommand("select * from closing_stock", Class1.Cn);
            OleDbDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                if (rd.GetDateTime(2).Year == date.Year && rd.GetDateTime(2).Month == date.Month)
                {

                    temp = Convert.ToDecimal(rd.GetValue(4)) / rd.GetInt32(5);
                    closing_amount += rd.GetInt32(1) * temp;
                    //total_ml = rd.GetInt32(7);
                }
            }
            rd.Close();
            Class1.Cn.Close();
            return closing_amount;
        }
        private int closing_stock_ml()
        {
            DateTime date = Convert.ToDateTime(this.dateTimePicker1.Value);
            int total_ml = 0;
            Class1.Cn.Open();
            OleDbCommand cmd = new OleDbCommand("select * from closing_stock", Class1.Cn);
            OleDbDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                if (rd.GetDateTime(2).Year == date.Year && rd.GetDateTime(2).Month == date.Month)
                {

                    //purchase_amount += rd.GetInt32(6) * Convert.ToDecimal(rd.GetValue(8));
                    total_ml += rd.GetInt32(1);
                }
            }
            rd.Close();
            Class1.Cn.Close();
            return total_ml;
        }
        private decimal expenses()
        {
            DateTime date = Convert.ToDateTime(this.dateTimePicker1.Value);
            decimal expenses = 0;
            Class1.Cn.Open();
            OleDbCommand cmd = new OleDbCommand("select * from incexp", Class1.Cn);
            OleDbDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                if (rd.GetDateTime(2).Year == date.Year && rd.GetDateTime(2).Month == date.Month)
                {

                    //purchase_amount += rd.GetInt32(6) * Convert.ToDecimal(rd.GetValue(8));
                    expenses += Convert.ToDecimal(rd.GetValue(4));
                }
            }
            rd.Close();
            Class1.Cn.Close();
            return expenses;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            PaperSize pz = new PaperSize();
            pz.Height = 500;
            pz.Width = 600;
            pd = new PrintDocument();
            pd.DefaultPageSettings.PaperSize = pz;
            pd.PrintPage += new PrintPageEventHandler(this.pd_print);
            pd.Print();
        }
        public void pd_print(object obj, PrintPageEventArgs pe)
        {


            Graphics graphics = pe.Graphics;
            int startX = 0;
            int startY = 0;
            int Offset = 15;
            int tempx = 0;
            int tempx2 = 0;

            string line = "--------------------------------------------------------------------------------------------";
            string name = "PUJA F.L ON SHOP";
            string ph = "ph:-03324430207";
            string address = "(SMT-BINTA PROSAD GAZOLE,MALDA)";
            graphics.DrawString(name, new Font("Courier New", 10), new SolidBrush(Color.Black), startX + 100, startY);
            graphics.DrawString(ph, new Font("Courier New", 5), new SolidBrush(Color.Black), startX + 250, startY);
            graphics.DrawString("Date" + DateTime.Now.ToShortDateString() + "   " + DateTime.Now.ToShortTimeString(), new Font("Courier New", 5), new SolidBrush(Color.Black), startX + 450, startY);
            graphics.DrawString(address, new Font("Courier New", 5), new SolidBrush(Color.Black), startX + 100, startY + 10);
            graphics.DrawString("PROFIT AND LOSS ACCOUNT", new Font("Courier New", 10), new SolidBrush(Color.Black), startX + 250, startY + Offset);
            Offset += 15;
            graphics.DrawString(line, new Font("Courier New", 8), new SolidBrush(Color.Black), startX, startY + Offset);
            Offset += 15;
            graphics.DrawString("HEAD", new Font("Courier New", 8), new SolidBrush(Color.Black), startX + 10, startY + Offset);
            graphics.DrawString("DR", new Font("Courier New", 8), new SolidBrush(Color.Black), startX + 310, startY + Offset);
            graphics.DrawString("CR", new Font("Courier New", 8), new SolidBrush(Color.Black), startX + 400, startY + Offset);
            Offset += 15;
            graphics.DrawString(line, new Font("Courier New", 8), new SolidBrush(Color.Black), startX, startY + Offset);
            Offset += 15;
            // total = 0;
            for (int i = 0; i < this.dataGridView1.Rows.Count - 1; i++)
            {


                //total += Convert.ToDouble(this.dataGridView1.Rows[i].Cells[2].Value);
                graphics.DrawString(this.dataGridView1.Rows[i].Cells[0].Value.ToString().ToUpper(), new Font("Courier New", 8), new SolidBrush(Color.Black), startX + 10, startY + Offset);
                graphics.DrawString(this.dataGridView1.Rows[i].Cells[1].Value.ToString(), new Font("Courier New", 8), new SolidBrush(Color.Black), startX + 310, startY + Offset);
                graphics.DrawString(this.dataGridView1.Rows[i].Cells[2].Value.ToString(), new Font("Courier New", 8), new SolidBrush(Color.Black), startX + 400, startY + Offset);
                Offset += 15;

                //MessageBox.Show(this.dataGridView1.Rows[i].Cells[3].Value.ToString());

                //graphics.DrawString("Medicine", new Font("Courier New", 14), new SolidBrush(Color.Black), startX + tempx2, startY + tempx);
                //tempx2 += 340;
                //graphics.DrawString(this.dataGridView1.Rows[i].Cells[0].Value.ToString(), new Font("Courier New", 14), new SolidBrush(Color.Black), startX + tempx2, startY+tempx);
                //tempx2 += 340;
                //graphics.DrawString(this.dataGridView1.Rows[i].Cells[1].Value.ToString(), new Font("Courier New", 14), new SolidBrush(Color.Black), startX + tempx2, startY+tempx);
                ////Offset = Offset + 20;
                //graphics.DrawString(line, new Font("Courier New", 14), new SolidBrush(Color.Black), startX, startY + tempx+20);
                //tempx += 40;
                //tempx2 = 0;

            }
            //graphics.DrawString(line, new Font("Courier New", 8), new SolidBrush(Color.Black), startX, startY + Offset);
            //Offset += 15;
            //graphics.DrawString("Total", new Font("Courier New", 8), new SolidBrush(Color.Black), startX + 50, startY + Offset);
            //graphics.DrawString(total_ml.ToString(), new Font("Courier New", 8), new SolidBrush(Color.Black), startX + 230, startY + Offset);
            //graphics.DrawString(total_price.ToString("00.00"), new Font("Courier New", 8), new SolidBrush(Color.Black), startX + 320, startY + Offset);
            //total = 0;
            //dt1.Clear();
            //this.gridbill.DataSource = bs1;
            //bill_no = 0;



        }
    }
}
