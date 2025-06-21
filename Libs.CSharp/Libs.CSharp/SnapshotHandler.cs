using System.Drawing.Imaging;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Interop;
using System.Windows.Media.Imaging;
using System.Windows;
using System;

namespace Libs.CSharp
{
    public class SnapshotHandler
    {
        [StructLayout(LayoutKind.Sequential)]
        private struct RECT
        {
            public int m_left;
            public int m_top;
            public int m_right;
            public int m_bottom;
        }

        [DllImport("user32.dll")]
        private static extern IntPtr GetWindowRect(IntPtr hWnd, ref RECT rect);

        public static void SaveToFile(IntPtr handle_, string pathSaveFile, int paddingLeft = 0, int paddingTop = 0, int paddingRight = 0, int paddingBot = 0)
        {
            RECT windowRect = new RECT();
            GetWindowRect(handle_, ref windowRect);

            int width = windowRect.m_right - windowRect.m_left - paddingLeft - paddingRight;
            int height = windowRect.m_bottom - windowRect.m_top - paddingTop - paddingBot;
            System.Drawing.Point topLeft = new System.Drawing.Point(windowRect.m_left + paddingLeft, windowRect.m_top + paddingTop);

            Bitmap b = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(b);
            g.CopyFromScreen(topLeft, new System.Drawing.Point(0, 0), new System.Drawing.Size(width, height));
            b.Save(pathSaveFile, ImageFormat.Jpeg);
        }

        public static void ToClipbroad(IntPtr handle_, int paddingLeft = 8, int paddingTop = 2, int paddingRight = 8, int paddingBot = 8)
        {
            RECT windowRect = new RECT();
            GetWindowRect(handle_, ref windowRect);

            int width = windowRect.m_right - windowRect.m_left - paddingLeft - paddingRight;
            int height = windowRect.m_bottom - windowRect.m_top - paddingTop - paddingBot;
            System.Drawing.Point topLeft = new System.Drawing.Point(windowRect.m_left + paddingLeft, windowRect.m_top + paddingTop);

            Bitmap b = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(b);
            g.CopyFromScreen(topLeft, new System.Drawing.Point(0, 0), new System.Drawing.Size(width, height));

            BitmapSource bitmapSource = Imaging.CreateBitmapSourceFromHBitmap(b.GetHbitmap(), IntPtr.Zero, System.Windows.Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            Clipboard.SetImage(bitmapSource);
        }
    }
}
