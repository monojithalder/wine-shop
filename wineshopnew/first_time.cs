using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.Data.OleDb;

namespace wineshopnew
{
    public partial class first_time : Form
    {
        public first_time()
        {
            InitializeComponent();
        }
        string mac_address = "";
        int flag = 0, flag2 = 0;
        DateTime st_date;
        int days_remain;
        int pass_days = 0, re_date = 0;
        DateTime realdate;
        private void first_time_Load(object sender, EventArgs e)
        {
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (nic.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
                {
                    //MessageBox.Show(nic.GetPhysicalAddress().ToString());
                    mac_address = nic.GetPhysicalAddress().ToString();
                }
            }
            Class1.Cn.Open();
            OleDbCommand cmd = new OleDbCommand("select * from product_key", Class1.Cn);
            OleDbDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                if (rd.GetString(0) == mac_address)
                {
                    flag++;
                }
            }
            rd.Close();
            Class1.Cn.Close();
            if (flag > 0)
            {
                Class1.Cn.Open();
                cmd = new OleDbCommand("select * from sd", Class1.Cn);
                OleDbDataReader rd2 = cmd.ExecuteReader();
                while (rd2.Read())
                {
                    st_date = rd2.GetDateTime(1);
                }
                rd2.Close();
                cmd = new OleDbCommand("select * from tv", Class1.Cn);
                rd2 = cmd.ExecuteReader();
                while (rd2.Read())
                {
                    days_remain = rd2.GetInt32(3);
                }
                rd2.Close();
                realdate = st_date.AddDays(days_remain);
                TimeSpan ts = DateTime.Now - realdate;
                if (ts.TotalDays < -1)
                {
                    MessageBox.Show("Your date is not valid");
                    Application.Exit();
                }
                cmd = new OleDbCommand("select * from tv", Class1.Cn);
                rd2 = cmd.ExecuteReader();
                while (rd2.Read())
                {
                    if (rd2.GetString(1) == "yes")
                    {
                        flag2++;
                    }

                }
                rd2.Close();
                if (flag2 > 0)
                {
                    string user = Class1.user;
                    if (user == "admin")
                    {
                        Class1.Cn.Close();
                        this.Close();
                        admin_panel ap = new admin_panel();
                        ap.Show();
                        //this.Hide();
                    }
                    else
                    {
                        Class1.Cn.Close();
                        this.Close();
                        user_control_panel ucp = new user_control_panel();
                        ucp.Show();
                        // this.Hide();

                    }
                }
                else
                {
                    cmd = new OleDbCommand("select * from tv", Class1.Cn);
                    rd2 = cmd.ExecuteReader();
                    rd2.Read();
                    if (rd2.GetInt32(2) == 0)
                    {
                        MessageBox.Show("Your trial version is expired");
                        Application.Exit();
                    }
                    else
                    {
                        int flag5 = 0;
                        OleDbCommand cmd3 = new OleDbCommand("select * from daily_login", Class1.Cn);
                        OleDbDataReader rd4 = cmd3.ExecuteReader();
                        while (rd4.Read())
                        {
                            if (DateTime.Now.Year == rd4.GetDateTime(1).Year)
                            {
                                if (DateTime.Now.Date == rd4.GetDateTime(1).Date && DateTime.Now.Month == rd4.GetDateTime(1).Month)
                                {
                                    flag5++;
                                }
                            }
                        }
                        if (flag5 < 1)
                        {
                            cmd = new OleDbCommand("insert into daily_login (daily_login) values ('" + DateTime.Now + "')", Class1.Cn);
                            cmd.ExecuteNonQuery();
                            cmd = new OleDbCommand("select * from tv", Class1.Cn);
                            OleDbDataReader rd3 = cmd.ExecuteReader();
                            while (rd3.Read())
                            {
                                pass_days = rd3.GetInt32(3);
                                re_date = rd3.GetInt32(2);
                            }
                            rd4.Close();
                            TimeSpan ts1 = DateTime.Now - st_date;
                            int temp, temp1;
                            temp = pass_days + 1;
                            temp1 = re_date - 1;
                            cmd = new OleDbCommand("update tv set active='no',days_remain=" + temp1 + ",days_pass=" + temp + "", Class1.Cn);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("your application is expire in" + temp1.ToString());
                            string user = Class1.user;
                            if (user == "admin")
                            {
                                Class1.Cn.Close();
                                this.Close();
                                admin_panel ap = new admin_panel();
                                ap.Show();
                                //this.Hide();
                            }
                            else
                            {
                                Class1.Cn.Close();
                                this.Close();
                                user_control_panel ucp = new user_control_panel();
                                ucp.Show();
                                //this.Hide();

                            }
                        }
                        else
                        {
                            cmd = new OleDbCommand("select * from tv", Class1.Cn);
                            OleDbDataReader rd5 = cmd.ExecuteReader();
                            rd5.Read();
                            //MessageBox.Show(rd5.GetInt32(2).ToString());
                            MessageBox.Show("your application is expire in" + rd5.GetInt32(2).ToString());
                            string user = Class1.user;
                            if (user == "admin")
                            {
                                Class1.Cn.Close();
                                this.Close();
                                admin_panel ap = new admin_panel();
                                ap.Show();
                                //this.Hide();
                            }
                            else
                            {
                                Class1.Cn.Close();
                                this.Close();
                                user_control_panel ucp = new user_control_panel();
                                ucp.Show();
                                //this.Hide();

                            }
                        }
                    }
                }
                Class1.Cn.Close();
            }
            else
            {
                Class1.Cn.Open();
                string random = System.IO.Path.GetRandomFileName().Replace(".", string.Empty);
                cmd = new OleDbCommand("insert into product_key (mac_address,key1) values ('" + mac_address + "','" + random + "')", Class1.Cn);
                cmd.ExecuteNonQuery();
                cmd = new OleDbCommand("insert into sd (s_date) values ('" + DateTime.Now + "')", Class1.Cn);
                cmd.ExecuteNonQuery();
                cmd = new OleDbCommand("select * from sd", Class1.Cn);
                OleDbDataReader rd1 = cmd.ExecuteReader();
                DateTime after_month;
                TimeSpan days;
                while (rd1.Read())
                {
                    st_date = rd1.GetDateTime(1);
                }
                rd1.Close();
                after_month = st_date.AddDays(30);
                days = after_month - DateTime.Now;
                cmd = new OleDbCommand("update tv set active=no and days_remain=" + Convert.ToInt32(days.TotalDays) + "", Class1.Cn);
                cmd.ExecuteNonQuery();
                Class1.Cn.Close();

            }

        }
    }
}
