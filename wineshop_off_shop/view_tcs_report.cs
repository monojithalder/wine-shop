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
    public partial class view_tcs_report : Form
    {
        public view_tcs_report()
        {
            InitializeComponent();
        }
        DataTable dt = new DataTable();
        BindingSource bs = new BindingSource();
        decimal dr=0,cr=0;
        string [] name=new string [9999999];
        int flag = 0;
        string temp = "";
        PrintDocument pd;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                dt.Clear();
                this.dataGridView1.DataSource = bs;
                int year = Convert.ToInt32(this.txtyear.Text);
                Class1.Cn.Open();
                OleDbCommand cmd = new OleDbCommand("select * from dealer_name", Class1.Cn);
                OleDbDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {


                    OleDbCommand cmd1 = new OleDbCommand("select * from tcs where dealer_name='" + rd.GetString(1) + "'", Class1.Cn);
                    OleDbDataReader crdatard = cmd1.ExecuteReader();
                    while (crdatard.Read())
                    {
                        if (crdatard.GetDateTime(4).Year == year)
                        {
                            cr += Convert.ToDecimal(crdatard.GetValue(2));
                        }
                    }
                    crdatard.Close();
                    cmd1 = new OleDbCommand("select * from tcs_return where dealer_name='" + rd.GetString(1) + "'", Class1.Cn);
                    OleDbDataReader drdatard = cmd1.ExecuteReader();
                    while (drdatard.Read())
                    {
                        if (drdatard.GetDateTime(3).Year == year)
                        {
                            dr += Convert.ToDecimal(drdatard.GetValue(2));
                        }
                    }

                    drdatard.Close();
                    insert_into_datatable(rd.GetString(1));
                }
                Class1.Cn.Close();
                button2.Enabled = true;
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }

        }

        private void view_tcs_report_Load(object sender, EventArgs e)
        {
            dt.Columns.Add("Dealer Name");
            dt.Columns.Add("DR");
            dt.Columns.Add("CR");
            bs.DataSource = dt;
            this.dataGridView1.DataSource = bs;
            
        }
        private void insert_into_datatable(string name1)
        {
            dt.Rows.Add(name1, dr, cr);
            dr = 0;
            cr = 0;
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
            graphics.DrawString("TCS REPORT", new Font("Courier New", 10), new SolidBrush(Color.Black), startX + 250, startY + Offset);
            Offset += 15;
            graphics.DrawString(line, new Font("Courier New", 8), new SolidBrush(Color.Black), startX, startY + Offset);
            Offset += 15;
            graphics.DrawString("DELEAR NAME", new Font("Courier New", 8), new SolidBrush(Color.Black), startX + 10, startY + Offset);
            graphics.DrawString("DR", new Font("Courier New", 8), new SolidBrush(Color.Black), startX + 310, startY + Offset);
            graphics.DrawString("CR", new Font("Courier New", 8), new SolidBrush(Color.Black), startX + 350, startY + Offset);
            Offset += 15;
            graphics.DrawString(line, new Font("Courier New", 8), new SolidBrush(Color.Black), startX, startY + Offset);
            Offset += 15;
            // total = 0;
            for (int i = 0; i < this.dataGridView1.Rows.Count - 1; i++)
            {


                //total += Convert.ToDouble(this.dataGridView1.Rows[i].Cells[2].Value);
                graphics.DrawString(this.dataGridView1.Rows[i].Cells[0].Value.ToString().ToUpper(), new Font("Courier New", 8), new SolidBrush(Color.Black), startX + 10, startY + Offset);
                graphics.DrawString(this.dataGridView1.Rows[i].Cells[1].Value.ToString(), new Font("Courier New", 8), new SolidBrush(Color.Black), startX + 310, startY + Offset);
                graphics.DrawString(this.dataGridView1.Rows[i].Cells[2].Value.ToString(), new Font("Courier New", 8), new SolidBrush(Color.Black), startX + 350, startY + Offset);
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
