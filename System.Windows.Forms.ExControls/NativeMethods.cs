using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;

namespace System.Windows.Forms.ExControls
{
    /// <summary>
    /// CodeProject.com "Simple pop-up control" "http://www.codeproject.com/cs/miscctrl/simplepopup.asp".
    /// </summary>
    internal static class NativeMethods
    {
        #region Constants
        internal const int WM_NCHITTEST = 0x0084,
                           WM_NCACTIVATE = 0x0086,
                           WS_EX_NOACTIVATE = 0x08000000,
                           HTTRANSPARENT = -1,
                           HTLEFT = 10,
                           HTRIGHT = 11,
                           HTTOP = 12,
                           HTTOPLEFT = 13,
                           HTTOPRIGHT = 14,
                           HTBOTTOM = 15,
                           HTBOTTOMLEFT = 16,
                           HTBOTTOMRIGHT = 17,
                           WM_USER = 0x0400,
                           WM_REFLECT = WM_USER + 0x1C00,
                           WM_COMMAND = 0x0111,
                           CBN_DROPDOWN = 7,
                           WM_GETMINMAXINFO = 0x0024;

        internal static int HIWORD(int n)
        {
            return (n >> 16) & 0xffff;
        }

        internal static int HIWORD(IntPtr n)
        {
            return HIWORD(unchecked((int)(long)n));
        }

        internal static int LOWORD(int n)
        {
            return n & 0xffff;
        }

        internal static int LOWORD(IntPtr n)
        {
            return LOWORD(unchecked((int)(long)n));
        }
        #endregion

        #region CheckBoxComboBox

        [StructLayout(LayoutKind.Sequential)]
        internal struct MINMAXINFO
        {
            public Point reserved;
            public Size maxSize;
            public Point maxPosition;
            public Size minTrackSize;
            public Size maxTrackSize;
        }

        #endregion

        #region TabControlEx

        #region GDI functions
        [DllImport("gdi32.dll", EntryPoint = "CreateCompatibleDC", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr CreateCompatibleDC(IntPtr hdc);

        [DllImport("gdi32.dll", EntryPoint = "DeleteDC", CallingConvention = CallingConvention.StdCall)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DeleteDC(IntPtr hdc);

        [DllImport("gdi32.dll", EntryPoint = "CreateCompatibleBitmap", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr CreateCompatibleBitmap(IntPtr hdc, int nWidth, int nHeight);

        [DllImport("gdi32.dll", EntryPoint = "SelectObject", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr SelectObject(IntPtr hdc, IntPtr hgdiobj);

        [DllImport("gdi32.dll", EntryPoint = "DeleteObject", CallingConvention = CallingConvention.StdCall)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DeleteObject(IntPtr hObject);

        [DllImport("gdi32.dll", EntryPoint = "StretchBlt", CallingConvention = CallingConvention.StdCall)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool StretchBlt(IntPtr hdcDest, int nXOriginDest, int nYOriginDest, int nWidthDest, int nHeightDest,
            IntPtr hdcSrc, int nXOriginSrc, int nYOriginSrc, int nWidthSrc, int nHeightSrc, uint dwRop);

        [DllImport("gdi32.dll", EntryPoint = "BitBlt", CallingConvention = CallingConvention.StdCall)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool BitBlt(IntPtr hdcDest, int nXDest, int nYDest, int nWidth, int nHeight,
            IntPtr hdcSrc, int nXSrc, int nYSrc, uint dwRop);

        //Some raster operations
        public const uint SRCCOPY = 0x00CC0020;

        [DllImport("gdi32.dll", EntryPoint = "GetPixel", CallingConvention = CallingConvention.StdCall)]
        public static extern uint GetPixel(IntPtr hdc, int nXPos, int nYPos);

        [DllImport("gdi32.dll", EntryPoint = "SetPixel", CallingConvention = CallingConvention.StdCall)]
        public static extern uint SetPixel(IntPtr hdc, int X, int Y, uint crColor);
        #endregion

        [DllImport("user32.dll", EntryPoint = "SendMessageW", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", EntryPoint = "RealGetWindowClassW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        public static extern uint RealGetWindowClass(IntPtr hWnd, StringBuilder ClassName, uint ClassNameMax);

        #region API Structures
        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int x, y;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct TCHITTESTINFO
        {
            public POINT pt;
            public uint flags;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct WINDOWPOS
        {
            public IntPtr hwnd, hwndInsertAfter;
            public int x, y, cx, cy, flags;
        }
        #endregion

        #region Constants
        public const int TCM_HITTEST = 0x130d, WM_SETFONT = 0x0030, WM_THEMECHANGED = 0x031a,
            WM_DESTROY = 0x0002, WM_NCDESTROY = 0x0082, WM_WINDOWPOSCHANGING = 0x0046,
            WM_PARENTNOTIFY = 0x0210, WM_CREATE = 0x0001, WM_MOUSEMOVE = 0x0200, WM_LBUTTONDOWN = 0x0201;
        #endregion

        #endregion

    }
}