using System;
using System.Runtime.InteropServices;

namespace mPanel.Extra
{
    public static class NativeMethods
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, uint msg, bool wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);
    }
}
