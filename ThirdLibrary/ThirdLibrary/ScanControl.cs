using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WIA;
using System.Drawing.Imaging;
using System.IO;
namespace ThirdLibrary
{
    public partial class ScanControl : UserControl
    {
        public ScanControl()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 自动扫描文件
        /// </summary>
        /// <param name="byteImage">输出图片二进制字节流</param>
        /// <returns>执行结构 true表示扫描成功 fale表示扫描失败</returns>
        public bool AutoScanFile(out byte[] byteImage)
        {
            byteImage = null;
            int xLeft = 0;
            int xRight = 0;
            int yTotp=0;
            int yBotom=0;
            DeviceManager manager = new DeviceManagerClass();
            Device device = null;
            foreach (DeviceInfo info in manager.DeviceInfos)
            {

                if (info.Type != WiaDeviceType.ScannerDeviceType) continue;

                device = info.Connect();

                break;

            }
            Item item = device.Items[1];

            CommonDialogClass cdc = new WIA.CommonDialogClass();
            ImageFile imageFile = cdc.ShowTransfer(item,
                "{B96B3CAB-0728-11D3-9D7B-0000F81EF32E}",
                true) as ImageFile;
            System.IO.MemoryStream ms = new MemoryStream();
            if (imageFile != null)
            {
                var buffer = imageFile.FileData.get_BinaryData() as byte[];

                ms.Write(buffer, 0, buffer.Length);
            }
            else
            {
                return false;
            }

            Color c1 = new Color();
            Color c2 = new Color();
            Color c3 = new Color();
            Color c4 = new Color();
            Color c5 = new Color();
            Color c6 = new Color();
            Color c7 = new Color();
            Color c8 = new Color();
            Color c9 = new Color();

            int rr, r1, r2, r3, r4, r5, r6, r7, r8, r9, fxr, i, j;
            // int g1, g2, g3, g4, fxg, fyg, b1, b2, b3, b4, fxb, fyb;
            Bitmap imgTem = (Bitmap)Bitmap.FromStream(ms);
            for (i = 1; i < imgTem.Width - 2; i++)
            {
                for (j = 1; j < imgTem.Height - 2; j++)
                {
                    c1 = imgTem.GetPixel(i, j - 1);
                    c2 = imgTem.GetPixel(i - 1, j);
                    c3 = imgTem.GetPixel(i, j);
                    c4 = imgTem.GetPixel(i + 1, j);
                    c5 = imgTem.GetPixel(i, j + 1);
                    c6 = imgTem.GetPixel(i - 1, j - 1);
                    c7 = imgTem.GetPixel(i - 1, j + 1);
                    c8 = imgTem.GetPixel(i + 1, j - 1);
                    c9 = imgTem.GetPixel(i + 1, j + 1);
                    r1 = c1.R;
                    r2 = c2.R;
                    r3 = c3.R;
                    r4 = c4.R;
                    r5 = c5.R;
                    r6 = c6.R;
                    r7 = c7.R;
                    r8 = c8.R;
                    r9 = c9.R;
                    fxr = 8 * r3 - r1 - r2 - r4 - r5 - r6 - r7 - r8 - r9;
                    // fyr = r6 + 2 * r1 + r8 - r7 - 2 * r5 - r9;
                    rr = Math.Abs(fxr);
                    if (rr < 0) rr = 0;
                    if (rr > 255) rr = 255;
                    Color cc = Color.FromArgb(rr, rr, rr);
                    imgTem.SetPixel(i, j, cc);

                }

            }

            bool isc = false;
            Color pixel;
            //污点熟练
            int maxc = 5;
            #region 扫描左空白
            for (int x = 1; x < imgTem.Width - 2; x++)
            {
                int c = 0;
                for (int y = 1; y < imgTem.Height - 2; y++)
                {
                    pixel = imgTem.GetPixel(x, y);
                    int r, g, b;
                    r = pixel.R;
                    g = pixel.G;
                    b = pixel.B;

                    if (r == 255 && g == 255 && b == 255)
                    {
                        c++;
                        if (c >= maxc)
                        {
                            isc = false;
                            break;
                        }
                    }
                    else
                    {
                        isc = true;
                    }

                }
                if (isc == false)
                {

                    xLeft = x;
                    break;
                }
            }
            #endregion

            #region 扫描右空白
            for (int x = imgTem.Width - 2; x > 2; x--)
            {
                int c = 0;
                for (int y = imgTem.Height - 2; y > 2; y--)
                {
                    pixel = imgTem.GetPixel(x, y);
                    int r, g, b;
                    r = pixel.R;
                    g = pixel.G;
                    b = pixel.B;
                    if (r == 255 && g == 255 && b == 255)
                    {
                        c++;
                        if (c >= maxc)
                        {
                            isc = false;
                            break;
                        }
                    }
                    else
                    {
                        isc = true;
                    }

                }
                if (isc == false)
                {

                    xRight = x;
                    break;
                }
            }
            #endregion

            #region 扫描底部空白
            for (int y = imgTem.Height - 2; y > 2; y--)
            {
                int c = 0;
                for (int x = imgTem.Width - 2; x > 2; x--)
                {
                    pixel = imgTem.GetPixel(x, y);
                    int r, g, b;
                    r = pixel.R;
                    g = pixel.G;
                    b = pixel.B;
                    if (r == 255 && g == 255 && b == 255)
                    {
                        c++;
                        if (c >= maxc)
                        {
                            isc = false;
                            break;
                        }
                    }
                    else
                    {
                        //imgTem = Clip(imgTem, 0, 0, x, imgTem.Height);
                        //pictureimgTem.Image = imgTem;
                        //pictureimgTem.Image = imgTem;
                        isc = true;
                    }

                }
                if (isc == false)
                {

                    yBotom = y;
                    break;
                }
            }
            #endregion

            #region 扫描上部空白
            for (int y = 1; y < imgTem.Height - 2; y++)
            {
                int c = 0;
                for (int x = 1; x < imgTem.Width - 2; x++)
                {
                    pixel = imgTem.GetPixel(x, y);
                    int r, g, b;
                    r = pixel.R;
                    g = pixel.G;
                    b = pixel.B;

                    if (r == 255 && g == 255 && b == 255)
                    {
                        c++;
                        if (c >= maxc)
                        {
                            isc = false;
                            break;
                        }
                    }
                    else
                    {
                        isc = true;
                    }

                }
                if (isc == false)
                {

                    yTotp = y;
                    break;
                }
            }
            #endregion

            //剪切图片
            imgTem = (Bitmap)Bitmap.FromStream(ms);
            imgTem = Clip(imgTem, xLeft - 5, yTotp - 5, xRight - xLeft + 5, yBotom - yTotp + 5);


            string strCurpath = System.IO.Directory.GetCurrentDirectory() + "\\scantdtk.bmp";
            imgTem.Save(strCurpath, ImageFormat.Bmp);
            byteImage = System.IO.File.ReadAllBytes(strCurpath);
            return true;
        }


    
        /// <summary>
        /// 文件扫描函数
        /// </summary>
        /// <param name="byteImage">输出图片二进制字节流</param>
        /// <param name="x">扫描起始点x轴</param>
        /// <param name="y">扫描起始点y轴</param>
        /// <param name="w">扫描范围宽度</param>
        /// <param name="h">扫描范围高度</param>
        /// <returns>执行结构 true表示扫描成功 fale表示扫描失败</returns>
        public bool ScanFile(out byte[] byteImage, int x, int y, int w, int h)
        {
            byteImage = null;
            DeviceManager manager = new DeviceManagerClass();
            Device device = null;
            foreach (DeviceInfo info in manager.DeviceInfos)
            {

                if (info.Type != WiaDeviceType.ScannerDeviceType) continue;

                device = info.Connect();

                break;

            }
            Item item = device.Items[1];

            CommonDialogClass cdc = new WIA.CommonDialogClass();
            ImageFile imageFile = cdc.ShowTransfer(item,
                "{B96B3CAB-0728-11D3-9D7B-0000F81EF32E}",
                true) as ImageFile;

            if (imageFile != null)
            {
                var buffer = imageFile.FileData.get_BinaryData() as byte[];
                using (System.IO.MemoryStream ms = new MemoryStream())
                {
                    ms.Write(buffer, 0, buffer.Length);
                    string strCurpath = System.IO.Directory.GetCurrentDirectory() + "\\scantdtk.bmp";
                    Image.FromStream(ms).Save(strCurpath, ImageFormat.Bmp);
                    Image img = Clip((Bitmap)Image.FromStream(ms), x, y, w, h);
                    img.Save(strCurpath, ImageFormat.Bmp);
                    byteImage = System.IO.File.ReadAllBytes(strCurpath);
                    return true;
                }

            }
            else
            {
                return false;
            }

        }

        public Bitmap Clip(Bitmap b, int StartX, int StartY, int iWidth, int iHeight)
        {
            Bitmap bmpOut = new Bitmap(iWidth, iHeight, System.Drawing.Imaging.PixelFormat.Format24bppRgb);

            Graphics g = Graphics.FromImage(bmpOut);
            g.DrawImage(b, new Rectangle(0, 0, iWidth, iHeight), new Rectangle(StartX, StartY, iWidth, iHeight), GraphicsUnit.Pixel);
            g.Dispose();

            return bmpOut;

        }

        private void ScanControl_Load(object sender, EventArgs e)
        {

        }
    }
}
