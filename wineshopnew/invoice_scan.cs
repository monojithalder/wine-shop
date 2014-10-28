using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WIA;
using System.Runtime.InteropServices;
using System.IO;
using System.Data.OleDb;

namespace wineshopnew
{
    public partial class invoice_scan : Form
    {
        public invoice_scan()
        {
            InitializeComponent();
        }
        WIA.CommonDialog dialog = new WIA.CommonDialog();
        ImageFile scannedImage = null;

        public abstract class EnvFormatID
        {

            public const string wiaFormatBMP = "{B96B3CAB-0728-11D3-9D7B-0000F81EF32E}";

            public const string wiaFormatGIF = "{B96B3CB0-0728-11D3-9D7B-0000F81EF32E}";

            public const string wiaFormatJPEG = "{B96B3CAE-0728-11D3-9D7B-0000F81EF32E}";

            public const string wiaFormatPNG = "{B96B3CAF-0728-11D3-9D7B-0000F81EF32E}";

            public const string wiaFormatTIFF = "{B96B3CB1-0728-11D3-9D7B-0000F81EF32E}";

        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtinvoice.Text != "")
                {
                    if (!Directory.Exists(Environment.CurrentDirectory + "\\scanimage"))
                    {
                        Directory.CreateDirectory(Environment.CurrentDirectory + "\\scanimage");
                    }
                    pictureBoxScannedImage.SizeMode = PictureBoxSizeMode.StretchImage;
                    WIA.CommonDialog commonDialogClass = new WIA.CommonDialog();
                    Device scannerDevice = commonDialogClass.ShowSelectDevice(WiaDeviceType.ScannerDeviceType, false, false);

                    if (scannerDevice != null)
                    {

                        Item scannnerItem = scannerDevice.Items[1];

                        AdjustScannerSettings(scannnerItem, 300, 0, 0, 2500, 2000, 0, 0);

                        object scanResult = commonDialogClass.ShowTransfer(scannnerItem, EnvFormatID.wiaFormatJPEG, false);

                        if (scanResult != null)
                        {

                            ImageFile image = (ImageFile)scanResult;


                            string fileName = Environment.CurrentDirectory + "\\scanimage\\" + this.txtinvoice.Text + ".png";
                            if (File.Exists(fileName))
                            {
                                MessageBox.Show("Already exists");
                            }
                            else
                            {
                                System.Drawing.Size s = new System.Drawing.Size();
                                s.Width = 100;
                                s.Height = 100;
                                SaveImageToPNGFile(image, fileName);
                                pictureBoxScannedImage.ImageLocation = fileName;
                            }

                        }

                    }
                    int flag = check_invoice_no(this.txtinvoice.Text);
                    if (flag < 1)
                    {
                        Class1.Cn.Open();
                        string pic = this.txtinvoice.Text + ".png";
                        OleDbCommand cmd = new OleDbCommand("insert into scan_invoice (invoice_no,img_path) values ('" + this.txtinvoice.Text + "','" + pic + "')", Class1.Cn);
                        cmd.ExecuteNonQuery();
                        Class1.Cn.Close();
                    }
                    else
                    {
                        MessageBox.Show("Already Inserted");
                    }
                }
                else
                {
                    MessageBox.Show("Please Enter Invoice No");
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }

        }
        private int check_invoice_no(string invoice_no)
        {
            Class1.Cn.Open();
            int flag = 0;
            OleDbCommand cmd = new OleDbCommand("select * from scan_invoice where invoice_no='" + invoice_no + "'", Class1.Cn);
            OleDbDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                flag++;
            }
            rd.Close();
            Class1.Cn.Close();
            return flag;
        }
        private static void AdjustScannerSettings(IItem scannnerItem, int scanResolutionDPI, int scanStartLeftPixel, int scanStartTopPixel,

            int scanWidthPixels, int scanHeightPixels, int brightnessPercents, int contrastPercents)
        {

            const string WIA_HORIZONTAL_SCAN_RESOLUTION_DPI = "6147";

            const string WIA_VERTICAL_SCAN_RESOLUTION_DPI = "6148";

            const string WIA_HORIZONTAL_SCAN_START_PIXEL = "6149";

            const string WIA_VERTICAL_SCAN_START_PIXEL = "6150";

            const string WIA_HORIZONTAL_SCAN_SIZE_PIXELS = "6151";

            const string WIA_VERTICAL_SCAN_SIZE_PIXELS = "6152";

            const string WIA_SCAN_BRIGHTNESS_PERCENTS = "6154";

            const string WIA_SCAN_CONTRAST_PERCENTS = "6155";

            SetWIAProperty(scannnerItem.Properties, WIA_HORIZONTAL_SCAN_RESOLUTION_DPI, scanResolutionDPI);

            SetWIAProperty(scannnerItem.Properties, WIA_VERTICAL_SCAN_RESOLUTION_DPI, scanResolutionDPI);

            SetWIAProperty(scannnerItem.Properties, WIA_HORIZONTAL_SCAN_START_PIXEL, scanStartLeftPixel);

            SetWIAProperty(scannnerItem.Properties, WIA_VERTICAL_SCAN_START_PIXEL, scanStartTopPixel);

            SetWIAProperty(scannnerItem.Properties, WIA_HORIZONTAL_SCAN_SIZE_PIXELS, scanWidthPixels);

            SetWIAProperty(scannnerItem.Properties, WIA_VERTICAL_SCAN_SIZE_PIXELS, scanHeightPixels);

            SetWIAProperty(scannnerItem.Properties, WIA_SCAN_BRIGHTNESS_PERCENTS, brightnessPercents);

            SetWIAProperty(scannnerItem.Properties, WIA_SCAN_CONTRAST_PERCENTS, contrastPercents);

        }
        private static void SetWIAProperty(IProperties properties, object propName, object propValue)
        {

            Property prop = properties.get_Item(ref propName);

            prop.set_Value(ref propValue);

        }
        private static void SaveImageToPNGFile(ImageFile image, string fileName)
        {

            ImageProcess imgProcess = new ImageProcess();

            object convertFilter = "Convert";

            string convertFilterID = imgProcess.FilterInfos.get_Item(ref convertFilter).FilterID;

            imgProcess.Filters.Add(convertFilterID, 0);

            SetWIAProperty(imgProcess.Filters[imgProcess.Filters.Count].Properties, "FormatID", EnvFormatID.wiaFormatJPEG);

            image = imgProcess.Apply(image);

            image.SaveFile(fileName);

        }

        private void invoice_scan_Load(object sender, EventArgs e)
        {

        }

       
    }
}
