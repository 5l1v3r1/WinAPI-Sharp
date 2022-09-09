# WinAPI-Sharp
A test wrapper for C#, Just dll imports bruh.
I'm trying to add gdi functions first.

TODO List: PatBlt, StretchBltMode, and e.t.c

Import: using Windows;

Example code:
```cs
Random rnd = new Random();
IntPtr hdc = WinAPI.GetDC(IntPtr.Zero);
int x = Screen.PrimaryScreen.Bounds.Width;
int y = Screen.PrimaryScreen.Bounds.Height;
            
while (true)
{
    IntPtr brush = WinAPI.CreateSolidBrush((uint)rnd.Next(0xFFFFFF));
    WinAPI.SelectObject(hdc, brush);
    WinAPI.StretchBlt(hdc, rnd.Next(y), rnd.Next(x), x, y, hdc, rnd.Next(10), rnd.Next(30), x, y, CopyPixelOperation.MergeCopy ^ CopyPixelOperation.PatInvert);
    Thread.Sleep(100);
}
