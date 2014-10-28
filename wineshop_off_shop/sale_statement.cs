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

namespace wineshop_off_shop
{
    public partial class sale_statement : Form
    {
        public sale_statement()
        {
            InitializeComponent();
        }
        //DataTable dt = new DataTable();
        //BindingSource bs = new BindingSource();
        //DataTable dt1 = new DataTable();
        //BindingSource bs1 = new BindingSource();
        //DataTable dt2 = new DataTable();
        //BindingSource bs2 = new BindingSource();
        //DataTable dt3 = new DataTable();
        //BindingSource bs3 = new BindingSource();
        //DataTable dt4 = new DataTable();
        //BindingSource bs4 = new BindingSource();
        //DataTable dt5 = new DataTable();
        //BindingSource bs5 = new BindingSource();
        //DataTable dt6 = new DataTable();
        //BindingSource bs6 = new BindingSource();
        //DataTable dt7 = new DataTable();
        //BindingSource bs7 = new BindingSource();
        DataTable dt8 = new DataTable();
        BindingSource bs8 = new BindingSource();
        string []pro_type=new string[20];
        PrintDocument pd;
        private void sale_statement_Load(object sender, EventArgs e)
        {
            //dt.Columns.Add("ML");
            //dt1.Columns.Add("ML");
            //dt2.Columns.Add("ML");
            //dt3.Columns.Add("ML");
            //dt4.Columns.Add("ML");
            //dt5.Columns.Add("ML");
            //dt6.Columns.Add("ML");
            //dt7.Columns.Add("ML");
            //bs.DataSource = dt;
            //grid2000ml.DataSource = bs;
            //bs1.DataSource = dt1;
            //grid1000ml.DataSource = bs1;
            //bs2.DataSource = dt2;
            //grid750ml.DataSource = bs2;
            //bs3.DataSource = dt3;
            //grid650ml.DataSource = bs3;
            //bs4.DataSource = dt4;
            //grid500ml.DataSource = bs4;
            //bs5.DataSource = dt5;
            //grid375ml.DataSource = bs5;
            //bs6.DataSource = dt6;
            //grid275ml.DataSource = bs6;
            //bs7.DataSource = dt7;
            //grid180ml.DataSource = bs7;
            dt8.Columns.Add("Product type");
            dt8.Columns.Add("Opeing Stock");
            dt8.Columns.Add("Purchase Stock");
            dt8.Columns.Add("Total Stock");
            dt8.Columns.Add("Sale");
            dt8.Columns.Add("Closing Stock");
            bs8.DataSource = dt8;
            this.dataGridView1.DataSource = bs8;
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            Class1.Cn.Open();
            int j = 0;
            int opening_stock = 0;
            int closing_stock = 0;
            int purchase = 0;
            int sale = 0;
            int total_stock = 0;
            DateTime date = Convert.ToDateTime(this.dateTimePicker1.Value);
            OleDbCommand cmd = new OleDbCommand("select * from product_type", Class1.Cn);
            OleDbDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                pro_type[j] = rd.GetString(1);
                j++;
            }
            rd.Close();
            Class1.Cn.Close();
            for (int i = 0; i < j; i++)
            {
                opening_stock = fatch_ml_opening(pro_type[i],date);
                closing_stock = fatch_ml_closing(pro_type[i], date);
                sale = fatch_ml_sale(pro_type[i], date);
                purchase = fatch_ml_purchase(pro_type[i], date);
                total_stock = opening_stock + purchase;
                dt8.Rows.Add(pro_type[i],opening_stock, purchase, total_stock, sale, closing_stock);

            }
            button2.Enabled = true;
            //show_opening_stock();
            //show_closing_stock();
           
        }
        //private int show_opening_stock()
        //{
        //    DateTime date = Convert.ToDateTime(this.dateTimePicker1.Value);
        //    Class1.Cn.Open();
        //    OleDbCommand cmd = new OleDbCommand("select * from opening_stock where product_type='" + this.txtpro_type.Text + "'", Class1.Cn);
        //    OleDbDataReader rd = cmd.ExecuteReader();
        //    while (rd.Read())
        //    {
        //        if (rd.GetInt32(5) == 2000)
        //        {
        //            int total_ml = fatch_ml_opening(2000, this.txtpro_type.Text,date);
        //           // return total_ml;
        //            //dt.Rows.Add(total_ml);
        //        }
        //        else if (rd.GetInt32(5) == 1000)
        //        {
        //            int total_ml = fatch_ml_opening(1000, this.txtpro_type.Text,date);
        //            //return total_ml;
        //            //dt1.Rows.Add(total_ml);
        //        }
        //        else if (rd.GetInt32(5) == 750)
        //        {
        //            int total_ml = fatch_ml_opening(750, this.txtpro_type.Text,date);
        //            //return total_ml;
        //            //dt2.Rows.Add(total_ml);
        //        }
        //        else if (rd.GetInt32(5) == 650)
        //        {
        //            int total_ml = fatch_ml_opening(650, this.txtpro_type.Text,date);
        //            //return total_ml;
        //            //dt3.Rows.Add(total_ml);
        //        }
        //        else if (rd.GetInt32(5) == 500)
        //        {
        //            int total_ml = fatch_ml_opening(500, this.txtpro_type.Text,date);
        //            //dt4.Rows.Add(total_ml);
        //        }
        //        else if (rd.GetInt32(5) == 375)
        //        {
        //            int total_ml = fatch_ml_opening(375, this.txtpro_type.Text,date);
        //            //dt5.Rows.Add(total_ml);
        //        }
        //        else if (rd.GetInt32(5) == 275)
        //        {
        //            int total_ml = fatch_ml_opening(275, this.txtpro_type.Text,date);
        //            //dt6.Rows.Add(total_ml);
        //        }
        //        else if (rd.GetInt32(5) == 180)
        //        {
        //            int total_ml = fatch_ml_opening(180, this.txtpro_type.Text,date);
        //            //dt7.Rows.Add(total_ml);
        //        }

