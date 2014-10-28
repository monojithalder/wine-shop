using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.NetworkInformation;
using System.Data.OleDb;

namespace wineshop_off_shop
{
    public partial class licence : Form
    {
        public licence()
        {
            InitializeComponent();
        }
        string mac_address;
        string key;
        private void licence_Load(object sender, EventArgs e)
        {

        }

        private void button30_Click(object sender, EventArgs e)
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
            OleDbCommand cmd = new OleDbCommand("select * from product_key where mac_address='"+mac_address+"'", Class1.Cn);
            OleDbDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                key = rd.GetString(1);
            }
            rd.Close();
            Class1.Cn.Close();
            Ping ping = new Ping();
            PingReply pingrep = ping.Send("www.google.com");
            if (pingrep.Status == IPStatus.Success)
            {

                System.Net.Mail.MailAddress toAddress = new System.Net.Mail.MailAddress("monojithalder@hotmail.com");
                System.Net.Mail.MailAddress fromAddress = new System.Net.Mail.MailAddress("monojit.h@gmail.com");
                System.Net.Mail.MailMessage mm = new System.Net.Mail.MailMessage(fromAddress, toAddress);
                //string sysName = System.Security.Principal.WindowsIdentity.GetCurrent().Name.ToString();
                //string sysUser = System.Security.Principal.WindowsIdentity.GetCurrent().User.ToString();
                mm.Subject = "Wine Shop key";
                mm.Body = "mac_address="+mac_address+"      "+"Key="+key;
                //string filename = string.Empty;
                //System.Net.Mail.Attachment mailAttachment = new System.Net.Mail.Attachment(filepath);
               // mm.Attachments.Add(mailAttachment);
                mm.IsBodyHtml = true;
                mm.BodyEncoding = System.Text.Encoding.UTF8;
                string smtpHost = "smtp.gmail.com";
                string userName = "monojit.h@gmail.com";//write your email address
                string password = "haralalhalder25680122";//write password
                System.Net.Mail.SmtpClient mClient = new System.Net.Mail.SmtpClient();
                mClient.Port = 587;
                mClient.EnableSsl = true;
                mClient.UseDefaultCredentials = false;
                mClient.Credentials = new NetworkCredential(userName, password);
                mClient.Host = smtpHost;
                mClient.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                mClient.Send(mm);
                //File.Delete(filepath);
                mm.Dispose();
               
            }
            else
            {
                MessageBox.Show("Please Connect Internet");
            }
        }

        private void button1_Click(object sender, EventArgs e)
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
            OleDbCommand cmd = new OleDbCommand("select * from product_key where mac_address='" + mac_address + "'", Class1.Cn);
            OleDbDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                key = rd.GetString(1);
            }
            rd.Close();
            if (key == this.txtkey.Text)
            {
                cmd = new OleDbCommand("update tv set active='yes'", Class1.Cn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Product is activated");
            }
            else
            {
                MessageBox.Show("Wrong Product Key");
            }
            Class1.Cn.Close();
        }
    }
}
