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
    public partial class user_control_panel : Form
    {
        public user_control_panel()
        {
            InitializeComponent();
        }
        string query;
        OleDbDataAdapter da;
        OleDbCommandBuilder cb;
        DataTable dt;
        BindingSource bs;
        int low=0, medium=0, high=0;
        public billing bl = null;
        private void button3_Click(object sender, EventArgs e)
        {
            if (bl == null)
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
        private void billing_close(object sender, EventArgs e)
        {
            bl = null;
        }

        private void button22_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are You Sure TO Insert Opening Stock?Once You Insert openung stock you can not insert in this month again","Warning",MessageBoxButtons.YesNo,MessageBoxIcon.Asterisk);
            if (DialogResult.Yes == dr)
            {
                insert_opening_stock ios = new insert_opening_stock();
                ios.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are You Sure TO Insert Closing Stock?Once You Insert Closing stock you can not insert in this month again","Warning",MessageBoxButtons.YesNo,MessageBoxIcon.Asterisk);
            if (DialogResult.Yes == dr)
            {
                insert_closing_stock ics = new insert_closing_stock();
                ics.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            insert_expenses ie = new insert_expenses();
            ie.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            change_passowrd cp = new change_passowrd();
            cp.Show();
        }

        private void user_control_panel_Load(object sender, EventArgs e)
        {
            this.label3.Text = Class1.user;
            change();
        }
        public void change()
        {
            Class1.Cn.Open();
            //query = "SELECT * FROM stock_info where name='" + this.txtmedicinename.Text + "'";
            query = "SELECT product_name,total_bottle FROM stock order by total_bottle";

            da = new OleDbDataAdapter(query, Class1.Cn);
            cb = new OleDbCommandBuilder(da);
            dt = new DataTable();
            da.Fill(dt);
            bs = new BindingSource();
            bs.DataSource = dt;
            this.dataGridView1.DataSource = bs;
            this.timer1.Enabled = true;
            Class1.Cn.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            change();
            Class1.Cn.Open();
            OleDbCommand cmd = new OleDbCommand("select * from setting",Class1.Cn);
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
            Class1.Cn.Close();
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

        private void button6_Click(object sender, EventArgs e)
        {
            daily_report dr = new daily_report();
            dr.Show();
        }

        private void button5_Click(object sender, EventArgs e)
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
            
        }

        private void button30_Click(object sender, EventArgs e)
        {
            view_income_expenses vie = new view_income_expenses();
            vie.Show();
        }

        private void button26_Click(object sender, EventArgs e)
        {
            show_pack sp = new show_pack();
            sp.Show();
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Class1.Cn.Open();
            OleDbCommand cmd = new OleDbCommand("delete from stock where total_ml < 1", Class1.Cn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Cleared");
            Class1.Cn.Close();
        }

        private void button32_Click(object sender, EventArgs e)
        {
            user_billing ub = new user_billing();
            ub.Show();
        }

        private void button31_Click(object sender, EventArgs e)
        {
            bill_print bp = new bill_print();
            bp.Show();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            product_sale_report psr = new product_sale_report();
            psr.Show();
        }

        private void button39_Click(object sender, EventArgs e)
        {
            item_sale_report isr = new item_sale_report();
            isr.Show();
        }

      

       
      

       
    }
}
