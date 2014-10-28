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
    public partial class creditors_ac : Form
    {
        public creditors_ac()
        {
            InitializeComponent();
        }
        DataTable dt = new DataTable();
        BindingSource bs = new BindingSource();
        string cre_name;
        decimal dr = 0, cr = 0;
        private void creditors_ac_Load(object sender, EventArgs e)
        {
            dt.Columns.Add("Creditors Name");
            dt.Columns.Add("CR");
            dt.Columns.Add("DR");
            Class1.Cn.Open();
            int[] id = new int[sizeof(int)];
            int j = 0;


            OleDbCommand cmd = new OleDbCommand("select * from creditors", Class1.Cn);
            OleDbDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                id[j] = rd.GetInt32(0);
                j++;
            }
            rd.Close();
            for (int i = 0; i < j; i++)
            {

                cmd = new OleDbCommand("select * from creditor_account where creditor_id=" + id[i] + "", Class1.Cn);
                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    cre_name = rd.GetString(2);
                    dr += Convert.ToDecimal(rd.GetValue(3));
                    cr += Convert.ToDecimal(rd.GetValue(4));
                }
                //dt.Rows.Add(cre_name,cr,dr);
                rd.Close();
                insert_into_datatable(cre_name);

            }
            Class1.Cn.Close();
            bs.DataSource = dt;
            this.dataGridView1.DataSource = bs;


        }
        private void insert_into_datatable(string name1)
        {
            dt.Rows.Add(name1, cr.ToString("00.00"), dr.ToString("00.00"));
            dr = 0;
            cr = 0;
        }
    }
}
