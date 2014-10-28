using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;

namespace wineshopnew
{
    public partial class backupandrestore : Form
    {
        public backupandrestore()
        {
            InitializeComponent();
        }
        public string path;
        public string path1;
        public string path2;
        string[] fi;
        string[] fi2;
        private void timer1_Tick(object sender, EventArgs e)
        {
            FileInfo finfo = new FileInfo(Class1.path);
            FileInfo finfo1 = new FileInfo(path + "backup\\wineshopmanagement.mdb");
            if (this.progressBar1.Value == Convert.ToInt32(finfo.Length))
            {

                this.timer1.Enabled = false;
                MessageBox.Show("Backup Sussessfull");
            }
            else
            {
                if (finfo1.Exists)
                {
                    this.progressBar1.Value = Convert.ToInt32(finfo1.Length);
                }
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            FileInfo finfo = new FileInfo(path1 + "\\wineshopmanagement.mdb");
            FileInfo finfo1 = new FileInfo(Class1.path);
            if (this.progressBar1.Value == Convert.ToInt32(finfo.Length))
            {

                this.timer2.Enabled = false;
                MessageBox.Show("Restore Sussessfull");

            }
            else
            {
                if (finfo.Exists)
                {
                    this.progressBar2.Value = Convert.ToInt32(finfo.Length);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            path = folderBrowserDialog1.SelectedPath;
            //MessageBox.Show(path.ToString());
            FileInfo finfo = new FileInfo(Class1.path);
            this.progressBar1.Maximum = Convert.ToInt32(finfo.Length);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string d, c, dir1 = Environment.CurrentDirectory + "\\scanimage", filename, com;
                if (!Directory.Exists(path + "backup"))
                {
                    Directory.CreateDirectory(path + "backup");
                    Directory.CreateDirectory(path + "backup\\scanimage");
                    fi2 = Directory.GetFiles(dir1);
                    foreach (string s1 in fi2)
                    {
                        filename = Path.GetFileName(s1);
                        com = Path.Combine(dir1, filename);
                        File.Copy(com, path + "backup\\scanimage\\" + filename);

                    }
                    File.Copy(Class1.path, path + "backup\\wineshopmanagement.mdb");
                    timer1.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Backup Folder already exists Please Delete the folder and take backup again");
                }

            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                //openFileDialog1.ShowDialog();
                folderBrowserDialog1.ShowDialog();
                path1 = folderBrowserDialog1.SelectedPath;

                //MessageBox.Show(path1.ToString());
                FileInfo finfo = new FileInfo(path1 + "\\wineshopmanagement.mdb");
                this.progressBar2.Maximum = Convert.ToInt32(finfo.Length);
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string d, c, dir1 = Environment.CurrentDirectory + "\\scanimage", filename, com;
                if (path1 != "")
                {

                    if (File.Exists(Class1.path))
                    {
                        fi = Directory.GetFiles(dir1);
                        foreach (string s in fi)
                        {
                            filename = Path.GetFileName(s);
                            com = Path.Combine(dir1, filename);
                            File.Delete(com);

                        }
                        fi2 = Directory.GetFiles(path1 + "\\scanimage");
                        foreach (string s1 in fi2)
                        {
                            filename = Path.GetFileName(s1);
                            com = Path.Combine(path1 + "\\scanimage\\", filename);
                            File.Copy(com, Environment.CurrentDirectory + "\\scanimage\\" + filename);


                        }
                        File.Delete(Class1.path);
                        File.Copy(path1+"\\wineshopmanagement.mdb", Class1.path);
                        timer2.Enabled = true;
                    }
                    else
                    {
                        fi2 = Directory.GetFiles(path1);
                        foreach (string s1 in fi2)
                        {
                            filename = Path.GetFileName(s1);
                            com = Path.Combine(dir1, filename);
                            File.Copy(com, Environment.CurrentDirectory + "\\scanimage\\" + filename);

                        }
                        File.Copy(path1+"\\wineshopmanagement.mdb", Class1.path);
                        timer2.Enabled = true;
                    }
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }
        private void inisialize_array()
        {
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(Environment.CurrentDirectory + "\\scanimage");
            int count = dir.GetFiles().Length;
            fi = new string[count];
            fi2 = new string[count];
            //MessageBox.Show(count.ToString());
        }

        private void backupandrestore_Load(object sender, EventArgs e)
        {

        }
    }
}
