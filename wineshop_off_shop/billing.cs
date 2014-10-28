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
    public partial class billing : Form
    {
        public billing()
        {
            InitializeComponent();
        }
        DataTable dt = new DataTable();
        BindingSource bs = new BindingSource();
        string method,vat_stat;
        int address;
        int stock_id;
        int row_index = -1;
        int ml;
        decimal total_amount = 0;
        int bill_no = 0;
        double total = 0;
        PrintDocument pd;
        decimal vat_persentage = 0;
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //OleDbConnection cn = new OleDbConnection("Provider = Microsoft.Jet.OLEDB.4.0; Data Source =" + Class1.path + "; Jet OLEDB:Database password = medicine");
            
            try
            {
                if (this.txtbarcode.Text != "")
                {
                    //dt.Clear();
                    //int id = 27;
                    //int flag = 0;
                    //this.gridbill.DataSource = bs;
                    int id = select_stock_id(this.txtbarcode.Text);
                    int flag = check_gridbill(id);
                    if (flag < 1)
                    {
                        Class1.Cn.Open();
                        //cn.Open();
                        OleDbCommand cmd = new OleDbCommand("select * from stock where id=" + id + "", Class1.Cn);
                        OleDbDataReader rd = cmd.ExecuteReader();
                        while (rd.Read())
                        {
                            dt.Rows.Add(rd.GetInt32(0), rd.GetString(1), rd.GetString(14), rd.GetString(2), rd.GetString(15), "1", rd.GetValue(9), rd.GetInt32(3));
                        }
                        rd.Close();
                        Class1.Cn.Close();
                       // cn.Close();
                        calculate_total_amount();
                    }
                    else
                    {
                        int quan = Convert.ToInt32(this.gridbill.Rows[address].Cells[5].Value) + 1;
                        this.gridbill.Rows[address].Cells[5].Value = quan;
                        calculate_total_amount();
                    }
                    this.txtbarcode.Text = "";
                    this.txtbarcode.Focus();
                }
            }
            catch
            {
                Class1.Cn.Close();
                //cn.Close();
            }
           
        }
        private int check_gridbill(int stock_id)
        {
            Class1.Cn.Open();
            int flag = 0;
            OleDbCommand cmd = new OleDbCommand("select * from stock where id="+stock_id+"",Class1.Cn);
            OleDbDataReader rd = cmd.ExecuteReader();
            rd.Read();
            string name=rd.GetString(14);
            int ml_perbottle=rd.GetInt32(3);
            decimal price=Convert.ToDecimal(rd.GetValue(9));
            for(int i=0;i <this.gridbill.Rows.Count-1;i++)
            {
                if (this.gridbill.Rows[i].Cells[2].Value.ToString() == name && Convert.ToInt32(this.gridbill.Rows[i].Cells[7].Value) == ml_perbottle)
                {
                    if (Convert.ToDecimal(this.gridbill.Rows[i].Cells[6].Value) == price)
                    {
                        address = i;
                        flag++;
                    }
                }
            }
            rd.Close();
            Class1.Cn.Close();
            return flag;
        }
        private void calculate_total_amount()
        {
            for (int i = 0; i < this.gridbill.Rows.Count - 1; i++)
            {
                total_amount +=Convert.ToDecimal(this.gridbill.Rows[i].Cells[6].Value)*Convert.ToDecimal(this.gridbill.Rows[i].Cells[5].Value);
                
            }
            this.txttotalamount.Text = total_amount.ToString("00.00");
            total_amount = 0;
        }
        private string fetch_method()
        {
            Class1.Cn.Open();
            OleDbCommand cmd = new OleDbCommand("select * from setting where type='method'", Class1.Cn);
            OleDbDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                method = rd.GetString(2);
            }
            rd.Close();
            Class1.Cn.Close();
            return method;

        }
        private int select_stock_id(string barcode)
        {
            int ml_per_bottle = get_ml_per_bottle(barcode);
            string me = fetch_method();
            Class1.Cn.Open();
            if (me == "LIFO")
            {
                OleDbCommand cmd = new OleDbCommand("select * from stock  where barcode='"+barcode+"' and total_ml > "+ml_per_bottle+" order by id DESC", Class1.Cn);
                OleDbDataReader rd = cmd.ExecuteReader();
                rd.Read();
                stock_id = rd.GetInt32(0);
                rd.Close();


            }
            else
            {
                OleDbCommand cmd = new OleDbCommand("select * from stock where barcode='" + barcode + "' and total_ml > "+ml_per_bottle+" order by id ASC", Class1.Cn);
                OleDbDataReader rd = cmd.ExecuteReader();
                rd.Read();
                stock_id = rd.GetInt32(0);
                rd.Close();
            }
            Class1.Cn.Close();
            return stock_id;
        }
        private int get_ml_per_bottle(string barcode)
        {
            Class1.Cn.Open();
            OleDbCommand cmd = new OleDbCommand("select * from barcode where barcode='"+barcode+"'",Class1.Cn);
            OleDbDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                ml = rd.GetInt32(3);
            }
            rd.Close();
            Class1.Cn.Close();
            return ml;
        }
        private void billing_Load(object sender, EventArgs e)
        {
            dt.Columns.Add("Id");
            dt.Columns.Add("Barcode");
            dt.Columns.Add("Product Name");
            dt.Columns.Add("Prodduct Type");
            dt.Columns.Add("Brand Name");
            dt.Columns.Add("Quantity");
            dt.Columns.Add("Price");
            dt.Columns.Add("Ml Per Bottle");
            bs.DataSource = dt;
            this.gridbill.DataSource = bs;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (row_index < 0)
                {
                    MessageBox.Show("Please Select Row");
                }
                else
                {
                    if (Convert.ToInt32(this.gridbill.Rows[row_index].Cells[5].Value) > 1)
                    {
                        int quan = Convert.ToInt32(this.gridbill.Rows[row_index].Cells[5].Value) - 1;
                        this.gridbill.Rows[row_index].Cells[5].Value = quan;
                        row_index = -1;
                        calculate_total_amount();
                    }
                    else
                    {
                        this.gridbill.Rows.RemoveAt(row_index);
                        row_index = -1;
                        calculate_total_amount();
                    }
                }
            }
            catch
            {
            }
        }

        private void gridbill_MouseClick(object sender, MouseEventArgs e)
        {
            row_index = Convert.ToInt32(this.gridbill.SelectedCells[0].RowIndex);
        }
        private void stock_maintain()
        {
            Class1.Cn.Open();
            OleDbCommand cmd;
            for (int i = 0; i < this.gridbill.Rows.Count - 1; i++)
            {

               
                    int id = Convert.ToInt32(this.gridbill.Rows[i].Cells[0].Value);
                    int pro_quan = Convert.ToInt32(this.gridbill.Rows[i].Cells[5].Value);
                    int ml_per_bottle=Convert.ToInt32(this.gridbill.Rows[i].Cells[7].Value);
                    int total_ml = ml_per_bottle * pro_quan;
                    cmd = new OleDbCommand("select * from stock where id="+id+"", Class1.Cn);
                    OleDbDataReader rd = cmd.ExecuteReader();
                    rd.Read();
                    int total_ml_from_stock = rd.GetInt32(7);
                    int ml_per_bottle_from_stock = rd.GetInt32(3);
                    int bottle_per_box = showbottle(ml_per_bottle_from_stock);
                    int total_bottle;
                    int lose_bottle;
                    int no_of_case;
                    int remail_ml = total_ml_from_stock - total_ml;
                    total_bottle = remail_ml / ml_per_bottle_from_stock;
                    no_of_case = total_bottle / bottle_per_box;
                    lose_bottle = total_bottle % bottle_per_box;
                    //string pro_name = this.gridbill.Rows[i].Cells[0].Value.ToString();
                    //decimal pro_price = Convert.ToDecimal(this.gridbill.Rows[i].Cells[1].Value);

                    cmd = new OleDbCommand("update stock set no_of_case=" + no_of_case + ",no_of_lose_bottle=" + lose_bottle + "" +
                        ",total_bottle=" + total_bottle + ",total_ml=" + remail_ml + " where id=" + id + "", Class1.Cn);
                    cmd.ExecuteNonQuery();
                    //Class1.Cn.Close();
                

            }
            Class1.Cn.Close();
        }

        private int showbottle(int ml_per_bottle)
        {
            //Class1.Cn.Open();
            string ml = "ml" + ml_per_bottle.ToString();
            OleDbCommand cmd = new OleDbCommand("select * from setting where type='" + ml + "'", Class1.Cn);
            OleDbDataReader rd = cmd.ExecuteReader();
            rd.Read();
            int bottle_per_box = Convert.ToInt32(rd.GetString(2));
            return bottle_per_box;
        }
        private void insert_into_tables()
        {
            Class1.Cn.Open();
            OleDbCommand cmd = new OleDbCommand("insert into billing(pro_date,status" +
                       ") values('" +DateTime.Now + "','no')", Class1.Cn);
            cmd.ExecuteNonQuery();
            cmd = new OleDbCommand("select * from billing where status='no'", Class1.Cn);
            OleDbDataReader rd;
            rd = cmd.ExecuteReader();
            rd.Read();
            bill_no = rd.GetInt32(0);
            rd.Close();
            for(int i=0;i<this.gridbill.Rows.Count-1;i++)
            {
                string pro_name = this.gridbill.Rows[i].Cells[2].Value.ToString();
                int pro_ml = Convert.ToInt32(this.gridbill.Rows[i].Cells[7].Value);
                int quan = Convert.ToInt32(this.gridbill.Rows[i].Cells[5].Value);
                //int total_ml = pro_ml * quan;
                string bar = this.gridbill.Rows[i].Cells[1].Value.ToString();
                string product_type = this.gridbill.Rows[i].Cells[3].Value.ToString();
                decimal pro_price = Convert.ToDecimal(this.gridbill.Rows[i].Cells[6].Value)*quan;
                //int pro_quan = find_product_size(this.gridbill.Rows[i].Cells[2].Value.ToString());
                cmd = new OleDbCommand("insert into bill_product (bill_no,product_name,product_price,product_quan,product_type,barcode,ml_per_bottle)"+
                    " values (" + bill_no + ",'" + pro_name + "'," + pro_price + "," + quan + ",'" + product_type + "','"+bar+"',"+pro_ml+")", Class1.Cn);
                cmd.ExecuteNonQuery();
                cmd = new OleDbCommand("insert into user_biling (user_name,price,bill_date) values ('" + Class1.user + "'," + pro_price + ",'" + DateTime.Now + "')", Class1.Cn);
                cmd.ExecuteNonQuery();
                cmd = new OleDbCommand("insert into incexp(head_name,dr,cr,exp_date) values ('sales'," + pro_price + ",0,'" + DateTime.Now + "')", Class1.Cn);
                cmd.ExecuteNonQuery();
            }
            cmd = new OleDbCommand("update billing set status='yes' where id=" + bill_no + "", Class1.Cn);
            cmd.ExecuteNonQuery();
            Class1.Cn.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.checkBox1.Checked == true)
            {
                stock_maintain();
                insert_into_tables();
                PaperSize pz = new PaperSize();
                //pz.Height = 200;
                pz.Width = 500;
                pd = new PrintDocument();
                pd.DefaultPageSettings.PaperSize = pz;
                pd.PrintPage += new PrintPageEventHandler(this.pd_print);
                pd.Print();
                insert_into_bill_print();
            }
            else
            {
                stock_maintain();
                insert_into_tables();
                //insert_into_bill_print();
                dt.Clear();
                this.gridbill.DataSource = bs;
            }
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
            graphics.DrawString("Bill NO:-"+bill_no.ToString(), new Font("Courier New", 8), new SolidBrush(Color.Black), startX, startY + Offset);
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
            for (int i = 0; i < this.gridbill.Rows.Count - 1; i++)
            {


                total += Convert.ToDouble(this.gridbill.Rows[i].Cells[6].Value) * Convert.ToDouble(this.gridbill.Rows[i].Cells[5].Value);
                graphics.DrawString(this.gridbill.Rows[i].Cells[2].Value.ToString().ToUpper(), new Font("Courier New", 8), new SolidBrush(Color.Black), startX + 10, startY + Offset);
                graphics.DrawString(this.gridbill.Rows[i].Cells[5].Value.ToString(), new Font("Courier New", 8), new SolidBrush(Color.Black), startX + 230, startY + Offset);
                graphics.DrawString(this.gridbill.Rows[i].Cells[7].Value.ToString(), new Font("Courier New", 8), new SolidBrush(Color.Black), startX + 330, startY + Offset);
                graphics.DrawString((Convert.ToDecimal(this.gridbill.Rows[i].Cells[6].Value) * Convert.ToDecimal(this.gridbill.Rows[i].Cells[5].Value)).ToString("00.00"), new Font("Courier New", 8), new SolidBrush(Color.Black), startX + 520, startY + Offset);
                Offset += 15;
            }
            string vt_st = vat_status();
            decimal vt_per = get_vat_persentage();
            if (vt_st == "yes")
            {
                decimal calculate_vat = (Convert.ToDecimal(total) * vt_per) / 100;
                decimal total_with_vat = Convert.ToDecimal(total) + calculate_vat;
                graphics.DrawString("Vat"+"("+vt_per.ToString("00.00")+")", new Font("Courier New", 8), new SolidBrush(Color.Black), startX + 10, startY + Offset);
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
            this.gridbill.DataSource = bs;
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

        private void txtgivmoney_TextChanged(object sender, EventArgs e)
        {
            this.txtbalance.Text = (Convert.ToDecimal(this.txtgivmoney.Text)-Convert.ToDecimal(this.txttotalamount.Text)).ToString("00.00");
        }

    }
}
