using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb;

namespace wineshopnew
{
    public partial class admin_panel : Form
    {
        public admin_panel()
        {
            InitializeComponent();
        }
        string query;
        OleDbDataAdapter da;
        OleDbCommandBuilder cb;
        DataTable dt;
        BindingSource bs;
        int low = 0, medium = 0, high = 0;
        public billing bl = null;
        private void timer1_Tick(object sender, EventArgs e)
        {
            change();
            /// Class1.Cn.Open();
            OleDbConnection cn = new OleDbConnection("Provider = Microsoft.Jet.OLEDB.4.0; Data Source =" + Class1.path + "; Jet OLEDB:Database password = medicine");
            cn.Open();
            OleDbCommand cmd = new OleDbCommand("select * from setting", cn);
            OleDbDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                if (rd.GetString(1) == "stock_low")
                {
                    low = Convert.ToInt32(rd.GetString(2));
                }
                else if (rd.GetString(1) == "stock_medium")
                {
                    medium = Convert.ToInt32(rd.GetString(2));
                }
                else if (rd.GetString(1) == "stock_high")
                {
                    high = Convert.ToInt32(rd.GetString(2));
                }
            }
            rd.Close();
            //Class1.Cn.Close();
            cn.Close();
            foreach (DataGridViewRow r in this.dataGridView1.Rows)
            {
                int id = Convert.ToInt32(r.Cells[1].Value);
                if (id <= low)
                {
                    //MessageBox.Show(id.ToString());
                    r.DefaultCellStyle.BackColor = Color.Red;
                    // r.DefaultCellStyle.ForeColor = Color.RosyBrown;
                }
                else if (id > low && id <= medium)
                {
                    r.DefaultCellStyle.BackColor = Color.Turquoise;
                }
                else if (id >= high)
                {
                    r.DefaultCellStyle.BackColor = Color.Green;
                }
            }
        }

        private void admin_panel_Load(object sender, EventArgs e)
        {
            first_time ft = new first_time();
            ft.Close();
            change();
        }
        public void change()
        {
            //Class1.Cn.Open();
            //query = "SELECT * FROM stock_info where name='" + this.txtmedicinename.Text + "'";
            OleDbConnection cn = new OleDbConnection("Provider = Microsoft.Jet.OLEDB.4.0; Data Source =" + Class1.path + "; Jet OLEDB:Database password = medicine");
            cn.Open();
            query = "SELECT product_name,total_bottle FROM stock order by total_bottle";

            da = new OleDbDataAdapter(query, cn);
            cb = new OleDbCommandBuilder(da);
            dt = new DataTable();
            da.Fill(dt);
            bs = new BindingSource();
            bs.DataSource = dt;
            this.dataGridView1.DataSource = bs;
            this.timer1.Enabled = true;
            cn.Close();
            //Class1.Cn.Close();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            insert_pack_detail inpd = new insert_pack_detail();
            inpd.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            barcode bc = new barcode();
            bc.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            insert_newproducttype it = new insert_newproducttype();
            it.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            insert_table it = new insert_table();
            it.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            insert_rebate ir = new insert_rebate();
            ir.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            rebate_targer rt = new rebate_targer();
            rt.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            insert_tcs ic = new insert_tcs();
            ic.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            view_tcs_report vtr = new view_tcs_report();
            vtr.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            insert_return_tcs irt = new insert_return_tcs();
            irt.Show();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            insert_stock i_s = new insert_stock();
            i_s.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            creditors_ac ca = new creditors_ac();
            ca.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            creditor_money_return cmr = new creditor_money_return();
            cmr.Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            
            if (bl==null)
            {
                bl = new billing();
                bl.Show(this);
                bl.FormClosed += billing_close;

            }
            else
            {
                bl.WindowState = FormWindowState.Maximized;
            }
        }
        private void billing_close(object sender,EventArgs e)
        {
            bl = null;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            set_starting_date ssd = new set_starting_date();
            ssd.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            daily_report dr = new daily_report();
            dr.Show();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            total_billing tb = new total_billing();
            tb.Show();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            product_sale_report psr = new product_sale_report();
            psr.Show();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            sale_statement ss = new sale_statement();
            ss.Show();
        }

        private void button27_Click(object sender, EventArgs e)
        {
            show_stock ss = new show_stock();
            ss.Show();
        }

        private void button26_Click(object sender, EventArgs e)
        {
            show_pack sp = new show_pack();
            sp.Show();
        }

        private void button28_Click(object sender, EventArgs e)
        {
            insert_expenses ie = new insert_expenses();
            ie.Show();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            show_profitandloss spl = new show_profitandloss();
            spl.Show();
        }

        private void button24_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are You Sure TO Insert Opening Stock?Once You Insert openung stock you can not insert in this month again", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if (DialogResult.Yes == dr)
            {
                insert_opening_stock ios = new insert_opening_stock();
                ios.Show();
            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            delete_user du = new delete_user();
            du.Show();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            create_user cu = new create_user();
            cu.Show();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are You Sure TO Insert Closing Stock?Once You Insert Closing stock you can not insert in this month again", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if (DialogResult.Yes == dr)
            {
                insert_closing_stock ics = new insert_closing_stock();
                ics.Show();
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            show_user_ac sua = new show_user_ac();
            sua.Show();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            change_passowrd cp = new change_passowrd();
            cp.Show();
        }

        private void button29_Click(object sender, EventArgs e)
        {
            seting st = new seting();
            st.Show();
        }

        private void button30_Click(object sender, EventArgs e)
        {
            view_income_expenses vie = new view_income_expenses();
            vie.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            licence li = new licence();
            li.Show();
        }

        private void button31_Click(object sender, EventArgs e)
        {
            bill_print bp = new bill_print();
            bp.Show();
        }

        private void button32_Click(object sender, EventArgs e)
        {
            user_billing ub = new user_billing();
            ub.Show();
        }

        private void button33_Click(object sender, EventArgs e)
        {
            login_detail ld = new login_detail();
            ld.Show();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
            logout log = new logout();
            log.Show();
        }

        private void button35_Click(object sender, EventArgs e)
        {
            if (bl == null)
            {
                this.Close();
                logout log = new logout();
                log.Show();
            }
            else
            {
                MessageBox.Show("Please Close Billing First");
            }
        }

        private void button34_Click(object sender, EventArgs e)
        {
            insert_opeingstock_manualy iom = new insert_opeingstock_manualy();
            iom.Show();
        }

        private void button36_Click(object sender, EventArgs e)
        {
            search_by_invoice SBI = new search_by_invoice();
            SBI.Show();
        }

        private void button37_Click(object sender, EventArgs e)
        {
            invoice_scan ins = new invoice_scan();
            ins.Show();
        }

        private void button38_Click(object sender, EventArgs e)
        {
            backupandrestore bar = new backupandrestore();
            bar.Show();
        }

        private void button39_Click(object sender, EventArgs e)
        {
            item_sale_report isr = new item_sale_report();
            isr.Show();
        }

        private void button40_Click(object sender, EventArgs e)
        {
            table_sale_report tsr = new table_sale_report();
            tsr.Show();
        }

        private void button13_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button41_Click(object sender, EventArgs e)
        {
            Class1.Cn.Open();
            OleDbCommand cmd = new OleDbCommand("delete from stock where total_ml < 1",Class1.Cn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Cleared");
            Class1.Cn.Close();
        }

       

        
    }
}
