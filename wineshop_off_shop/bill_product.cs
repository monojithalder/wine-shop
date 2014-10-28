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
    public partial class bill_product : Form
    {
        public bill_product()
        {
            InitializeComponent();
        }
        DataTable dt = new DataTable();
        BindingSource bs = new BindingSource();
        DataTable dt1 = new DataTable();
        BindingSource bs1 = new BindingSource();
        public int bill_no;
        int total_amount_first;
        decimal vat_persentage;
        double total;
        string vat_stat;
        PrintDocument pd;
        private void bill_product_Load(object sender, EventArgs e)
        {
            dt.Columns.Add("Bill_No");
           // dt.Columns.Add("Table_No");
            dt.Columns.Add("Pro_Name");
            dt.Columns.Add("Pro_price");
            dt.Columns.Add("Quantity");
            dt.Columns.Add("Pro_Type");
            dt.Columns.Add("ML Per Bottle");
            dt.Columns.Add("No_Of_Bill_Print");
            dt.Columns.Add("Total_Bill_Amount");
            bs.DataSource = dt;
            this.dataGridView1.DataSource = bs;
            //dt1.Columns.Add("Bill_No");
            //dt1.Columns.Add("Table_No");
            //dt1.Columns.Add("Pro_Name");
            //dt1.Columns.Add("Pro_price(per)");
            //dt1.Columns.Add("Pro_Type");
            //dt1.Columns.Add("Quantity");
            //dt1.Columns.Add("Total_Ml");
            //dt1.Columns.Add("No_Of_Bill_Print");
            //dt1.Columns.Add("Total_Bill_Amount");
            //bs1.DataSource = dt1;
            //this.dataGridView2.DataSource = bs1;
            show_first_grid();
            //show_sceound_grid();
        }
        public void show_first_grid()
        {
            total_amount_first = 0;
            int number_of_bill_print=bill_print(bill_no);
            Class1.Cn.Open();
            OleDbCommand cmd = new OleDbCommand("select * from bill_product where bill_no="+bill_no+"", Class1.Cn);
            OleDbDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                dt.Rows.Add(bill_no,rd.GetString(2),rd.GetValue(3),rd.GetInt32(4),rd.GetString(5),rd.GetInt32(7),number_of_bill_print,"");
            }
            rd.Read();
            Class1.Cn.Close();
            for (int i = 0; i < this.dataGridView1.Rows.Count - 1; i++)
            {
                total_amount_first += Convert.ToInt32(this.dataGridView1.Rows[i].Cells[2].Value);
            }
            dt.Rows.Add("","","","","","","",total_amount_first);

        }

        private int bill_print(int bil_no)
        {
            Class1.Cn.Open();
            int flag = 0;
            OleDbCommand cmd = new OleDbCommand("select * from bill_print where bill_no="+bil_no+"", Class1.Cn);
            OleDbDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                flag++;
            }
            rd.Close();
            Class1.Cn.Close();
            if (flag < 1)
            {
                return 0;
            }
            else
            {
                return flag;   
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PaperSize pz = new PaperSize();
            //pz.Height = 200;
            pz.Width = 500;
            pd = new PrintDocument();
            pd.DefaultPageSettings.PaperSize = pz;
            pd.PrintPage += new PrintPageEventHandler(this.pd_print);
            pd.Print();
            insert_into_bill_print();
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
            graphics.DrawString(address, new Font("Courier New", 5), new SolidBrush(Color.Black), startX + 94, startY + 10);
            graphics.DrawString(line, new Font("Courier New", 8), new SolidBrush(Color.Black), startX, startY + Offset);
            Offset += 15;
            graphics.DrawString(line, new Font("Courier New", 8), new SolidBrush(Color.Black), startX, startY + Offset);
            Offset += 15;
            graphics.DrawString("NAME", new Font("Courier New", 8), new SolidBrush(Color.Black), startX + 10, startY + Offset);
            graphics.DrawString("QUANTITY", new Font("Courier New", 8), new SolidBrush(Color.Black), startX + 230, startY + Offset);
            graphics.DrawString("ML PER BOTTLE", new Font("Courier New", 8), new SolidBrush(Color.Black), startX + 330, startY + Offset);
            graphics.DrawString("PRICE", new Font("Courier New", 8), new SolidBrush(Color.Black), startX + 520, startY + Offset);
            Offset += 15;
            graphics.DrawString(line, new Font("Courier New", 8), new SolidBrush(Color.Black), startX, startY + Offset);
            Offset += 15;
            total = 0;
            for (int i = 0; i < this.dataGridView1.Rows.Count - 2; i++)
            {


                total += Convert.ToDouble(this.dataGridView1.Rows[i].Cells[2].Value);
                graphics.DrawString(this.dataGridView1.Rows[i].Cells[1].Value.ToString().ToUpper(), new Font("Courier New", 8), new SolidBrush(Color.Black), startX + 10, startY + Offset);
                graphics.DrawString(this.dataGridView1.Rows[i].Cells[3].Value.ToString(), new Font("Courier New", 8), new SolidBrush(Color.Black), startX + 230, startY + Offset);
                graphics.DrawString(this.dataGridView1.Rows[i].Cells[5].Value.ToString(), new Font("Courier New", 8), new SolidBrush(Color.Black), startX + 330, startY + Offset);
                graphics.DrawString(Convert.ToDecimal(this.dataGridView1.Rows[i].Cells[2].Value).ToString("00.00"), new Font("Courier New", 8), new SolidBrush(Color.Black), startX + 520, startY + Offset);
                Offset += 15;
            }
            string vt_st = vat_status();
            decimal vt_per = get_vat_persentage();
            if (vt_st == "yes")
            {
                decimal calculate_vat = (Convert.ToDecimal(total) * vt_per) / 100;
                decimal total_with_vat = Convert.ToDecimal(total) + calculate_vat;
                graphics.DrawString("Vat" + "(" + vt_per.ToString("00.00") + ")", new Font("Courier New", 8), new SolidBrush(Color.Black), startX + 10, startY + Offset);
                graphics.DrawString(calculate_vat.ToString("00.00"), new Font("Courier New", 8), new SolidBrush(Color.Black), startX + 520, startY + Offset);
                Offset += 15;
                graphics.DrawString(line, new Font("Courier New", 8), new SolidBrush(Color.Black), startX, startY + Offset);
                Offset += 15;
                graphics.DrawString("Total_Anount", new Font("Courier New", 8), new SolidBrush(Color.Black), startX + 50, startY + Offset);
                graphics.DrawString(total_with_vat.ToString("00.00"), new Font("Courier New", 8), new SolidBrush(Color.Black), startX + 520, startY + Offset);
                total = 0;
                total_with_vat = 0;
            }
            else
            {
                graphics.DrawString(line, new Font("Courier New", 8), new SolidBrush(Color.Black), startX, startY + Offset);
                Offset += 15;
                graphics.DrawString("Total_Anount", new Font("Courier New", 8), new SolidBrush(Color.Black), startX + 50, startY + Offset);
                graphics.DrawString(total.ToString("00.00"), new Font("Courier New", 8), new SolidBrush(Color.Black), startX + 420, startY + Offset);
                total = 0;
            }
            dt.Clear();
            this.dataGridView1.DataSource = bs;
            //bill_no = 0;


        }
        private decimal get_vat_persentage()
        {
            Class1.Cn.Open();
            OleDbCommand cmd = new OleDbCommand("select * from setting where type='vat_persentage'", Class1.Cn);
            OleDbDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                vat_persentage = Convert.ToDecimal(rd.GetString(2));
            }
            rd.Close();
            Class1.Cn.Close();
            return vat_persentage;
        }
        private string vat_status()
        {
            Class1.Cn.Open();
            OleDbCommand cmd = new OleDbCommand("select * from setting where type='vat_status'", Class1.Cn);
            OleDbDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                vat_stat = rd.GetString(2);
            }
            rd.Close();
            Class1.Cn.Close();
            return vat_stat;
        }
        private void insert_into_bill_print()
        {

            Class1.Cn.Open();
            OleDbCommand cmd = new OleDbCommand("insert into bill_print (bill_no) values (" + bill_no + ")", Class1.Cn);
            cmd.ExecuteNonQuery();
            Class1.Cn.Close();
        }
       
    }
}
