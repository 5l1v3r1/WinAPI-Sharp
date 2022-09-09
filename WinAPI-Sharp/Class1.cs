using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Windows
{
    public class WinAPI
    {
        [DllImport("gdi32.dll", EntryPoint = "BitBlt", SetLastError = true)]
        static extern bool BitBltA([In] IntPtr hdc, int nXDest, int nYDest, int nWidth, int nHeight, [In] IntPtr hdcSrc, int nXSrc, int nYSrc, CopyPixelOperation dwRop);
        [return: MarshalAs(UnmanagedType.Bool)]
        public static void BitBlt(IntPtr hdc, int cx, int cy, int x, int y, IntPtr hdc2, int x1, int y1, CopyPixelOperation dwRop)
        {
            BitBltA(hdc, cx, cy, x, y, hdc, x1, y1, CopyPixelOperation.NotSourceCopy);
        }

        [DllImport("gdi32.dll", EntryPoint = "StretchBlt", SetLastError = true)]
        static extern bool StretchBltA(IntPtr hdcDest, int nXOriginDest, int nYOriginDest,
        int nWidthDest, int nHeightDest,
        IntPtr hdcSrc, int nXOriginSrc, int nYOriginSrc, int nWidthSrc, int nHeightSrc,
        CopyPixelOperation dwRop);
        public static void StretchBlt(IntPtr hdc, int nXOriginDest, int nYOriginDest, int nWidthDest, int nHeightDest, IntPtr hdcSrc, int nXOriginSrc, int nYOriginSrc, int nWidthSrc, int nHeightSrc, CopyPixelOperation dwRop)
        {
            StretchBltA(hdc, nXOriginDest, nYOriginDest, nWidthDest, nHeightDest, hdcSrc, nXOriginSrc, nYOriginSrc, nWidthSrc, nHeightSrc, dwRop);
        }
        [DllImport("user32.dll", EntryPoint = "GetDC", SetLastError = true)]
        static extern IntPtr GetDCa(IntPtr hWnd);
        public static IntPtr GetDC(IntPtr hWnd)
        {
            IntPtr hdc = GetDCa(hWnd);
            return hdc;
        }

        [DllImport("gdi32.dll", EntryPoint = "CreateSolidBrush", SetLastError = true)]
        static extern IntPtr CreateSolidBrushA(uint crColor);
        public static IntPtr CreateSolidBrush(uint crColor)
        {
            return CreateSolidBrushA(crColor);
        }
        [DllImport("gdi32.dll", EntryPoint = "SelectObject", SetLastError = true)]
        public static extern IntPtr SelectObjectA([In] IntPtr hdc, [In] IntPtr hgdiobj);
        public static void SelectObject(IntPtr hdc, IntPtr hgdiobj)
        {
            SelectObjectA(hdc, hgdiobj);
        }
    }
}
