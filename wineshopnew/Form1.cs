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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public OleDbDataAdapter da = null;
        //public OleDbDataAdapter da1 = null;
        public OleDbCommandBuilder cb = null;
       // public OleDbCommandBuilder cb1 = null;
        public DataTable dt = null;
        //public DataTable dt1 = null;
        public BindingSource bs = null;
       // public BindingSource bs1 = null;
        public OleDbConnection Cn = null;
        public string query = null;
        public int row_index = 0;
        private void Form1_Load(object sender, EventArgs e)
        {
           /// OleDbConnection Cn = new OleDbConnection("Provider = Microsoft.Jet.OLEDB.4.0; Data Source =" + Class1.path + "; Jet OLEDB:Database password = medicine");
            
            ////query = "SELECT * FROM stock_info where name='" + this.txtmedicinename.Text + "'";
            //query = "SELECT * FROM tcs";
            //da = new OleDbDataAdapter(query, Cn);
            //cb = new OleDbCommandBuilder(da);
            
            dt = new DataTable();
            dt.Columns.Add("test");
            //da.Fill(dt);
            bs = new BindingSource();
            bs.DataSource = dt;
           
            this.dataGridView1.DataSource = bs;
            dt.Rows.Add("lmlmml");
            ////dt.Columns.Add("Expiri_date");
            ////for (int i = 0; i < this.dataGridView2.Rows.Count - 1; i++)
            ////{
            ////    OleDbCommand cmd = new OleDbCommand("select * from date_management where medi_id=" + Convert.ToInt32(this.dataGridView2.Rows[i].Cells[0].Value), Cn);
            ////    OleDbDataReader rd = cmd.ExecuteReader();
            ////    while (rd.Read())
            ////    {
            ////        this.dataGridView2.Rows[j].Cells[7].Value = rd.GetDateTime(1);
            ////        j++;
            ////    }
            ////}
            ////this.dataGridView2.Refresh();
            //Cn.Close();
            //timer1.Enabled = true;
            //timer2.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //this.dataGridView1.Rows.Clear();
            dt.Clear();
            this.dataGridView1.DataSource = bs;
            //int i = 0;
            //for (i = 0; i < this.dataGridView1.Rows.Count-1; i++)
            //{
            //    MessageBox.Show(this.dataGridView1.Rows[i].Cells[0].Value.ToString());
            //}
        }

        private void button2_Click(object sender, EventArgs e)
        {
            insert_stock i_s=new insert_stock();
            i_s.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            billing bl = new billing();
            bl.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            barcode bc = new barcode();
            bc.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            creditor cr = new creditor();
            cr.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            daily_report dr = new daily_report();
            dr.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            insert_newproducttype it = new insert_newproducttype();
            it.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            insert_rebate ir = new insert_rebate();
            ir.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            insert_return_tcs irt = new insert_return_tcs();
            irt.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            insert_table it = new insert_table();
            it.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            insert_tcs ic = new insert_tcs();
            ic.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            product_sale_report psr = new product_sale_report();
            psr.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            rebate_targer rt = new rebate_targer();
            rt.Show();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            sale_statement ss = new sale_statement();
            ss.Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            set_starting_date ssd = new set_starting_date();
            ssd.Show();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            seting st = new seting();
            st.Show();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            view_tcs_report vtr = new view_tcs_report();
            vtr.Show();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            creditors_ac ca = new creditors_ac();
            ca.Show();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            creditor_money_return cmr = new creditor_money_return();
            cmr.Show();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            insert_pack_detail inpd = new insert_pack_detail();
            inpd.Show();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            total_billing tb = new total_billing();
            tb.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Class1.insert_opeingstock();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Class1.insert_closeingstock();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            insert_opening_stock ios = new insert_opening_stock();
            ios.Show();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            insert_closing_stock ics = new insert_closing_stock();
            ics.Show();
        }

        private void button24_Click(object sender, EventArgs e)
        {
            show_profitandloss spl = new show_profitandloss();
            spl.Show();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            show_stock ss = new show_stock();
            ss.Show();
        }

        private void button26_Click(object sender, EventArgs e)
        {
            show_pack sp = new show_pack();
            sp.Show();
        }

        private void button27_Click(object sender, EventArgs e)
        {
            create_user cu = new create_user();
            cu.Show();
        }

        private void button28_Click(object sender, EventArgs e)
        {
            delete_user du = new delete_user();
            du.Show();
        }

        private void button29_Click(object sender, EventArgs e)
        {
            show_user_ac sua = new show_user_ac();
            sua.Show();
        }

        private void button30_Click(object sender, EventArgs e)
        {
            change_passowrd cp = new change_passowrd();
            cp.Show();
        }

        private void button31_Click(object sender, EventArgs e)
        {
            insert_expenses ie = new insert_expenses();
            ie.Show();
        }

        private void button32_Click(object sender, EventArgs e)
        {
            view_income_expenses vie = new view_income_expenses();
            vie.Show();
        }
    }
}