        //    }
        //    rd.Close();
        //    Class1.Cn.Close();
        //    return total_ml;
        //}
        private int fatch_ml_opening(string type,DateTime date)
        {
            Class1.Cn.Open();
            int total_ml=0;
            OleDbCommand cmd = new OleDbCommand("select * from opening_stock where product_type='"+type+"'", Class1.Cn);
            OleDbDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                if (rd.GetDateTime(2).Month == date.Month && rd.GetDateTime(2).Year == date.Year)
                {
                    total_ml += rd.GetInt32(1);
                }
            }
            rd.Close();
            Class1.Cn.Close();
            return total_ml;
        }
        //private int show_closing_stock()
        //{
        //    DateTime date = Convert.ToDateTime(this.dateTimePicker1.Value);
        //    Class1.Cn.Open();
        //    OleDbCommand cmd = new OleDbCommand("select * from  closing_stock where product_type='" + this.txtpro_type.Text + "'", Class1.Cn);
        //    OleDbDataReader rd = cmd.ExecuteReader();
        //    while (rd.Read())
        //    {
        //        if (rd.GetInt32(5) == 2000)
        //        {
        //            int total_ml = fatch_ml_closing(2000, this.txtpro_type.Text,date);
        //            //dt.Rows.Add(total_ml);
        //        }
        //        else if (rd.GetInt32(5) == 1000)
        //        {
        //            int total_ml = fatch_ml_closing(1000, this.txtpro_type.Text,date);
        //            //dt1.Rows.Add(total_ml);
        //        }
        //        else if (rd.GetInt32(5) == 750)
        //        {
        //            int total_ml = fatch_ml_closing(750, this.txtpro_type.Text,date);
        //            //dt2.Rows.Add(total_ml);
        //        }
        //        else if (rd.GetInt32(5) == 650)
        //        {
        //            int total_ml = fatch_ml_closing(650, this.txtpro_type.Text,date);
        //            //dt3.Rows.Add(total_ml);
        //        }
        //        else if (rd.GetInt32(5) == 500)
        //        {
        //            int total_ml = fatch_ml_closing(500, this.txtpro_type.Text,date);
        //            //dt4.Rows.Add(total_ml);
        //        }
        //        else if (rd.GetInt32(5) == 375)
        //        {
        //            int total_ml = fatch_ml_closing(375, this.txtpro_type.Text,date);
        //            //dt5.Rows.Add(total_ml);
        //        }
        //        else if (rd.GetInt32(5) == 275)
        //        {
        //            int total_ml = fatch_ml_closing(275, this.txtpro_type.Text,date);
        //            //dt6.Rows.Add(total_ml);
        //        }
        //        else if (rd.GetInt32(5) == 180)
        //        {
        //            int total_ml = fatch_ml_closing(180, this.txtpro_type.Text,date);
        //            //dt7.Rows.Add(total_ml);
        //        }

        //    }
        //    rd.Close();
        //    Class1.Cn.Close();
        //}
        private int fatch_ml_closing(string type,DateTime date)
        {
            Class1.Cn.Open();
            int total_ml = 0;
            OleDbCommand cmd = new OleDbCommand("select * from closing_stock where product_type='" + type + "'", Class1.Cn);
            OleDbDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                if (rd.GetDateTime(2).Month == date.Month && rd.GetDateTime(2).Year == date.Year)
                {
                    total_ml += rd.GetInt32(1);
                }
            }
            rd.Close();
            Class1.Cn.Close();
            return total_ml;
        }
        private int fatch_ml_sale(string type, DateTime date)
        {
            Class1.Cn.Open();
            int total_ml = 0;
            OleDbCommand cmd = new OleDbCommand("select * from bill_product where product_type='" + type + "'", Class1.Cn);
            OleDbDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                OleDbCommand cmd1 = new OleDbCommand("select * from billing where id="+rd.GetInt32(1)+"", Class1.Cn);
                OleDbDataReader rd1 = cmd1.ExecuteReader();
                rd1.Read();
                if (rd1.GetDateTime(1).Month == date.Month && rd1.GetDateTime(1).Year == date.Year)
                {
                    total_ml += rd.GetInt32(7)*rd.GetInt32(4);
                }
                rd1.Close();
            }
            rd.Close();
            Class1.Cn.Close();
            return total_ml;
        }
        private int fatch_ml_purchase(string type, DateTime date)
        {
            Class1.Cn.Open();
            int total_ml = 0;
            OleDbCommand cmd = new OleDbCommand("select * from main_stock where product_type='" + type + "'", Class1.Cn);
            OleDbDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                
                if (rd.GetDateTime(10).Month == date.Month && rd.GetDateTime(10).Year == date.Year)
                {
                    total_ml += rd.GetInt32(7);
                }
                
            }
            rd.Close();
            Class1.Cn.Close();
            return total_ml;
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
            graphics.DrawString("SALE STATEMENT", new Font("Courier New", 10), new SolidBrush(Color.Black), startX + 250, startY + Offset);
            Offset += 15;
            graphics.DrawString(line, new Font("Courier New", 8), new SolidBrush(Color.Black), startX, startY + Offset);
            Offset += 15;
            graphics.DrawString("TYPE", new Font("Courier New", 8), new SolidBrush(Color.Black), startX + 10, startY + Offset);
            graphics.DrawString("OPENING", new Font("Courier New", 8), new SolidBrush(Color.Black), startX + 80, startY + Offset);
            graphics.DrawString("PURCHASE", new Font("Courier New", 8), new SolidBrush(Color.Black), startX + 150, startY + Offset);
            graphics.DrawString("TOTAL", new Font("Courier New", 8), new SolidBrush(Color.Black), startX + 230, startY + Offset);
            graphics.DrawString("SALE", new Font("Courier New", 8), new SolidBrush(Color.Black), startX + 290, startY + Offset);
            graphics.DrawString("CLOSING", new Font("Courier New", 8), new SolidBrush(Color.Black), startX + 360, startY + Offset);
            Offset += 15;
            graphics.DrawString(line, new Font("Courier New", 8), new SolidBrush(Color.Black), startX, startY + Offset);
            Offset += 15;
           // total = 0;
            for (int i = 0; i < this.dataGridView1.Rows.Count - 1; i++)
            {


                //total += Convert.ToDouble(this.dataGridView1.Rows[i].Cells[2].Value);
                graphics.DrawString(this.dataGridView1.Rows[i].Cells[0].Value.ToString().ToUpper(), new Font("Courier New", 8), new SolidBrush(Color.Black), startX + 10, startY + Offset);
                graphics.DrawString(this.dataGridView1.Rows[i].Cells[1].Value.ToString(), new Font("Courier New", 8), new SolidBrush(Color.Black), startX + 80, startY + Offset);
                graphics.DrawString(this.dataGridView1.Rows[i].Cells[2].Value.ToString(), new Font("Courier New", 8), new SolidBrush(Color.Black), startX + 150, startY + Offset);
                graphics.DrawString(this.dataGridView1.Rows[i].Cells[3].Value.ToString(), new Font("Courier New", 8), new SolidBrush(Color.Black), startX + 230, startY + Offset);
                graphics.DrawString(this.dataGridView1.Rows[i].Cells[4].Value.ToString(), new Font("Courier New", 8), new SolidBrush(Color.Black), startX + 290, startY + Offset);
                graphics.DrawString(this.dataGridView1.Rows[i].Cells[5].Value.ToString(), new Font("Courier New", 8), new SolidBrush(Color.Black), startX + 360, startY + Offset);
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
        //private void show_sale_stcok()
        //{
        //    DateTime date = Convert.ToDateTime(this.dateTimePicker1.Value);
        //    Class1.Cn.Open();
        //    OleDbCommand cmd = new OleDbCommand("select * from closing_stock product_type='" + this.txtpro_type.Text + "'", Class1.Cn);
        //    OleDbDataReader rd = cmd.ExecuteReader();
        //    while (rd.Read())
        //    {
        //        if (rd.GetInt32(3) == 2000)
        //        {
        //            int total_ml = fatch_ml_closing(2000, this.txtpro_type.Text, date);
        //            dt.Rows.Add(total_ml);
        //        }
        //        else if (rd.GetInt32(3) == 1000)
        //        {
        //            int total_ml = fatch_ml_closing(1000, this.txtpro_type.Text, date);
        //            dt1.Rows.Add(total_ml);
        //        }
        //        else if (rd.GetInt32(3) == 750)
        //        {
        //            int total_ml = fatch_ml_closing(750, this.txtpro_type.Text, date);
        //            dt2.Rows.Add(total_ml);
        //        }
        //        else if (rd.GetInt32(3) == 650)
        //        {
        //            int total_ml = fatch_ml_closing(650, this.txtpro_type.Text, date);
        //            dt3.Rows.Add(total_ml);
        //        }
        //        else if (rd.GetInt32(3) == 500)
        //        {
        //            int total_ml = fatch_ml_closing(500, this.txtpro_type.Text, date);
        //            dt4.Rows.Add(total_ml);
        //        }
        //        else if (rd.GetInt32(3) == 375)
        //        {
        //            int total_ml = fatch_ml_closing(375, this.txtpro_type.Text, date);
        //            dt5.Rows.Add(total_ml);
        //        }
        //        else if (rd.GetInt32(3) == 275)
        //        {
        //            int total_ml = fatch_ml_closing(275, this.txtpro_type.Text, date);
        //            dt6.Rows.Add(total_ml);
        //        }
        //        else if (rd.GetInt32(3) == 180)
        //        {
        //            int total_ml = fatch_ml_closing(180, this.txtpro_type.Text, date);
        //            dt7.Rows.Add(total_ml);
        //        }

        //    }
        //    rd.Close();
        //    Class1.Cn.Close();
        //}


    }
}
