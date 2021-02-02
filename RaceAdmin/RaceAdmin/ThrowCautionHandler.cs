using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace RaceAdmin
{
    internal class ThrowCautionHandler : ICautionHandler
    {
        [DllImport("User32.dll")]
        static extern int SetForegroundWindow(IntPtr point);


        // Attempts to throw the caution by sending the "!yellow" admin chat command
        // to iRacing. This should work OK when the user is driving but may be problematic
        // if a leauge admin tries to use it while actively interacting with mouse/keyboard
        // on their computer. Active league admins may prefer not to use this automatic
        // caution handler as it is primarily intended for use by league admins who are
        // also racing.
        public void CautionThresholdReached()
        {
            // TODO: offer both this method and the SDK-supported method of activating a chat
            // macro in iRacing. This chat macro approach is probably more reliable but requires
            // the user to configure one of their chat macros with the string "!yellow$" and then
            // configure our app to know the number (0-14) of the macro.

            // TODO: find a way to avoid hardcoding the iRacing executable name
            Process p = Process.GetProcessesByName("iRacingSim64DX11").FirstOrDefault();
            if (p != null)
            {
                // The timing with the Thread.Sleep() below is one of the problematic
                // requirements of this approach to IPC.
                IntPtr h = p.MainWindowHandle;
                SetForegroundWindow(h);
                SendKeys.SendWait("t");
                Thread.Sleep(1000); // delay required to let the chat box pop up
                SendKeys.SendWait("!yellow{ENTER}");
            }
        }

        public void YellowFlagThrown()
        {
            // nothing to do
        }

        public void GreenFlagThrown()
        {
            // nothing to do
        }
    }

}