using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace mPanel.Extra
{
    public static class Extensions
    {
        public static string InBetween(this string s, string start, string end)
        {
            if (string.IsNullOrWhiteSpace(start) || string.IsNullOrWhiteSpace(end))
                return string.Empty;

            var sIndex = s.IndexOf(start, StringComparison.Ordinal);
            var eIndex = s.IndexOf(end, StringComparison.Ordinal);

            return s.Substring(sIndex + start.Length, eIndex - sIndex - start.Length);
        }

        public static void SetCue(this TextBox t, string cue)
        {
            const uint emSetCueBanner = 0x1501;

            NativeMethods.SendMessage(t.Handle, emSetCueBanner, true, cue);
        }

        public static void ExInvoke<T>(this T t, Action<T> action) where T : ISynchronizeInvoke
        {
            try
            {
                t.Invoke(action, new object[] {t});
            }
            catch (ObjectDisposedException) { }
        }
    }
}
